using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Quarter:Coin
    {
        //Member Variables (Has A)

        //Constructor (Spawner)
        public Quarter()
        {
            Name = "Quarter";
            value = .25;
            Console.WriteLine("here is your quarter");
            Console.ReadLine();
        }

        //Member Methods (Can Do)
    }
}
