using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class SodaMachine
    {  //Member Variables (Has A)
        private List<Coin> _register; //_field is read only, locked// this list of coins is useful for the Fill Register method
        private List<Can> _inventory;  //_inventory is read only

        public double balanceQuarter_register; //I use these next methods to check coins in the register
        public double balanceDime_register;
        public double balanceNickel_register;
        public double balancePenny_register;
        //public double hasOrangeSoda_inventory;
        //public double hasRootBeer_inventory;
        //public double hasCola_inventory;
        
        //Constructor (Spawner)
       
      
        public SodaMachine()
        {
            Console.WriteLine("SodaMachine construction begins here");
            Console.ReadLine();

            _register = new List<Coin>();
            _inventory = new List<Can>();

            List<Can> SodaOptions = new List<Can>();
            List<Coin> testPayment = new List<Coin>(); //Key to calling this method, need instances of objects to call the method within the class
            for (int i = 0; i < 1; i++)
            {
                
                
                Quarter testQuarter = new Quarter(); /// will create 3 Q's to create payment
                testPayment.Add(testQuarter);/// for loop includes a function to add q's to test payment for testing the functions below.  now test payment = 75cent
            }
            //for (int i = 0; i < 5; i++)
            //{
            //    Penny testPenny = new Penny(); //use this to test purchase of Orange
            //    testPayment.Add(testPenny); // run 6 cents
            //}

            double someNumber = 0.66677786777678;//rounding method
            someNumber = Math.Round(someNumber, 2);

            //Customer testCustomer = new Customer(); //Key to calling this method
            //Can testCan = new RootBeer();//Key cannot make an abstract can, must make an instance to test some of the logic.  Need an Orange can to test exact change logic
            Can testCan = new OrangeSoda();
            FillRegister();//void AND this is a good place to turn off the fill register function
            FillInventory();//void this is a GREAT PLACE to turn off inventory to check tranaction logic involving the insufficient inventory.
            //this.balanceQuarter_register = 0; //added, try check balance
            //this.balanceDime_register = 0;
            //this.balanceNickel_register = 0;
            //this.balanceNickel_register = 0;
            //BeginTransaction(testCustomer);
           //CalculateTransaction(testPayment, testCan , testCustomer);
            //GetSodaFromInventory("Cola");//only for testing the method
            //GetCoinFromRegister("Quarter");tests method
        }

        //Member Methods (Can Do)
              
        public void FillRegister() //fill register with coins.Fill register: Coins: 20 quarters, 10 dimes, 20 nickels, 50 pennies.
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
                    Console.WriteLine("");
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
                _inventory.Add(inventoryCola);//put these on watch list
                Console.WriteLine($"{ inventoryCola.Name} added to inventory");
            }
            for (int i = 0; i < 2; i++)
            {
                OrangeSoda inventoryOrangeSoda = new OrangeSoda();
                _inventory.Add(inventoryOrangeSoda); // put his on watch list
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
            while (willProceed)
            {
                Transaction(customer);
               willProceed = UserInterface.ContinuePrompt("Continue? press Y, else, press N");
            }
            
        }
        
        //get payment from the user.
        //pass payment to the calculate transaction method to finish up the transaction based on the results.
        private void Transaction(Customer customer) //main transaction logic.  user will be prompted for the desired soda.
        {
            Console.WriteLine("Press any Key to Enter transaction");
            Console.ReadLine();
            string selectedSodaName = UserInterface.SodaSelection(_inventory); //use string to capture value returned by cMETHOD #return method
            //_inventory.Find (soda => soda.Name == chosenSoda.Name)
            //UserInterface.DisplayCost(_inventory.Find(soda => soda.Name == selectedSodaName)); //need local variable for Linq
            Can selectedSoda = _inventory.Find(soda => soda.Name == selectedSodaName);
            List<Coin> customerPayment = customer.GatherCoinsFromWallet(selectedSoda);               //new List<Coin>();//hold payment
            customer.Wallet.CheckWalletBalance();
            DepositCoinsIntoRegister(customerPayment);
            //need to add payment to machine.
            //string selectedCoinName = UserInterface.CoinSelection((_inventory.Find(soda => soda.Name == selectedSodaName)), customer.Wallet.Coins);
            CalculateTransaction(customerPayment, selectedSoda, customer);

            UserInterface.EndProgram();//ends program
        }
        
        private Can GetSodaFromInventory(string nameOfSoda)//Gets a soda from the inventory based on the name of the soda.
        {
            Can GetSodaFromInventory = new Cola();//ASK, Is this right? need to return a value to avoid an error message

            bool sodaFound = false;//going to raise flag if we find the can.  
            //Flag stays at False if we never find can  at the loop, 
            //check "if" true, return can, if false, display error message

            foreach (var can in _inventory)//check name of soda, at if found (true) returns soda, if not, proceeds to below "if"
                //this is the long way of searching, without using Linq.  I used Linq in the other method to add coins to the wallet!
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
        ////result - dispense the chosen soda and give change to the customer
        ////If the payment is greater than the price of the soda, and if the sodamachine has enough change to return: Dispense soda, and change to the customer.
        ////If the payment is greater than the cost of the soda, but the machine does not have enough change: Return payment to the customer.
        ////If the payment is exact to the cost of the soda:  Dispense soda.
        ////If the payment does not meet the cost of the soda: return payment to the customer.
        //Takes in the worth of the amount of change needed.
        //Attempts to gather all the required coins from the sodamachine's register to make change.
        //Returns the list of coins as change to dispense.
        //If the change cannot be made, return null.
        private void CalculateTransaction(List<Coin> payment, Can chosenSoda, Customer customer)
        {
            ///// check the payment - if greater than price of soda AND the soda machine has enough change to return ******(check the register)

            //Takes in the total payment amount and the price of can to return the change amount.
            //_inventory.RemoveAll(can => can.Name == "Orange Soda"); //using Linq/// test case for Orange Soda only
            
            
            if (_inventory.Find (soda => soda.Name == chosenSoda.Name) == null) //test against inventory;  Coin returnCoin = Wallet.Coins.Find(coin => coin.Name == coinName);
            {
                Console.WriteLine("inventory not sufficient");
                customer.AddCoinsIntoWallet(payment);
            }
            else if (TotalCoinValue(payment) > chosenSoda.Price && TotalCoinValue(_register) > DetermineChange(TotalCoinValue(payment), chosenSoda.Price))//disable/able breakpoint here.  add TCV(Payment) to the watchlist
            {
                Console.WriteLine("dispense Soda + return Change + place soda in backpack");
                //dispensing soda  //placing soda in backpack
                customer.AddCanToBackpack(GetSodaFromInventory(chosenSoda.Name));
                //returning change
                List<Coin> change = GatherChange(DetermineChange(TotalCoinValue(payment), chosenSoda.Price));
                //Give change to customer
                customer.AddCoinsIntoWallet(change);
                customer.Wallet.CheckWalletBalance();
            }
            else if (TotalCoinValue(payment) > chosenSoda.Price && TotalCoinValue(_register) < DetermineChange(TotalCoinValue(payment), chosenSoda.Price)) //simple test: turn off the register
            {
                UserInterface.DisplayError("Not enough money to dispense Change.  Customer: Do not Damage Machine. Return payment to Customer");
               //Console.WriteLine("");
            }
            else if (TotalCoinValue(payment) == chosenSoda.Price) //make both sides of equation a double when an operand error tells me they are not able to be compared; test this with exact payment
            {
                Console.WriteLine("dispense soda, exact payment(see adjusted price for orange soda!) + place soda in backpack"); //had to switch the orange soda value to accommodate cost = payment test case 
            }
            
            else if (TotalCoinValue(payment) < chosenSoda.Price) //test with smaller payment than the chosen soda.  Test switch as 6 pennies for payment, check the watch list// never hits this test case because decimal point on double makes payment +
            {
                Console.WriteLine("Not enough payment: return payment to Customer");
            }
        }

        private List<Coin> GatherChange(double changeValue)
        {
           //uses same Greedy Algorithm
            List<Coin> ReturnList = new List<Coin>();//Greedy Algorithm to select from list of coins
            double remainingValue = changeValue; // Greedy Algorithm subtracts from this in while loop
            while (remainingValue > 0)
            {
                if (remainingValue >= .25)// remaining value diminishes by worth of coins in loop, then terminate at value of zero that remains
                {
                    remainingValue = remainingValue - .25;
                    ReturnList.Add(new Quarter());
                }
                else if (remainingValue >= .10)
                {
                    remainingValue = remainingValue - .10;
                    ReturnList.Add(new Dime());
                }
                else if (remainingValue >= .05)
                {
                    remainingValue = remainingValue - .05;
                    ReturnList.Add(new Nickel());
                }
                else// could use a condition like the Q,N,D above, or just use the else
                {
                    remainingValue = remainingValue - .01;
                    ReturnList.Add(new Penny());
                }
                
            }
             return ReturnList;//gives final result, leave this here, all the work done to return the list           
        }

        private bool RegisterHasCoin(string name)
        {
            //Can GetSodaFromInventory = new Cola();//ASK, Is this right? need to return a value to avoid an error message

            bool coinFound = false;//going to raise flag if we find the coin.  
            //Flag stays at False if we never find coin at the loop, 
            //check "if" true, return true; if false, display error message

            foreach (var coin in _register)//this is the long way of searching, without using Linq. Used Linq in the other method to add coins to the wallet
            {
                if (name == coin.Name)
                {
                    coinFound = true;
                    break;
                }
            }
            if (coinFound == false)//if not found, displays error, not found
            {
                UserInterface.DisplayError("no such coin in inventory");
            }
            return coinFound;
        }
        //Reusable method to return a coin from the register.
        //Returns null if no coin can be found of that name.
        private Coin GetCoinFromRegister(string name)
        {
            Coin returnCoin = _register.Find(coin => coin.Name == name);
          _register.Remove(returnCoin);
            return returnCoin;//could put this in watch & see reduction in count
        }
        //Takes in the total payment amount and the price of can to return the change amount.
        private double DetermineChange(double totalPayment, double canPrice)//gotta assume at this point that customer always adds enough.  Maybe interface has a prompt? chack later
        { 
            double changeCalculated;
            changeCalculated = totalPayment - canPrice;
            return changeCalculated;///place holder next two lines
        }
        //Takes in a list of coins to return the total worth of the coins as a double. GOOD FOR USE ABOVE in the transaction
        private double TotalCoinValue(List<Coin> payment)//payment is the price of the can, and a loop will add worth of coint to worth of coin, 
            //FOR EACH LOOP good here FOR EACH COIN in payment, add to total until goal achieved
            //until that paymentvalue/worth equals or is greater than cost of the soda.
        {
            double totalWorth = 0;
            foreach (var coin in payment)
            {
                totalWorth += coin.Worth; //+= function rather than complete addition statement; 
                //gonna have a list of things, going thru the list, adding the value of each item until list is complete
            }

            return totalWorth;///place holder next two lines
        }
        //Puts a list of coins into the soda machines register.
        private void DepositCoinsIntoRegister(List<Coin> coins)
        {
            //_register = List<>Coins. Add specific coins from the customer into the existing list of coin held in the SM regiaster.
            //Not adding the worth of the coins, instead adding to the LIST of coins
            foreach (var coinFromCustomer in coins)//want to add it to the register
            {
                _register.Add(coinFromCustomer);
                Console.WriteLine($"Customer payment coin {coinFromCustomer.Name} deposited here");
                Console.ReadLine();

            }
        }
    }
}
