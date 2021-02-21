using System;
using System.Collections.Generic;

namespace SodaMachine
{
    class Backpack
    {
        //Member Variables (Has A)
        public List<Can> cans;
        //public double totalCansBackpack;//used to count
        //public List<Can> Canz = new List<Can>(); //constructs a list
        //Constructor (Spawner)
        public Backpack()
        {
            //this.totalCansBackpack = 0;
            //Canz = new List<Can>();
            Console.WriteLine($"The Customer gets a backpack here");/* current can count of {totalCansBackpack}");*/
            Console.ReadLine();
        }

        private void AddCanToBackpack(Can can) //method to add 
        {
            this.cans.Add(can);
            //excellent method to watch backpack fill

        }
        //Member Methods (Can Do)
    }
}
