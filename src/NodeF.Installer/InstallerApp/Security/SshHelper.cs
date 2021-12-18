using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstallerApp.Security
{
    public class SshHelper
    {
        public static (string privKey, string pubKey) CreateRSAKey(string keyName)
        {
            var keygen = new SshKeyGenerator.SshKeyGenerator(2048);

            var privKey = keygen.ToPrivateKey();
            var pubKey = keygen.ToRfcPublicKey(keyName);

            return (privKey, pubKey);
        }
    }
}
