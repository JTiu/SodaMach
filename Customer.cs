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
        

        //Can selectedCan;//test


        //Constructor (Spawner)

        public Customer()
        {
           Console.WriteLine("The Customer needs a 'Wallet' & a 'Backpack'");
            Console.WriteLine("");
             Wallet = new Wallet();// Has
             Backpack = new Backpack();//Has
             Console.WriteLine("Customer now has a wallet (with coins), & a backpack");
             Console.ReadLine();

            // AddCanToBackpack(new Cola()); checks the backpack for inclusion of cola object, use/ add to watch, check "this"
            //AddCoinsIntoWallet(List<Coin> coinsToAdd), create list of coins, add coins to the list, use the add to watch, then use breakpoints
            //AddCoinsIntoWallet(coinsToAdd);
            //GetCoinFromWallet();
            //GatherCoinsFromWallet();
            //AddCanToBackpack();
        }
        //Member Methods (CAN DO)

        //this is one way to search, but there is another, contained in the inventory search for soda in the SodaMachine Class
        //Takes in a list of coin objects to add into the customers wallet.
        public void AddCoinsIntoWallet(List<Coin> coinsToAdd)
        {

            foreach (var coin in coinsToAdd)
            {
                Wallet.Coins.Add(coin);
            }
            Console.WriteLine("Customer CAN DO: 1. Add coins to the wallet.");
            Console.ReadLine();
        }


        public Coin GetCoinFromWallet(string coinName)
        {
            Console.WriteLine("Customer CAN DO: 2. Get coins from the wallet.");
            Console.ReadLine();
            Coin returnCoin = Wallet.Coins.Find(coin => coin.Name == coinName);
            Wallet.Coins.Remove(returnCoin);
            return returnCoin;

            ///can check this reduce by one with the "watch" method.  
            // using Linq here, so uncomment... this is advanced find the first coin such that coin.name = coinName
        }

        public List<Coin> GatherCoinsFromWallet(Can selectedCan)
        {
            Console.WriteLine("Customer CAN DO: 3. Gather coins from the wallet.");
            Console.ReadLine();
            //////////////'Selected can' for price reference
           //////////////This method will return a list of coin objects that the customer will use a payment for their soda

            List<Coin> ReturnList = new List<Coin>();    //'Greedy Algorithm' to select list of coins
            double remainingValue = selectedCan.Price;   // Greedy Algorithm subtracts from this in while loop
            while (remainingValue > 0)
            {
                if (remainingValue >= .25)// remaining value diminishes by worth of coins in loop, then terminates at value of zero that remains
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
                else// Penny class could use a condition like the Q, N, D, above, or just use the 'else' as no other values remain
                {
                    remainingValue = remainingValue - .01;
                    ReturnList.Add(new Penny());
                }
                //else 
                //{//Returns a coin object from the wallet based on the name passed into it.
                //Returns null if no coin can be found
                //    break;//will stop any way
                //}

            }
            return ReturnList;     
          
        }        
        
        //Takes in a can object to add to the customers backpack.
        public void AddCanToBackpack(Can purchasedCan)
        {
            //CheckStep();
            Backpack.cans.Add(purchasedCan); //Backpack, variable, can<List of>, Add function Purchased can accepted in parenthesis
            Console.WriteLine("Customer CAN DO: 4. Add purchased soda to backpack.");
            Console.ReadLine();
        }
    }
}
