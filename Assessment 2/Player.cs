using System;
using System.IO;

namespace Assessment_2
{
    interface IPlayer
    {
        int ReturnScore();
    }
    public class Players : IPlayer
    {
        private int score = 0;
        public void ScoreReport(int Score)
        {
            score = Score;
            Console.WriteLine($"Total Points: {score}");
            Console.WriteLine("==================");
        }
        public int ReturnScore()
        {
            return score;
        }

        public void Winner(int score1, int score2)
        {
            Console.WriteLine("===============================================" +
                              $"\nPlayer 1 Points: {score1} | Player 2 Pounts: {score2}\n" +
                              "===============================================");
            if (score1 > score2)
            {
                Console.WriteLine("###########################" +
                                  "\nPlayer 1 is victorious!\n" +
                                  "###########################");
            }
            else if (score2 > score1)
            {
                Console.WriteLine("###########################" +
                                  "\nPlayer 2 is victorious!\n" +
                                  "###########################");
            }
            else
            {
                Console.WriteLine("###########################" +
                                  "\n      It is a draw!    \n" +
                                  "###########################");
            }
        }

        public void Winner(int score1, int score2, int[] stats, string title)
        {
            StreamWriter writer = new StreamWriter("Game Statistics"); // Writes a new file

            Console.WriteLine("Game Statistics file has been created. You will find it at: Assessment 2 / bin / Debug");
            writer.WriteLine($"- {title} - \n" +
                              "===============================================" +
                              $"\nPlayer 1 Points: {score1} | Player 2 Pounts: {score2}\n" +
                              "==============================================="); // Shows the players score

            writer.WriteLine("How many die were rolled in Session\n" +
                             "----------------------------------------------\n" +
                             $" - One's Rolled: {stats[0]}\n" +
                             $" - Two's Rolled: {stats[1]}\n" +
                             $" - Three's Rolled: {stats[2]}\n" +
                             $" - Four's Rolled: {stats[3]}\n" +
                             $" - Five's Rolled: {stats[4]}\n" +
                             $" - Six's Rolled: {stats[5]}\n" +
                             "----------------------------------------------\n" +
                             $" - Total Dice Rolled: {stats[10]}\n" +
                             "===============================================");

            writer.WriteLine("How many group numbers were rolled\n"+
                             "----------------------------------------------\n" +
                             $" - Two of Kinds: {stats[6]}\n" +
                             $" - Three of Kinds: {stats[7]}\n" +
                             $" - Four of Kinds: {stats[8]}\n" +
                             $" - Five of Kinds: {stats[9]}");
                             
            writer.Flush();
        }  
    }
}