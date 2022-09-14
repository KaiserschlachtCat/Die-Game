using System;
using System.Collections.Generic;

namespace Assessment_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rounds = 5;
            int Score1 = 0;
            int Score2 = 0;

            List<int> dieRolls = new List<int>();

            Die die = new Die(); // Creates Die Class
            Game game = new Game(); // Creates Game Class

            Players players1 = new Players();
            Players players2 = new Players();

            game.Rules();
            Console.WriteLine("=======================");
            game.Welcome(); // START!

            while (rounds > 0) // Debugging for number of rounds
            {
                //while (Score1 <= 24 || Score2 <= 24) // This is the max number of points
                {
                    Console.WriteLine("\n====================" +
                                      $"\nRounds Left: {rounds}\n" +
                                      "====================");      

                    // Player 1
                    Console.WriteLine("##################\n" +
                                      "- Player 1 -\n" +
                                      "##################");

                    die.Dice();

                    dieRolls = die.ReturnDice(); // Gets values form the Die Class

                    Score1 += game.CalcScore(dieRolls); // Sends values to the Game Class

                    //Players players1 = new Players();

                    players1.ScoreReport(Score1);


                    // Player 2
                    Console.WriteLine("\n##################\n" +
                                      "- Player 2 -\n" +
                                      "##################");

                    die.Dice();
                    dieRolls = die.ReturnDice(); // Gets values form the Die Class

                    Score2 += game.CalcScore(dieRolls); // Sends values to the Game Class

                    //Players players2 = new Players();

                    players2.ScoreReport(Score2);

                    rounds--;
                }
            }
            
            Console.WriteLine("\n#########################################" +
                              "\n - The Rounds have been concluded. - \n" +
                              "#########################################\n");

            // Sending the stats to the statistics.  
            int finalPoints1 = players1.ReturnScore();
            int finalPoints2 = players2.ReturnScore();
            int[] stats;

            stats = game.ReturnRollStats();
            players1.Winner(finalPoints1, finalPoints2);
            players1.Winner(finalPoints1, finalPoints2, stats, "- Game Statistics -" );

            game.GameQuit();

            Console.ReadLine();
        }
    }
}
