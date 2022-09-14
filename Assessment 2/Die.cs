using System;
using System.Collections.Generic;

namespace Assessment_2
{
    interface IDie
    {
        void Dice();
    }
    internal class Die : IDie
    {
        int roll = 0; // The number the player will roll

        List<int> RollList = new List<int>();

        int[] ReRollArray; // For conv later

        Random random = new Random(); // Generate random number

        int i = 0; // For size
        public void Dice()
        {
            Console.WriteLine("{0} turns to roll dice.\nPress any Key to roll Dice.", i);
            try
            {
                i = 0;

                for (i = 0; i < 5; i++) // They can roll 5 times
                {
                    Console.ReadKey();

                    roll = random.Next(1, 7); // Players oll

                    RollList.Add(roll); // Adds number to list

                    if (i == 2)
                    {
                        ReRollArray = RollList.ToArray();

                        int first = ReRollArray[0];
                        int second = ReRollArray[1];

                        if (first == second)
                        {
                            ReRollDice();
                        }
                    }

                    Console.WriteLine("Rolled: {0}", roll);
                    Console.WriteLine("-----------");
                }
            }
            catch (ArgumentOutOfRangeException e) // If i goes outside the bounds of what it should do
            {
                Console.WriteLine($"Error with Arguement: {i} is out of range: {e}");
            }
            catch (IndexOutOfRangeException e) // Just in case it goes out of range
            {
                Console.WriteLine($"Error with index: {i}. This is out of range : {e}");
            }
            finally
            {
                RollList.Add(roll); // If allowed then just add it in.
            }
        }
       
        private void ReRollDice()
        {
            Console.WriteLine("You have rolled a Two-Of-Kind.");
            Console.WriteLine("Would you like to Re-Roll the remaining die? (Y) or (N)");
            string reRoll = Console.ReadLine();
            reRoll.ToLower(); // Makes ReRoll lower so you can write CAPS and it still recognises

            try
            {
                // If ReRoll is Y / N then it will choose what re roll
                if (reRoll == "y") { i = 2; } // Sets the the i to be 2 only 3 rolls after
                if (reRoll == "n") { i = 5; } // Should hopefully reset the loop?
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("Error with index: {0}. This is out of range : {1}", i, e); // for n. I don't trust n
            }
            finally
            {
                if (reRoll == "n") { i = 5; } //{Array.Clear(ReRollArray, 0, 0); } // Resets the loop allowing for player 1/2 to have their turn.
            }
          
        }
        ////////////////////
        // Returing value //
        ///////////////////
        public List<int> ReturnDice()
        {
            return RollList;
        }
    }
}
