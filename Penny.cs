using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Penny:Coin
    {
        //Member Variables (Has A)
        //// take this out if program runs:::: public string pennyInWallet;

        //Constructor (Spawner)
        public Penny()
        {
            Name = "Shiny Penny";
            value = .01;
            //take this out if program runspennyInWallet = "this in a penny in my wallet";
        }
        //Member Methods (Can Do)
    }
}
