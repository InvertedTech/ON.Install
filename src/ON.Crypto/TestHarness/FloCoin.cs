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
            uint account = 0;

            Console.WriteLine("Mnemonic:");
            Console.WriteLine(derive.DeriveFlocoinMnemonic(account));
            Console.WriteLine("Should be:");
            Console.WriteLine("cousin gown upgrade matrix middle room belt intact donor base road toward rabbit surge tomorrow curve bracket repair spider width solve timber insane state");

            Console.WriteLine();
            Console.WriteLine("Private WIF:");
            Console.WriteLine(derive.DeriveFlocoinWIF(account));
            Console.WriteLine("Should be:");
            Console.WriteLine("RF8qp7mbgu8WysNWmAYUj1sXsjon6Ycv5ptScgtbYbT1DWoTHFFa");

            Console.WriteLine();
            Console.WriteLine("Public Address:");
            Console.WriteLine(derive.DeriveFlocoinAddress(account));
            Console.WriteLine("Should be:");
            Console.WriteLine("FSDne6j7knfkvLnNZn6giXL4erbBKhk7gC");


            account = 1;

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Mnemonic:");
            Console.WriteLine(derive.DeriveFlocoinMnemonic(account));
            Console.WriteLine("Should be:");
            Console.WriteLine("invest lens nephew quality potato desert will clog card debris mother salmon fury faint neither lift easy peanut crop member afraid soon flower shallow");

            Console.WriteLine();
            Console.WriteLine("Private WIF:");
            Console.WriteLine(derive.DeriveFlocoinWIF(account));
            Console.WriteLine("Should be:");
            Console.WriteLine("RAdXy2T8YYk6746emtzdrpG88HP65FQtPRfUKkFs9r5MKxm6wcxP");

            Console.WriteLine();
            Console.WriteLine("Public Address:");
            Console.WriteLine(derive.DeriveFlocoinAddress(account));
            Console.WriteLine("Should be:");
            Console.WriteLine("FDsEoKpDbxYX1ZLcSPFzx4wBMyS1QYjUBd");
            Console.WriteLine();
        }
    }
}
