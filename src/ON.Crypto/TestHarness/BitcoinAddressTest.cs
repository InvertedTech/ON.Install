using NBitcoin;
using ON.Crypto.Extra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHarness
{
    internal class BitcoinAddressTest
    {
        public static void Test()
        {
            var derive = new TheGreatDerivator("abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon about");//TheGreatDerivator.GenerateNewMnemonic());

            var parentKey = derive.DeriveBitcoinExtendPrivateKey();
            Console.WriteLine(parentKey.GetWif(Network.Main).ToString());
            var sample1 = parentKey.Derive(new KeyPath("0/0"));
            var sample1Pub = sample1.GetPublicKey();
            var addr1 = sample1Pub.GetAddress(ScriptPubKeyType.Legacy, Network.Main);
            var addr1Str = addr1.ToString();
            Console.WriteLine(addr1Str);

            var pubParent = parentKey.Neuter();
            var pubWif = pubParent.GetWif(Network.Main).ToString();
            Console.WriteLine(pubWif);
            var sample2 = pubParent.Derive(new KeyPath("0/0"));
            var sample2Pub = sample2.GetPublicKey();
            var addr2 = sample2Pub.GetAddress(ScriptPubKeyType.Legacy, Network.Main);
            var addr2Str = addr2.ToString();
            Console.WriteLine(addr2Str);

            pubParent = ExtPubKey.Parse(pubWif, Network.Main);
            for (int i = 0; i < 10; i++)
            {
                var myaddr = pubParent.Derive(new KeyPath("0/" + i.ToString()));
                Console.WriteLine(myaddr.GetPublicKey().GetAddress(ScriptPubKeyType.Legacy, Network.Main));
            }


        }
        public static void Test2()
        {
            var derive = new TheGreatDerivator("ginger cotton giggle lift buzz security vague repair decide jaguar hire way");//TheGreatDerivator.GenerateNewMnemonic());
            var mnemo = new Mnemonic("ginger cotton giggle lift buzz security vague repair decide jaguar hire way", Wordlist.English);
            var master = mnemo.DeriveExtKey("Asdfasdf");
            Console.WriteLine(master.GetWif(Network.Main).ToString());

            //var parentKey = derive.DeriveFlocoinExtendPrivateKey();
            //Console.WriteLine(parentKey.GetWif(Network.Main).ToString());
            //var sample1 = parentKey.Derive(new KeyPath("0/0"));
            //var sample1Pub = sample1.GetPublicKey();
            //var addr1 = sample1Pub.GetAddress(ScriptPubKeyType.Legacy, Network.Main);
            //var addr1Str = addr1.ToString();
            //Console.WriteLine(addr1Str);

            //var pubParent = parentKey.Neuter();
            //var pubWif = pubParent.GetWif(Network.Main).ToString();
            //Console.WriteLine(pubWif);
            //var sample2 = pubParent.Derive(new KeyPath("0/0"));
            //var sample2Pub = sample2.GetPublicKey();
            //var addr2 = sample2Pub.GetAddress(ScriptPubKeyType.Legacy, Network.Main);
            //var addr2Str = addr2.ToString();
            //Console.WriteLine(addr2Str);

            //pubParent = ExtPubKey.Parse(pubWif, Network.Main);
            //for (int i = 0; i < 10; i++)
            //{
            //    var myaddr = pubParent.Derive(new KeyPath("0/" + i.ToString()));
            //    Console.WriteLine(myaddr.GetPublicKey().GetAddress(ScriptPubKeyType.Legacy, Network.Main));
            //}


        }
    }
}
