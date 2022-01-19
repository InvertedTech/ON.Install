using Google.Protobuf;
using Grpc.Core;
using Auth = ON.Fragments.Authentication;
using Content = ON.Fragments.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstallerApp.Security;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using ON.Authentication;
using System.Security.Claims;
using ON.Crypto;
using System.IO;

namespace InstallerApp.BackupRestore
{
    public class BackupRestoreServer
    {
        private ServiceNameHelper nameHelper;
        private KeyHelper keyHelper;
        private DirectoryInfo rootBackupDir;

        private const string FILENAME_AUTH = "auth.data";
        private const string FILENAME_CMS = "cms.data";

        public BackupRestoreServer(DirectoryInfo rootBackupDir, ServiceNameHelper nameHelper, KeyHelper keyHelper)
        {
            this.rootBackupDir = rootBackupDir;
            this.nameHelper = nameHelper;
            this.keyHelper = keyHelper;
        }

        public async Task BackupAll(uint backupNum)
        {
            await BackupAuth(backupNum);
            await BackupContent(backupNum);
        }

        public async Task BackupAuth(uint backupNum)
        {
            var file = new FileInfo(GenerateDirectory(backupNum).FullName + "/" + FILENAME_AUTH);

            var req = new Auth.BackupAllDataRequest()
            {
                ClientPublicJwk = keyHelper.DeriveEcBackupKey(0, backupNum).ToPublicEncodedJsonWebKey()
            };

            var client = new Auth.BackupInterface.BackupInterfaceClient(nameHelper.AuthenticationServiceChannel);
            using var call = client.BackupAllData(req, GetMetadata());

            using var fstream = file.Create();

            await foreach (var response in call.ResponseStream.ReadAllAsync())
            {
                response.WriteDelimitedTo(fstream);
            }
        }

        public async Task BackupContent(uint backupNum)
        {
            var file = new FileInfo(GenerateDirectory(backupNum).FullName + "/" + FILENAME_CMS);

            var req = new Content.BackupAllDataRequest()
            {
                ClientPublicJwk = keyHelper.DeriveEcBackupKey(0, backupNum).ToPublicEncodedJsonWebKey()
            };

            var client = new Content.BackupInterface.BackupInterfaceClient(nameHelper.ContentServiceChannel);
            using var call = client.BackupAllData(req, GetMetadata());

            using var fstream = file.Create();

            await foreach (var response in call.ResponseStream.ReadAllAsync())
            {
                response.WriteDelimitedTo(fstream);
            }
        }

        public async Task RestoreAll(uint backupNum)
        {
            await RestoreAuth(backupNum);
            await RestoreContent(backupNum);
        }

        public async Task<Auth.RestoreAllDataResponse> RestoreAuth(uint backupNum)
        {
            var file = new FileInfo(GenerateDirectory(backupNum).FullName + "/" + FILENAME_AUTH);

            using var fstream = file.OpenRead();
            var keyRec = Auth.BackupAllDataResponse.Parser.ParseDelimitedFrom(fstream);

            var backupPrivKey = keyHelper.DeriveEcBackupKey(0, backupNum);
            var decKey = EcdhHelper.DeriveKeyClient(backupPrivKey, keyRec.ServerPublicJwk.DecodeJsonWebKey());

            var client = new Auth.BackupInterface.BackupInterfaceClient(nameHelper.AuthenticationServiceChannel);
            using var call = client.RestoreAllData(GetMetadata());

            await call.RequestStream.WriteAsync(new Auth.RestoreAllDataRequest()
            {
                Mode = Auth.RestoreAllDataRequest.Types.RestoreMode.Wipe,
            });

            while (fstream.Position != fstream.Length)
            {
                var encRec = Auth.BackupAllDataResponse.Parser.ParseDelimitedFrom(fstream);
                AesHelper.Decrypt(decKey, encRec.EncryptedRecord.EncryptionIV.ToByteArray(), encRec.EncryptedRecord.Data.ToByteArray(), out var plaintText);

                var decRec = Auth.UserBackupDataRecord.Parser.ParseFrom(plaintText);

                await call.RequestStream.WriteAsync(new Auth.RestoreAllDataRequest()
                {
                    Record = decRec,
                });
            }

            await call.RequestStream.CompleteAsync();

            var res = await call;
            return res;
        }

        public async Task<Content.RestoreAllDataResponse> RestoreContent(uint backupNum)
        {
            var file = new FileInfo(GenerateDirectory(backupNum).FullName + "/" + FILENAME_CMS);

            using var fstream = file.OpenRead();
            var keyRec = Content.BackupAllDataResponse.Parser.ParseDelimitedFrom(fstream);

            var backupPrivKey = keyHelper.DeriveEcBackupKey(0, backupNum);
            var decKey = EcdhHelper.DeriveKeyClient(backupPrivKey, keyRec.ServerPublicJwk.DecodeJsonWebKey());

            var client = new Content.BackupInterface.BackupInterfaceClient(nameHelper.ContentServiceChannel);
            using var call = client.RestoreAllData(GetMetadata());

            await call.RequestStream.WriteAsync(new Content.RestoreAllDataRequest()
            {
                Mode = Content.RestoreAllDataRequest.Types.RestoreMode.Wipe,
            });

            while (fstream.Position != fstream.Length)
            {
                var encRec = Content.BackupAllDataResponse.Parser.ParseDelimitedFrom(fstream);
                AesHelper.Decrypt(decKey, encRec.EncryptedRecord.EncryptionIV.ToByteArray(), encRec.EncryptedRecord.Data.ToByteArray(), out var plaintText);

                var decRec = Content.ContentBackupDataRecord.Parser.ParseFrom(plaintText);

                await call.RequestStream.WriteAsync(new Content.RestoreAllDataRequest()
                {
                    Record = decRec,
                });
            }

            await call.RequestStream.CompleteAsync();

            var res = await call;
            return res;
        }

