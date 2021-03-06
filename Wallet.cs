﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Wallet
    {
        //Member Variables (Has A)
        //public string walletName;
        public double totalBalanceCoins;//used to test wallet
        public List<Coin> Coins = new List<Coin>(); //constructs a list
                
        
        Coin penny = new Penny();
        Coin nickel = new Nickel();
        Coin dime = new Dime();
        Coin quarter = new Quarter();
        

        //Constructor (Spawner)
        public Wallet()
        {
            this.totalBalanceCoins = 0;//added, checks balance in wallet with console write line after coins fill

            //Console.WriteLine("The Customer starts building the Wallet here");
            //Console.ReadLine();

            FillWallet();//void method

        }
        //Member Methods (Can Do)
        
        private void AddCoinToWallet(Coin coin) //method to add coin
        {
            this.Coins.Add(coin);
            this.totalBalanceCoins += coin.Worth;//excellent method to watch wallet fill
            this.totalBalanceCoins = Math.Round(totalBalanceCoins, 2);
        }

        public void CheckWalletBalance() //displays total worth in decimals
        {
            Console.WriteLine($"The Customer wallet has a current coin balance of ${totalBalanceCoins}");
            Console.ReadLine();
        }

        private void FillWallet()// loops for coins//Fills wallet with starting money
        {
            //CheckWalletBalance();
            //Console.WriteLine("");
            //Console.WriteLine("The Customer then fills the wallet with coins ");
            //Console.ReadLine();

            for (int i = 0; i < 12; i++)//adds twelve quarters = $3.  
            {
                Quarter quarterIn_Wallet = new Quarter();                
                AddCoinToWallet(quarterIn_Wallet);
               
            }
            for (int i = 0; i < 10; i++)
            {
                Dime dimeIn_Wallet = new Dime();// adds dimes
               AddCoinToWallet(dimeIn_Wallet);
            }
            for (int i = 0; i < 10; i++)//adds 50 cents in nickels
            {
                Nickel nickelInWallet = new Nickel();   //adds nickels             
                AddCoinToWallet(nickelInWallet);
            }
            for (int i = 0; i < 50; i++)
            {
                Penny pennyInWallet = new Penny();//adds fifty pennies
                AddCoinToWallet(pennyInWallet);
            }
            CheckWalletBalance(); //displays balance

        }
    }
}
