using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    static class UserInterface
    {
        //Intro message that asks user if they wish to make a purchase
        public static bool DisplayWelcomeInstructions(List<Can> sodaOptions)
        {
            OutputText("\nWelcome to the soda machine.  We only take coins as payment \n");
            OutputText("At a glance, these are the drink options:\n");
            PrintOptions(sodaOptions);
            bool willProceed = ContinuePrompt("\nWould you like to make a purchase? (y/n)");
            if (willProceed == true)
            {
                Console.Clear();
                return true;
            }
            else
            {
                OutputText("Please step aside to allow another customer to make a selection");
                return false;
            }
        
        }
        //For printing out an error message for user to see.  Has built in console clear
        public static void DisplayError(string error)
        {
            Console.WriteLine(error);
            Console.ReadLine();
            Console.Clear();
        }
        //Method for getting user input for the selected coin.
        //Uses a tuple to help group valadation boolean and normalized selection name.
        public static string CoinSelection(Can selectedCan, List<Coin> paymnet)
        {
            Tuple<bool, string> validatedSelection;
            do
            {
                DisplayCost(selectedCan);
                DiplayTotalValueOfCoins(paymnet);
                Console.WriteLine("\n");
                Console.WriteLine("Enter -1- for Quarter");
                Console.WriteLine("Enter -2- for Dime");
                Console.WriteLine("Enter -3- for Nickel");
                Console.WriteLine("Enter -4- for Penny");
                Console.WriteLine("Enter -5- when finishd to deposit payment");
                int.TryParse(Console.ReadLine(), out int selection);
                validatedSelection = ValidateCoinChoice(selection);
               
            }
            while (!validatedSelection.Item1);

            return validatedSelection.Item2;

        }
        //For validating the selected coin choice. Returns a tuple with a bool for if its a valid input and the normalized name of the coin
        private static Tuple<bool, string> ValidateCoinChoice(int input)
        {
            switch (input)
            {
                case 1:
                    Console.Clear();
                    return Tuple.Create(true, "Quarter");
                case 2:
                    Console.Clear();
                    return Tuple.Create(true, "Dime");
                case 3:
                    Console.Clear();
                    return Tuple.Create(true, "Nickel");
                case 4:
                    Console.Clear();
                    return Tuple.Create(true, "Penny");
                case 5:
                    Console.Clear();
                    return Tuple.Create(true, "Done");
                default:
                    DisplayError("Not a valid selection\n\nPress enter to continue");
                    return Tuple.Create(false, "Null");
            }
        }
        //Takes in a list of sodas and returns only unqiue sodas from it.
        private static List<Can> GetUniqueCans(List<Can> SodaOptions)
        {
            List<Can> UniqueCans = new List<Can>();
            List<string> previousNames = new List<string>();
            foreach (Can can in SodaOptions)
            {
                if (previousNames.Contains(can.Name))
                {
                    continue;
                }
                else
                {
                    UniqueCans.Add(can);
                    previousNames.Add(can.Name);
                }
            }
            return UniqueCans;

        }
        //Takes in a list of sodas to print.
        public static void PrintOptions(List<Can> SodaOptions)
        {

           List<Can> uniqueCans = GetUniqueCans(SodaOptions);
           foreach(Can can in uniqueCans)
           {
                Console.WriteLine($"\t{can.Name}");
           }
        }
        //Takes in the inventory of sodas to provide the user with an interface for their selection.
        public static string SodaSelection(List<Can> SodaOptions)
        {
            Tuple<bool, string> validatedSodaSelection;
            List<Can> uniqueCans = GetUniqueCans(SodaOptions);
            int selection;
            do
            {
                Console.WriteLine("\nPlease choose from the following.");
                for (int i = 0; i < uniqueCans.Count; i++)
                {
                    Console.WriteLine($"\n\tEnter -{i + 1}- for {uniqueCans[i].Name} : ${uniqueCans[i].Price}");
                }
                int.TryParse(Console.ReadLine(), out selection);
                validatedSodaSelection = ValidateSodaSelection(selection, uniqueCans);
            } while (!validatedSodaSelection.Item1);

            return validatedSodaSelection.Item2;
           
        }
        //Uses a tuple to validate the soda selection.
        private static Tuple<bool,string> ValidateSodaSelection(int input, List<Can> uniqueCans)
        {
            if(input >= 0 && input <= uniqueCans.Count)
            {
                return Tuple.Create(true, uniqueCans[input-1].Name);
            }
            else
            {
                DisplayError("Not a valid selection\n\nPress enter to continue");
                return Tuple.Create(false, "Null");
            }
        }
        //Takes in a string to output to the console.
        public static void OutputText(string output)
        {
            Console.WriteLine(output);
        }
        //Used for any user prompts that use a yes or now format.
        public static bool ContinuePrompt(string output)
        {
            Console.WriteLine(output);
            string input = Console.ReadLine().ToLower();
            switch (input)
            {
                case "y":
                case "yes":
                    return true;
                case "n":
                case "no":
                    return false;
                default:
                    OutputText("Invalid input");
                    return ContinuePrompt(output);
            }
        }
        //Displays the cost of a can.
        public static void DisplayCost(Can selectedSoda)
        {
            Console.Clear();
            Console.WriteLine($"\nYou have selected {selectedSoda.Name}.  This option will cost {selectedSoda.Price} \n");
        }
        //Displays the total value of a list of coins.
        public static void DiplayTotalValueOfCoins(List<Coin> coinsToTotal)
        {
            double totalValue = 0;
            foreach(Coin coin in coinsToTotal)
            {
                totalValue += coin.Value;
            }
            Console.WriteLine($"You currently have ${totalValue} in hand");
        }
        //Used for any error messages.  Has a built in read line for readablity and console clear after.
        public static void EndMessage(string sodaName, double changeAmount)
        {
            Console.WriteLine($"Enjoy your {sodaName}.");
            if(changeAmount > 0)
            {
                Console.WriteLine($"Despensing ${changeAmount}");
            }
            Console.ReadLine();
        }
    }
}
