using Google.Protobuf;
using Grpc.Core;
using NodeF.Fragments.Authentcation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestHarness
{
    class AuthenticationBackupClient
    {
        public AuthenticationBackupClient()
        {
        }

        public async Task<byte[]> GetBackup()
        {
            //byte[] buffer = new byte[1024 * 1024 * 1024];

            using (var wc = new WebClient())
            {
                wc.Headers["Accept"] = "application/octet-stream";
                wc.Headers["Authorization"] = "Bearer " + Program.JwtToken;
                return await wc.DownloadDataTaskAsync("http://localhost:8080/backup/authentication");
                //var stream = await wc.OpenReadTaskAsync("http://localhost:8080/backup/authentication");

                //while (true)
                //{
                //    var numBytes = await stream.ReadAsync(buffer, 0, 4);
                //    if (numBytes != 4)
                //        break;

                //    numBytes = BitConverter.ToInt32(buffer, 0);
                //    numBytes = await stream.ReadAsync(buffer, 0, numBytes);
                //    var rec = UserBackupDataRecord.Parser.ParseFrom(buffer, 0, numBytes);
                //}
            }
        }

        public async Task SetMode()
        {
            using (var wc = new WebClient())
            {
                wc.Headers["Authorization"] = "Bearer " + Program.JwtToken;
                await wc.UploadDataTaskAsync("http://localhost:8080/backup/authentication/restore/wipe", new byte[0]);
            }
        }

        public async Task RestoreFromBackup(byte[] data)
        {
            using (var wc = new WebClient())
            {
                wc.Headers["Accept"] = "application/octet-stream";
                wc.Headers["Authorization"] = "Bearer " + Program.JwtToken;
                var res = await wc.UploadDataTaskAsync("http://localhost:8080/backup/authentication", data);
                var res2 =RestoreAllDataResponse.Parser.ParseFrom(res);
            }
        }
    }
}
