using NBitcoin;
using NBitcoin.DataEncoders;
using ON.Crypto.Extra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHarness
{
    internal class FloCoin
    {
        public static void Test()
        {
            var derive = new TheGreatDerivator("abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon abandon about");

            var floMnemonic = derive.DeriveFlocoinMnemonic();
            Console.WriteLine("Mnemonic:");
            Console.WriteLine(floMnemonic);
            Console.WriteLine("Should be:");
            Console.WriteLine("cousin gown upgrade matrix middle room belt intact donor base road toward rabbit surge tomorrow curve bracket repair spider width solve timber insane state");

            Console.WriteLine();
            Console.WriteLine("Private WIF:");
            Console.WriteLine(derive.DeriveFlocoinWIF());
            Console.WriteLine("Should be:");
            Console.WriteLine("RF8qp7mbgu8WysNWmAYUj1sXsjon6Ycv5ptScgtbYbT1DWoTHFFa");

            Console.WriteLine();
            Console.WriteLine("Public Address:");
            Console.WriteLine(derive.DeriveFlocoinAddress());
            Console.WriteLine("Should be:");
            Console.WriteLine("FSDne6j7knfkvLnNZn6giXL4erbBKhk7gC");
        }
    }
}
