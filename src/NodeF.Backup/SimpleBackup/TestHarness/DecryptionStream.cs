using Google.Protobuf;
using NodeF.Crypto;
using NodeF.Fragments.Authentcation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHarness
{
    class DecryptionStream : Stream
    {
        private readonly byte[] key;
        private readonly Stream inStream;

        public DecryptionStream(byte[] key,Stream inStream)
        {
            this.key = key;
            this.inStream = inStream;
        }

        public override bool CanRead => true;

        public override bool CanSeek => false;

        public override bool CanWrite => false;

        public override long Length => throw new NotImplementedException();

        public override long Position { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void Flush()
        {
            throw new NotImplementedException();
        }

        private MemoryStream mem = new();
        private byte[] bytesToSend = null;
        public override int Read(byte[] buffer, int offset, int count)
        {
            if (bytesToSend == null)
                bytesToSend = GetOne();

            if (bytesToSend == null)
                return 0;

                var numBytes = Math.Min(bytesToSend.Length, count);
            Buffer.BlockCopy(bytesToSend, 0, buffer, offset, numBytes);

            if (numBytes == bytesToSend.Length)
            {
                bytesToSend = null;
                return numBytes;
            }

            bytesToSend = bytesToSend.Skip(numBytes).ToArray();
            return numBytes;
        }

        private byte[] GetOne()
        {
            if (inStream.Length == inStream.Position)
                return null;

            var r = BackupAllDataResponse.Parser.ParseDelimitedFrom(inStream);
            AesHelper.Decrypt(key, r.EncryptedRecord.EncryptionIV.ToByteArray(), r.EncryptedRecord.Data.ToByteArray(), out var plaintText);
            var req = new RestoreAllDataRequest()
            {
                Record = UserBackupDataRecord.Parser.ParseFrom(plaintText)
            };

            mem.Position = 0;
            req.WriteDelimitedTo(mem);
            int len = (int)mem.Position;
            mem.Position = 0;

            var bytes = new byte[len];
            mem.Read(bytes, 0, len);

            return bytes;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotImplementedException();
        }

        public override void SetLength(long value)
        {
            throw new NotImplementedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotImplementedException();
        }
    }
}
