using NBitcoin;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ON.Crypto.Extra
{
    public class TheGreatDerivator
    {
        private readonly ExtKey master;

        private const string BITCOIN_RECEIVE_PATH = "49'/0'/0'/0";

        private const string KEYPATH_JWTKEY = "12021'/0'";
        private const string KEYPATH_SSHKEY = "12021'/1'";
        private const string KEYPATH_BACKUPKEY = "12021'/2'";

        public TheGreatDerivator(string mnemoWords, string passphrase = null)
        {
            var mnemo = new Mnemonic(mnemoWords, Wordlist.English);
            if (!mnemo.IsValidChecksum)
                throw new Exception("24 word phrase not valid!");
            master = mnemo.DeriveExtKey(passphrase);
        }

        public static string GenerateNewMnemonic()
        {
            Mnemonic mnemo = new Mnemonic(Wordlist.English, WordCount.TwentyFour);
            return mnemo.ToString();
        }

        public ECDsa DeriveBackupKey(uint account = 0, uint keyNum = 0)
        {
            var jwtKey = master.Derive(new KeyPath($"{KEYPATH_BACKUPKEY}/{account}'/{keyNum}'"));

            return ECDsa.Create(new ECParameters()
            {
                Curve = ECCurve.NamedCurves.nistP256,
                D = jwtKey.PrivateKey.ToBytes()
            });
        }

        public ExtKey DeriveBitcoinExtendPrivateKey()
        {
            return master.Derive(new KeyPath(BITCOIN_RECEIVE_PATH));
        }

        public ECDsa DeriveEcJwtKey(uint account = 0, uint keyNum = 0)
        {
            var jwtKey = master.Derive(new KeyPath($"{KEYPATH_JWTKEY}/{account}'/{keyNum}'"));

            return ECDsa.Create(new ECParameters()
            {
                Curve = ECCurve.NamedCurves.nistP256,
                D = jwtKey.PrivateKey.ToBytes()
            });
        }

        public (string privSshKey, string pubSshKey) DeriveEcSshKey(uint account = 0, uint keyNum = 0)
        {
            var sshKey = master.Derive(new KeyPath($"{KEYPATH_SSHKEY}/{account}'/{keyNum}'"));

            var eckey = ECDsa.Create(new ECParameters()
            {
                Curve = ECCurve.NamedCurves.nistP256,
                D = sshKey.PrivateKey.ToBytes()
            });

            return (GenerateSshPrivFile(eckey), GenerateSshPubLine(eckey));
        }

        private static string GenerateSshPrivFile(ECDsa key)
        {
            List<byte> bytes = new List<byte>();

            Random r = new Random();
            byte[] checkint = new byte[4];
            r.NextBytes(checkint);

            var parameters = key.ExportParameters(true);

            bytes.AddRange(Convert.FromHexString("6f70656e7373682d6b65792d763100000000046e6f6e65000000046e6f6e650000000000000001000000680000001365636473612d736861322d6e69737470323536000000086e697374703235360000004104"));
            bytes.AddRange(parameters.Q.X);
            bytes.AddRange(parameters.Q.Y);
            bytes.AddRange(Convert.FromHexString("000000b0"));
            bytes.AddRange(checkint);
            bytes.AddRange(checkint);
            bytes.AddRange(Convert.FromHexString("0000001365636473612d736861322d6e69737470323536000000086e697374703235360000004104"));
            bytes.AddRange(parameters.Q.X);
            bytes.AddRange(parameters.Q.Y);
            bytes.AddRange(Convert.FromHexString("00000020"));
            bytes.AddRange(parameters.D);
            bytes.AddRange(Convert.FromHexString("0000001265636473612d6b65792d3230313930393230010203040506"));

            var sb = new StringBuilder();
            sb.Append("-----BEGIN OPENSSH PRIVATE KEY-----\n");

            string str = Convert.ToBase64String(bytes.ToArray());
            while (str.Length > 0)
            {
                int len = Math.Min(64, str.Length);
                sb.Append(str.Substring(0, len));
                sb.Append("\n");
                str = str.Substring(len);
            }

            sb.Append("-----END OPENSSH PRIVATE KEY-----\n");
            return sb.ToString();
        }

        private static string GenerateSshPubLine(ECDsa key)
        {
            List<byte> bytes = new List<byte>();

            var parameters = key.ExportParameters(true);

            bytes.AddRange(Convert.FromHexString("0000001365636473612d736861322d6e69737470323536000000086e697374703235360000004104"));
            bytes.AddRange(parameters.Q.X);
            bytes.AddRange(parameters.Q.Y);

            var sb = new StringBuilder();
            sb.Append("ecdsa-sha2-nistp256 ");

            sb.Append(Convert.ToBase64String(bytes.ToArray()));

            sb.Append(" ecdsa-key-20190920");
            return sb.ToString();
        }
    }
}
