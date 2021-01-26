using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Program
    {
        static void Main(string[] args)
        {

            //////////////////Simulation simulation = new Simulation();
            //////////////////simulation.Simulate();




            //working code that prints coins to counsel

            ////step one instantiate wallet, 
            Wallet JTsWallet = new Wallet("My coin wallet");
            //Coin pennyInWallet = new Penny();

            Console.WriteLine(JTsWallet.walletName /*+ " contains a " + pennyInWallet.Name + " with a value of: " + pennyInWallet.Value*/);
            Console.ReadLine();
        }
    }
}
