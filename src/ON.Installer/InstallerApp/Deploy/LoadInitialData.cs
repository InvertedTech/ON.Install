using InstallerApp.BackupRestore;
using ON.Fragments.Generic;
using ON.Fragments.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace InstallerApp.Deploy
{
    internal class LoadInitialData
    {
        private static readonly HashAlgorithm hasher = SHA256.Create();

        internal static async Task Load(DeployWindow window)
        {
            try
            {
                await window.AddLine("--- Load Initial Data ---");

                var date = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);
                var password = "admin";

                var record = new UserRecord()
                {
                    Public = new UserRecord.Types.PublicData()
                    {
                        UserID = Guid.NewGuid().ToString(),
                        UserName = "admin",
                        DisplayName = "Admin",
                        CreatedOnUTC = date,
                        ModifiedOnUTC = date,
                    },
                    Private = new UserRecord.Types.PrivateData()
                };
                record.Public.Roles.Add("admin");

                byte[] salt = RandomNumberGenerator.GetBytes(16);
                record.Private.PasswordSalt = Google.Protobuf.ByteString.CopyFrom(salt);
                record.Private.PasswordHash = Google.Protobuf.ByteString.CopyFrom(ComputeSaltedHash(Encoding.UTF8.GetBytes(password), salt));

                await window.backup.RestoreOneAuth(new UserBackupDataRecord()
                {
                    Data = record,
                });

                await window.AddLine("Change complete");
            }
            catch (Exception ex)
            {
                await window.AddLine(ex.Message);
            }
        }

        private static byte[] ComputeSaltedHash(ReadOnlySpan<byte> plainText, ReadOnlySpan<byte> salt)
        {
            byte[] plainTextWithSaltBytes = new byte[plainText.Length + salt.Length];

            plainText.CopyTo(plainTextWithSaltBytes.AsSpan());
            salt.CopyTo(plainTextWithSaltBytes.AsSpan(plainText.Length));

            return hasher.ComputeHash(plainTextWithSaltBytes);
        }
    }
}
