using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectONE
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wellcome to my memory GAME: ");
            MemoryGame();
        }

        private static void MemoryGame()
        {
            int matrix1 = 0;
            do
            {
                Console.Write("Please enter the array sizes: ");
                matrix1 = Convert.ToInt32(Console.ReadLine());
            } while (matrix1 <= 0 || matrix1 % 2 != 0 || matrix1 > 8);

            Console.WriteLine();
            Console.WriteLine($"This is your size: ({matrix1},{matrix1})");
            int[,] matrix = new int[matrix1, matrix1];

            int zugot = (matrix1 * matrix1) / 2;
            Random rnd = new Random();
            for (int i = 1; i <= zugot; i++)
            {
                // card1 - 1 random place
                int randomRow;
                int randomCol;
                do
                {
                    randomRow = rnd.Next(0, matrix1);
                    randomCol = rnd.Next(0, matrix1);
                }
                while (matrix[randomRow, randomCol] != 0);
                matrix[randomRow, randomCol] = i;

                // card2 - 1 random place
                do
                {
                    randomRow = rnd.Next(0, matrix1);
                    randomCol = rnd.Next(0, matrix1);
                }
                while (matrix[randomRow, randomCol] != 0);
                matrix[randomRow, randomCol] = i;
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($" { (matrix[i, j] > 0 ? "X" : "0") } ");
                }
                Console.WriteLine();
            }

            // Player ONE Card
            int playerNumberROW, playerNumberCOL;
            do
            {
                Console.Write("Please write a row number (zero based): ");
                playerNumberCOL = Convert.ToInt32(Console.ReadLine());

                Console.Write("Please write a column number (zero based): ");
                playerNumberROW = Convert.ToInt32(Console.ReadLine());

            } while ((playerNumberCOL < 0) && (playerNumberROW < 0)
                    && (playerNumberCOL >= matrix.GetLength(0))
                    && (playerNumberROW >= matrix.GetLength(1)));
            Console.WriteLine($"The card you pick-up is: {matrix[playerNumberROW, playerNumberCOL]}");
            Console.WriteLine();

            int playerNumberROW2, playerNumberCOL2;
            int card1 = matrix[playerNumberROW, playerNumberCOL];
            int playerPoints = 0;

            do // Player SECOND Card
            {
                Console.Write("Please write a row number (zero based): ");
                playerNumberCOL2 = Convert.ToInt32(Console.ReadLine());

                Console.Write("Please write a column number (zero based): ");
                playerNumberROW2 = Convert.ToInt32(Console.ReadLine());
            }
            while((playerNumberCOL < 0) && (playerNumberROW < 0)
                    && (playerNumberCOL >= matrix.GetLength(0))
                    && (playerNumberROW >= matrix.GetLength(1))
                    || matrix[playerNumberROW2, playerNumberCOL2] == 0
                    || playerNumberCOL2 == playerNumberCOL
                    && playerNumberROW2 == playerNumberROW);

            Console.WriteLine($"The second card you pick-up is: {matrix[playerNumberROW2, playerNumberCOL2]}");
            Console.WriteLine();
            Console.WriteLine($"Player - Row & Column numbers: ({playerNumberROW}, {playerNumberCOL}) , ({playerNumberROW2}, {playerNumberCOL2})");
            int card2 = matrix[playerNumberROW2, playerNumberCOL2];

            if (card1 == card2) //Player ONE
            {

                // remove 2 cards if match
                card1 = 0;
                card2 = 0;
                playerPoints++;

            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("This is the board now: ");
            }
            if (true)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        //Console.Write($" { (matrix[i, j] > 0 ? "X" : "0") } "); WITHOUT ETGAR
                        if (matrix[i, j] == 0)
                            Console.Write($" { matrix[i, j]}  ");
                        else if ((i == playerNumberROW) && (j == playerNumberCOL))
                            Console.Write($" { matrix[i, j]}  ");
                        else if ((i == playerNumberROW2) && (j == playerNumberCOL2))
                            Console.Write($" {matrix[i,j]}  ");
                        else
                            Console.Write($" X  ");
                    }
                    Console.WriteLine();
                }
            }
            Console.WriteLine($"You have now {playerPoints} Points.");

            // FOR ITAY:
            // I didn't do "do while" very good so the game can't go on after one time of guessing..
            // I'll happy if you can show me in class what i need to write
            // THANK YOU ! ☺
        }
    }
}
