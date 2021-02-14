using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Customer
    {
        //Member Variables (Has A)
        public Wallet Wallet;
        public Backpack Backpack;
        
        
        //Constructor (Spawner)
        public Customer()
        {
           Wallet = new Wallet();// Has
           Backpack = new Backpack();//Has
            Console.WriteLine("Customer has wallet & backpack");
            // AddCanToBackpack(new Cola()); checks the backpack for inclusion of cola object, use/ add to watch, check "this"
            //AddCoinsIntoWallet(List<Coin> coinsToAdd), create list of coins, add coins to the list, use the add to watch, then use breakpoints
            Console.ReadLine();
        }
        //Member Methods (Can Do)
        //public void CheckStep()
        //{
        //    Console.WriteLine("Check Step, method placed here");
        //    Console.ReadLine();
        //}
       
        //Takes in the selected can for price reference
        //Will need to get user input for coins they would like to add.
        //WThis method will return a list of coin objects that the customer will use a payment for their soda.
        public List<Coin> GatherCoinsFromWallet(Can selectedCan)
        {
            List<Coin> ReturnList = new List<Coin>();//Greedy Algorithm to select lost of coins
            double remainingValue = selectedCan.Price; // greedy Algorithm subtracts from this in while loop
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
                //else 
                //{
                //    break;//will stop
                //}

            }

            return ReturnList;//gives final result, leave this here, all the work done to return the list
            //////////Console.WriteLine("This method will be the main logic for a customer to retrieve coins from their wallet.");
            //////////Console.ReadLine();
        }
        
        //Returns a coin object from the wallet based on the name passed into it.
        //Returns null if no coin can be found
        public Coin GetCoinFromWallet(string coinName)
        {
            Coin returnCoin = Wallet.Coins.Find(coin => coin.Name == coinName);
            Wallet.Coins.Remove(returnCoin);
           
            return returnCoin;///can check this reduce by one with the "watch" method.  
            // using Linq here, so uncomment... this is advanced find the first coin such that coin.name = coinName
        }//this is one way to search, but there is antoher, contained in the inventory searchg for soda in the SodaMachine Class
        //Takes in a list of coin objects to add into the customers wallet.
        public void AddCoinsIntoWallet(List<Coin> coinsToAdd)
        {
            
            foreach (var coin in coinsToAdd)
            {
                Wallet.Coins.Add(coin);
            }
        }
        //Takes in a can object to add to the customers backpack.
        public void AddCanToBackpack(Can purchasedCan)
        {
            //CheckStep();
            Backpack.cans.Add(purchasedCan); //Backpack, variable, can<List of>, Add function Purchased can accepted in parenthesis

        }
    }
}
