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
            _customer = new Customer();
            _sodaMachine = new SodaMachine();
        }

        //Member Methods
        public void Simulate()
        {
            bool willProceed = true;
            while (willProceed)
            {
                _sodaMachine.BeginTransaction(_customer);
                willProceed = UserInterface.ContinuePrompt("Continue to next transaction?");
                Console.Clear();
            }
           
        }
    }
}
