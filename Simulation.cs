using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Simulation
    {
        //Member Variables (Has A)
        Customer _customer;
        SodaMachine _sodaMachine;
        

        //Constructor (Spawner)
        public Simulation()
        {
            Console.WriteLine("Before the simulated interaction begins, create a Customer and create a SodaMachine");
            Console.ReadLine();
            _customer = new Customer();
            _sodaMachine = new SodaMachine();
            Simulate();
            Console.WriteLine("The Simulation is complete");
            Console.ReadLine();
            
        }

        //Member Methods
        public void Simulate()
        {
            _sodaMachine.BeginTransaction(_customer);
            //bool willProceed = true; //Allows Soda machine to continue to run, so that coins & cans reduce with every trx
            //while (willProceed)
            //{
            //    _sodaMachine.BeginTransaction(_customer);
            //    willProceed = UserInterface.ContinuePrompt("Continue to next transaction?");
            //    Console.Clear();
            //    //Console.WriteLine("Simulate Method called here");
            //    //Console.ReadLine();
            //}
           
        }
    }
}
