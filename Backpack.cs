﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Backpack
    {
        //Member Variables (Has A)
        public List<Can> cans;
        //Constructor (Spawner)
        public Backpack()
        {
            cans = new List<Can>();
            Console.WriteLine("Customer creates the Backpack here");
            Console.ReadLine();
        }

        //Member Methods (Can Do)
    }
}
