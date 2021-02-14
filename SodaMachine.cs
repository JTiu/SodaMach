using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class SodaMachine
    {//	Coins: 20 quarters, 10 dimes, 20 nickels, 50 pennies
     //Cans(you pick how many of each the machine starts with) : 
        //Root Beer(60 cents per can), Cola(35 cents per can), and Orange(6 cents per can)

        //Member Variables (Has A)
        private List<Coin> _register; //_field is read only, locked// this list of coins is useful for the Fill Register method,
        // no need to create now list of coins when _register exists
        private List<Can> _inventory;//_field is read only
        public double balanceQuarter_register; //used to check coins in register?
        public double balanceDime_register;
        public double balanceNickel_register;
        public double balancePenny_register;
        public double hasOrangeSoda_inventory;
        public double hasRootBeer_inventory;
        public double hasCola_inventory;
        //Constructor (Spawner)
        public SodaMachine()
        {
            _register = new List<Coin>();
            _inventory = new List<Can>();
            Console.WriteLine("SodaMachine constructed here");
         
            
            Console.ReadLine();
            FillRegister();//void
            FillInventory();//void
            this.balanceQuarter_register = 0; //added, try check balance
            this.balanceDime_register = 0;
            this.balanceNickel_register = 0;
            this.balanceNickel_register = 0;
            //GetSodaFromInventory("Cola");//only for testing the method
            
        }

        //Member Methods (Can Do)
              
        public void FillRegister() //fill register with coin objects.
        {
            //Console.WriteLine("machine register fills here");
            //Console.ReadLine();
            //sodaMachineCoinsToAdd = new Coin();
            for (int i = 0; i < 20; i++)
            {
                //add a quarter: first create a quarter, then and that Q to the list; Q HAS A name "Q", also has a Public "Worth"
                //call the constructor, /has a parent class/ those two variables, name & worth
                Quarter registerQuarter = new Quarter(); //1. Create new Quarter, new variabloe
                _register.Add(registerQuarter);//2. to create method, 
                //start with the List (i.e., the object, then Add ("function"), 
                //then Parenthesis(), because this is a method, Method takes ():
                //to test,
                this.balanceQuarter_register += registerQuarter.Worth;
                if (i == 19)
                {
                    Console.WriteLine($"This is the amount, ${balanceQuarter_register}, of quarters in your register");
                    
                }
                
            }
            for (int i = 0; i < 10; i++)
            {
                Dime registerDime = new Dime(); //1. Create new Dime, new variabloe
                _register.Add(registerDime);
                this.balanceDime_register += registerDime.Worth;
                if (i == 9)
                {
                        Console.WriteLine($"This is the amount, ${balanceDime_register}, of dimes in your register");
                      
                  }
            }
            for (int i = 0; i < 20; i++)
            {
                Nickel registerNickel = new Nickel(); //1. Create new Dime, new variabloe
                _register.Add(registerNickel);
                this.balanceNickel_register += registerNickel.Worth;
                if (i == 19)
                {
                    Console.WriteLine($"This is the amount, ${balanceNickel_register}, of nickels in your register");
                    
                }
            }
            for (int i = 0; i < 50; i++)
            {
                Penny registerPenny = new Penny(); //1. Create new Dime, new variabloe
                _register.Add(registerPenny);
                this.balancePenny_register += registerPenny.Worth;
                if (i == 49)
                {
                    Console.WriteLine($"This is the amount, ${balancePenny_register}, of pennies in your register");
                    Console.ReadLine();
                }
            }
            Console.WriteLine("All coins now added to Register");
            Console.ReadLine();

        }
        
        public void FillInventory()//Cans(you pick how many of each the machine starts with) : 
        //Root Beer(60 cents per can), Cola(35 cents per can), and Orange(6 cents per can).
        {
            //Console.WriteLine("machine inventory fills here");
            //Console.ReadLine();
            for (int i = 0; i < 2; i++)
            {
                Cola inventoryCola = new Cola();
                _inventory.Add(inventoryCola);
                Console.WriteLine($"{ inventoryCola.Name} added to inventory");
            }
            for (int i = 0; i < 2; i++)
            {
                OrangeSoda inventoryOrangeSoda = new OrangeSoda();
                _inventory.Add(inventoryOrangeSoda);
                Console.WriteLine($"{inventoryOrangeSoda.Name} added to inventory");
            }
            for (int i = 0; i < 2; i++)
            {
                RootBeer inventoryRootBeer = new RootBeer();
                _inventory.Add(inventoryRootBeer);
                Console.WriteLine($"{inventoryRootBeer.Name} added to inventory");
            }
            Console.WriteLine("");
            Console.WriteLine("All cans now added to Inventory");
            Console.ReadLine();
        }
        
        public void BeginTransaction(Customer customer)//Start transaction. Takes customer passed to which ever method needs it.
        {
            bool willProceed = UserInterface.DisplayWelcomeInstructions(_inventory);
            if (willProceed)
            {
                Transaction(customer);
            }
        }
        
       
       
        //get payment from the user.
        //pass payment to the calculate transaction method to finish up the transaction based on the results.
        private void Transaction(Customer customer) //main transaction logic.  user will be prompted for the desired soda.
        {
            Console.WriteLine("Prompt for soda");
            Console.ReadLine();

        }
        
        private Can GetSodaFromInventory(string nameOfSoda)//Gets a soda from the inventory based on the name of the soda.
        {
            Can GetSodaFromInventory = new Cola();//ASK, Is this right? need to return a value to avoid an error message

            bool sodaFound = false;//going to raise flag if we find the can.  
            //Flag stays at False if we never find can  at the loop, 
            //check "if" true, return can, if false, display error message

            foreach (var can in _inventory)//check name of soda, at if found (true) returns soda, if not, proceeds to below "if"
                //this is the long way of searching, without using Linq.  I used Linq in the other mwthod to add coins to the wallet!
            {
                if (nameOfSoda == can.Name)
                {
                    sodaFound = true;
                    GetSodaFromInventory = can;
                    _inventory.Remove(GetSodaFromInventory);
                    break;
                }
                
            }
            if (sodaFound == false)//if not found, displays error, not found
            {
                UserInterface.DisplayError("no such soda in inventory");
            }
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
        //Takes in the worth of the amount of change needed.
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
            List<Coin> ReturnList = new List<Coin>();
            return ReturnList;
        }
        //Reusable method to check if the register has a coin of that name.
        //If it does have one, return true.  Else, false.
        private bool RegisterHasCoin(string name)
        {
            return true;
        }
        //Reusable method to return a coin from the register.
        //Returns null if no coin can be found of that name.
        //private Coin GetCoinFromRegister(string name)
        //{
        //   // Coin returnCoin = new Coin();
        //    //return returnCoin;
        //}
        //Takes in the total payment amount and the price of can to return the change amount.
       // private double DetermineChange(double totalPayment, double canPrice)
        //{
        //    return 6;///place holder next two lines
        //}
        //Takes in a list of coins to return the total worth of the coins as a double.
        //private double TotalCoinValue(List<Coin> payment)
        //{
        //    return 6;///place holder next two lines
        //}
        //Puts a list of coins into the soda machines register.
        //private void DepositCoinsIntoRegister(List<Coin> coins)
        //{
           
        //}
    }
}
