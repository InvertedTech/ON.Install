using Google.Protobuf;
using Grpc.Core;
using NodeF.Crypto;
using NodeF.Fragments.Authentcation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TestHarness
{
    class AuthenticationBackupClient
    {
        public AuthenticationBackupClient()
        {
        }

        public async Task<byte[]> GetBackup(string clientPubKey)
        {
            using (var wc = new WebClient())
            {
                wc.Headers["Accept"] = "application/octet-stream";
                wc.Headers["Authorization"] = "Bearer " + Program.JwtToken;
                return await wc.DownloadDataTaskAsync("http://localhost:8080/backup/authentication?key=" + clientPubKey);
            }
        }

        public async Task RestoreFromBackup(RestoreAllDataRequest.Types.RestoreMode mode, ECDsa clientKey, byte[] data)
        {
            using MemoryStream inStream = new MemoryStream();
            inStream.Write(data);
            inStream.Position = 0;

            var keyRecord = BackupAllDataResponse.Parser.ParseDelimitedFrom(inStream);
            var serverPubJwk = keyRecord.ServerPublicJwk;
            var decKey = EcdhHelper.DeriveKeyClient(clientKey, serverPubJwk.DecodeJsonWebKey());

            string url = "http://localhost:8080/backup/authentication/";
            switch (mode)
            {
                case RestoreAllDataRequest.Types.RestoreMode.MissingOnly:
                    url += "restore/missing";
                    break;
                case RestoreAllDataRequest.Types.RestoreMode.Overwrite:
                    url += "restore/overwrite";
                    break;
                case RestoreAllDataRequest.Types.RestoreMode.Wipe:
                    url += "restore/wipe";
                    break;
            }

            using var wc = new WebClient();
            wc.Headers["Accept"] = "application/octet-stream";
            wc.Headers["Authorization"] = "Bearer " + Program.JwtToken;
            var res = await wc.UploadDataTaskAsync(url, DecryptAll(decKey, inStream));
            var res2 = RestoreAllDataResponse.Parser.ParseFrom(res);
        }

        private byte[] DecryptAll(byte[] key, MemoryStream inStream)
        {
            using MemoryStream outStream = new MemoryStream();

            while (inStream.Position != inStream.Length)
                GetOne(key, inStream, outStream);

            return outStream.ToArray();
        }

        private void GetOne(byte[] key, Stream inStream, Stream outStream)
        {
            var r = BackupAllDataResponse.Parser.ParseDelimitedFrom(inStream);
            AesHelper.Decrypt(key, r.EncryptedRecord.EncryptionIV.ToByteArray(), r.EncryptedRecord.Data.ToByteArray(), out var plaintText);
            var req = new RestoreAllDataRequest()
            {
                Record = UserBackupDataRecord.Parser.ParseFrom(plaintText)
            };

            req.WriteDelimitedTo(outStream);
        }
    }
}
