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
       
        //Constructor (Spawner)
        public Penny()
        {


            Name = "Penny";//no lock on the box

            Worth = .01;//has a wrench

        }
        //Member Methods (Can Do)
    }
}
