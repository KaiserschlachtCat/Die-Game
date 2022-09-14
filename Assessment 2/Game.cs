using System;
using System.Collections.Generic;

namespace Assessment_2
{
    interface IGame
    {
        void Welcome();
        void Rules();
        void GameQuit();

    }
    internal class Game : IGame
    {
        public void Rules()
        {
            Console.WriteLine("###############" +
                              "\n - Rules - \n" +
                              "###############");
            Console.WriteLine("- Players take turns rolling all five dice and scoring for three-of-a-kind or better.\n" +
                              "- If a player only has two-of-a-kind, they may re-throw the remaining dice in an attempt to improve the matching dice values.\n" +
                              "- If no matching numbers are rolled, a player scores 0.");
        }
        public void Welcome()
        {
            Console.WriteLine("Welcome to 'Three Or More Dice' game!");
            string play = ""; // For the readline
            play.ToLower(); // Makes it low, no erros here!

            Console.WriteLine("To Play press 'Q'. Any of Letter(s) to quit. ");
            play = Console.ReadLine();

            if (play != "q")
            {
                System.Environment.Exit(0); // Quits the application
            }
        }

        public void GameQuit()
        {
            Console.WriteLine("To Quit the Game type 'Q'");
            string gameQuit = Console.ReadLine();
            gameQuit.ToLower();
            if (gameQuit == "q")
            {
                System.Environment.Exit(0); // Quits the application
            }
        }

        int one = 0; int two = 0; int three = 0; // 1, 2, 3 counters
        int four = 0; int five = 0; int six = 0; // 4, 5, 6 counters
        int twoOfKind = 0; int threeOfKind = 0; int fourOfKind = 0; int fiveOfKind = 0; // for the game stats return;
        int total = 0; // Total die roll
        int[] stats = new int[11]; // Makes array to store vars
        public int CalcScore(List<int> Rolls)
        {
            int Score = 0; // The score it will add

            int[] RollsArray = Rolls.ToArray(); // turns the Rolls List into an array
            int len = RollsArray.Length - 1; // len gets the length of the array

            Rolls.Clear(); // Clears the old array to make room for the other player lists to come through. Doesn't make arrayLength = infinite amounts!

            one = 0; two = 0; three = 0; four = 0; five = 0; six = 0; // Make sure they're restarted - I don't trust it

            for (int i = 0; i < len; i++) // for length in array
            {
                if (RollsArray[i] == 1) { one++; }
                if (RollsArray[i] == 2) { two++; }
                if (RollsArray[i] == 3) { three++; }
                if (RollsArray[i] == 4) { four++; }
                if (RollsArray[i] == 5) { five++; }
                if (RollsArray[i] == 6) { six++; }
            }

            ////////////////////////////////////////////
            /////////////// DEBUGGING //////////////////
            ////////////////////////////////////////////
            //Console.WriteLine("Array Length: " + len);
            //Console.WriteLine("=======\nOne: " + one);
            //Console.WriteLine("Two: " + two);
            //Console.WriteLine("Three: " + three);
            //Console.WriteLine("Four: " + four);
            //Console.WriteLine("Five: " + five);
            //Console.WriteLine("Six: " + six);
            ////////////////////////////////////////////

            if (one == 3 || two == 3 || three == 3 || four == 3 || five == 3 || six == 3) { Console.WriteLine("==================\nScored 3 Points.", Score = 3, threeOfKind += 1); } // 3 points
            else if (one == 4 || two == 4 || three == 4 || four == 4 || five == 4 || six == 4) { Console.WriteLine("==================\nScored 6 Points.", Score = 6, fourOfKind += 1); } // 6 points
            else if (one == 5 || two == 5 || three == 5 || four == 5 || five == 5 || six == 5) { Console.WriteLine("==================\nScored 12 Points.", Score = 12, fiveOfKind += 1); } // 12 points
            else if (one == 2 || two == 2 || three == 2 || four == 2 || five == 2 || six == 2) { Console.WriteLine("==================\nTwo-Of-Kind: Scored 0 Points.", Score = 0, twoOfKind += 1); } // Two-of-Kind
            else { Console.WriteLine("==================\nScored 0 Points"); } // no points

            // Adds them to a list. 
            stats[0] += one;
            stats[1] += two;
            stats[2] += three;
            stats[3] += four;
            stats[4] += five;
            stats[5] += six;

            stats[6] = twoOfKind; 
            stats[7] = threeOfKind; 
            stats[8] = fourOfKind;
            stats[9] = fiveOfKind;

            stats[10] += one + two + three + four + five + six;

            return Score;
        }
        public int[] ReturnRollStats()
        {
            return stats;
        }
    }
}
    