        public async Task<Auth.RestoreAllDataResponse> RestoreOneAuth(Auth.UserBackupDataRecord rec)
        {
            var client = new Auth.BackupInterface.BackupInterfaceClient(nameHelper.AuthenticationServiceChannel);
            using var call = client.RestoreAllData(GetMetadata());

            await call.RequestStream.WriteAsync(new Auth.RestoreAllDataRequest()
            {
                Mode = Auth.RestoreAllDataRequest.Types.RestoreMode.Overwrite,
            });

            await call.RequestStream.WriteAsync(new Auth.RestoreAllDataRequest()
            {
                Record = rec,
            });

            await call.RequestStream.CompleteAsync();

            var res = await call;
            return res;
        }

        public async Task<Content.RestoreAllDataResponse> RestoreOneContent(Content.ContentBackupDataRecord rec)
        {
            var client = new Content.BackupInterface.BackupInterfaceClient(nameHelper.ContentServiceChannel);
            using var call = client.RestoreAllData(GetMetadata());

            await call.RequestStream.WriteAsync(new Content.RestoreAllDataRequest()
            {
                Mode = Content.RestoreAllDataRequest.Types.RestoreMode.Overwrite,
            });

            await call.RequestStream.WriteAsync(new Content.RestoreAllDataRequest()
            {
                Record = rec,
            });

            await call.RequestStream.CompleteAsync();

            var res = await call;
            return res;
        }

        private Metadata GetMetadata()
        {
            var data = new Metadata();
            data.Add("Authorization", "Bearer " + GenerateToken());

            return data;
        }

        private DirectoryInfo GenerateDirectory(uint backupNum)
        {
            var num = backupNum.ToString("0000");
            num = num.Substring(num.Length - 4, 4);
            return rootBackupDir.CreateSubdirectory(num.Substring(0, 2)).CreateSubdirectory(num.Substring(2, 2));
        }


        private string GenerateToken()
        {
            var jwtKey = keyHelper.DeriveEcJwtKey();
            //var key = jwtKey.ToPrivateJsonWebKey();
            var key = "eyJBZGRpdGlvbmFsRGF0YSI6e30sIkFsZyI6IkVTMjU2IiwiQ3J2IjoiUC0yNTYiLCJEIjoiT29QN3dhcUdtLU1fYU43N1dGSlZlXzc4Y2loMUZEX09hVmp5eHp6Q19SbyIsIkRQIjpudWxsLCJEUSI6bnVsbCwiRSI6bnVsbCwiSyI6bnVsbCwiS2V5SWQiOiJmNjBiMjNkNy1hN2JjLTQyY2MtYTRiNC1lN2JmMjQ4NmJjODkiLCJLZXlPcHMiOltdLCJLaWQiOiJmNjBiMjNkNy1hN2JjLTQyY2MtYTRiNC1lN2JmMjQ4NmJjODkiLCJLdHkiOiJFQyIsIk4iOm51bGwsIk90aCI6bnVsbCwiUCI6bnVsbCwiUSI6bnVsbCwiUUkiOm51bGwsIlVzZSI6InNpZyIsIlgiOiJUM0JDOVBSU2RqYUhwRXhVcXpnVGkxa3lfam8wb1hIcy1tU2g3RGxFVkUwIiwiWDVjIjpbXSwiWDV0IjpudWxsLCJYNXRTMjU2IjpudWxsLCJYNXUiOm51bGwsIlkiOiIyOGY0S0tLSHJnd18zZnhKUmxfVzR4TGRybkVRdU9BY19nTDI3S01zQ1I4IiwiS2V5U2l6ZSI6MjU2LCJIYXNQcml2YXRlS2V5Ijp0cnVlLCJDcnlwdG9Qcm92aWRlckZhY3RvcnkiOnsiQ3J5cHRvUHJvdmlkZXJDYWNoZSI6e30sIkN1c3RvbUNyeXB0b1Byb3ZpZGVyIjpudWxsLCJDYWNoZVNpZ25hdHVyZVByb3ZpZGVycyI6dHJ1ZX19".DecodeJsonWebKey();

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.EcdsaSha256)
            };

            tokenDescriptor.Claims = new Dictionary<string, object>();
            tokenDescriptor.Claims.Add(ONUser.IdType, Guid.NewGuid().ToString());
            tokenDescriptor.Claims.Add(ClaimTypes.Role, "backup");

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
