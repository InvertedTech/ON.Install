using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Microsoft.Extensions.Options;
using ON.Authorization.Crypto.Service.Models;
using ON.Fragments.Authorization;
using ON.Fragments.Authorization.Payments.Crypto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ON.Authorization.Crypto.Service.Data
{
    public class FileSystemBitcoinServiceRecordProvider : IBitcoinServiceRecordProvider
    {
        private readonly DirectoryInfo dataDir;
        private readonly FileInfo dataFile;

        public FileSystemBitcoinServiceRecordProvider(IOptions<AppSettings> settings)
        {
            var root = new DirectoryInfo(settings.Value.DataStore);
            root.Create();
            dataDir = root.CreateSubdirectory("service");
            dataFile = new FileInfo(dataDir.FullName + "\\record");
        }

        public async Task<int> GetNextAddressNumber()
        {
            for (int i = 0; i < 100; i++)
            {
                try
                {
                    return await GetNextAddressNumber_Safe();
                }
                catch
                {
                    await Task.Delay(i);
                }
            }

            throw new Exception("Cannot get next Bitcoin receive address");
        }

        private Task<int> GetNextAddressNumber_Safe()
        {
            using (var fs = File.Open(dataFile.FullName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
            {
                BitcoinServiceRecord rec;
                try
                {
                    rec = BitcoinServiceRecord.Parser.ParseFrom(fs);
                }
                catch
                {
                    //fs.SetLength(0);
                    rec = new BitcoinServiceRecord()
                    {
                        LastAddressUsed = -1,
                    };
                }

                rec.LastAddressUsed++;
                rec.ModifiedOnUTC = Timestamp.FromDateTime(DateTime.UtcNow);

                fs.SetLength(0);
                rec.WriteTo(fs);

                return Task.FromResult(rec.LastAddressUsed);
            }
        }
    }
}
