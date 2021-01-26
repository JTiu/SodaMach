using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class SodaMachine
    {
        //Member Variables (Has A)
        private List<Coin> _register;
        private List<Can> _inventory;

        //Constructor (Spawner)
        public SodaMachine()
        {
            _register = new List<Coin>();
            _inventory = new List<Can>();
            FillInventory();
            FillRegister();
        }

        //Member Methods (Can Do)

        //A method to fill the sodamachines register with coin objects.
        public void FillRegister()
        {
           
        }
        //A method to fill the sodamachines inventory with soda can objects.
        public void FillInventory()
        {
            
        }
        //Method to be called to start a transaction.
        //Takes in a customer which can be passed freely to which ever method needs it.
        public void BeginTransaction(Customer customer)
        {
            bool willProceed = UserInterface.DisplayWelcomeInstructions(_inventory);
            if (willProceed)
            {
                Transaction(customer);
            }
        }
        
        //This is the main transaction logic think of it like "runGame".  This is where the user will be prompted for the desired soda.
        //grab the desired soda from the inventory.
        //get payment from the user.
        //pass payment to the calculate transaction method to finish up the transaction based on the results.
        private void Transaction(Customer customer)
        {
           
        }
        //Gets a soda from the inventory based on the name of the soda.
        private Can GetSodaFromInventory(string nameOfSoda)
        {
            Can GetSodaFromInventory = new Cola();
            return GetSodaFromInventory;
                
        }

        ////This is the main method for calculating the result of the transaction.
        ////It takes in the payment from the customer, the soda object they selected, and the customer who is purchasing the soda.
        //// If statements - the very first word of each statement in the comments 
        ///// check the payment - if greater than price of soda AND the soda machine has enough change to return (check the register)
        ////result - dispense the chosen soda and give change to the customer
        ////This is the method that will determine the following:
        ////If the payment is greater than the price of the soda, and if the sodamachine has enough change to return: Dispense soda, and change to the customer.
        ////If the payment is greater than the cost of the soda, but the machine does not have ample change: Dispense payment back to the customer.
        ////If the payment is exact to the cost of the soda:  Dispense soda.
        ////If the payment does not meet the cost of the soda: dispense payment back to the customer.
        //Takes in the value of the amount of change needed.
        //Attempts to gather all the required coins from the sodamachine's register to make change.
        //Returns the list of coins as change to despense.
        //If the change cannot be made, return null.
        private void CalculateTransaction(List<Coin> payment, Can chosenSoda, Customer customer)
        {


            //if (payment > priceOfSoda && sodaMachineRegister > changeToReturn)
            //{
            //    Console.WriteLine("dispenseSoda + returnChange + place soda in backpack");
            //}
            //else if (payment > priceOfSoda && sodaMachineRegister < changeToReturn)
            //{
            //    Console.WriteLine("dispense payment back to customer");
            //}
            //else if (payment == priceOfSoda)
            //{
            //    Console.WriteLine("dispense soda + place soda in backpack");
            //}
            //else if (payment < priceOfSoda)
            //{
            //    Console.WriteLine("dispense payment back to customer");
            //}
            //else if (payment < priceOfSoda && inventoryNotSufficient)
            //{
            //    Console.WriteLine("dispense payment back to customer");
            //}

        }

        private List<Coin> GatherChange(double changeValue)
        {
            List<Coin> REturnList = new List<Coin>();
            return REturnList;
        }
        //Reusable method to check if the register has a coin of that name.
        //If it does have one, return true.  Else, false.
        private bool RegisterHasCoin(string name)
        {
            return true;
        }
        //Reusable method to return a coin from the register.
        //Returns null if no coin can be found of that name.
        private Coin GetCoinFromRegister(string name)
        {
            Coin returnCoin = new Coin();
            return returnCoin;
        }
        //Takes in the total payment amount and the price of can to return the change amount.
        private double DetermineChange(double totalPayment, double canPrice)
        {
            return 6;///place holder next two lines
        }
        //Takes in a list of coins to returnt he total value of the coins as a double.
        private double TotalCoinValue(List<Coin> payment)
        {
            return 6;///place holder next two lines
        }
        //Puts a list of coins into the soda machines register.
        private void DepositCoinsIntoRegister(List<Coin> coins)
        {
           
        }
    }
}
