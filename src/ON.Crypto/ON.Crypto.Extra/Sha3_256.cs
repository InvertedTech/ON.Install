using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ON.Crypto.Extra
{
    public class Sha3_256
    {
        public static byte[] HashIt(in byte[] input)
        {
            var hashAlgorithm = new Org.BouncyCastle.Crypto.Digests.Sha3Digest(256);
            hashAlgorithm.BlockUpdate(input, 0, input.Length);
            byte[] result = new byte[32]; // 256 / 8 = 32
            hashAlgorithm.DoFinal(result, 0);
            return result;
        }
    }
}
