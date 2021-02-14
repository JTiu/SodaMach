using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Dime:Coin
    {
        //Member Variables (Has A)

        //Constructor (Spawner)
        public Dime()
        {
            Name = "Dime";// no lock on the box
            Worth = .10;//Worth has a wrench
        }

        //Member Methods (Can Do)
    }
}
