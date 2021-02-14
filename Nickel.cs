using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Nickel:Coin
    {
        //Member Variables (Has A)

        //Constructor (Spawner)
        public Nickel()
        {
            Name = "Nickel";//no lock

            Worth = .05;//has a wrench
        }
        //Member Methods (Can Do)
    }
}
