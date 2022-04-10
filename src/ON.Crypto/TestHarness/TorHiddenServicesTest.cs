using ON.Crypto;
using ON.Crypto.Extra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHarness
{
    internal class TorHiddenServicesTest
    {
        public static void Test()
        {
            //var derive = new TheGreatDerivator(TheGreatDerivator.GenerateNewMnemonic());
            var derive = new TheGreatDerivator("abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon about");

            var tor = derive.DeriveTorV3Key(0, 0);
            Console.WriteLine(tor.privEncodedKey);
            Console.WriteLine(tor.pubOnionName);
            Console.WriteLine("Should be:\nbc5wgzqo4wwoqek773ohqfgfaenlbctvokdeksofcqzrtgsoneryx5id.onion");
        }
    }
}
