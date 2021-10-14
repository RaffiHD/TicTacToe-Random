using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_Random
{
    class Program
    {

        private static List<List<string>> fields = new List<List<string>>() { new List<string> { null, null, null }, new List<string> { null, null, null }, new List<string> { null, null, null } };

        private static bool hasWinner = false;

        private static int mover = 1;

        private static int amountFieldsX = 3;
        private static int amountFieldsY = 3;

        static void Main(string[] args)
        {

            Console.WriteLine("TicTacToe Random");

            start();

            if (hasWinner == false)
            {
                printResult("No winner.");

            }
            else
            {
                printResult("Winner: " + mover.ToString());
            }

            reset();

            Console.ReadLine();

        }

        static void reset()
        {

        }

        static void printResult(string resultText)
        {
            /*
             * if (new[] { fields[0][0], fields[1][0], fields[2][0] }.All(x => x == mover.ToString())
                || new[] { fields[0][1], fields[1][1], fields[2][1] }.All(x => x == mover.ToString())
                || new[] { fields[0][1], fields[1][2], fields[2][2] }.All(x => x == mover.ToString())
                || new[] { fields[0][0], fields[0][1], fields[0][1] }.All(x => x == mover.ToString())
                || new[] { fields[1][0], fields[1][1], fields[1][2] }.All(x => x == mover.ToString())
                || new[] { fields[2][0], fields[2][1], fields[2][2] }.All(x => x == mover.ToString())
                || new[] { fields[0][0], fields[1][1], fields[2][2] }.All(x => x == mover.ToString())
                || new[] { fields[0][1], fields[1][1], fields[2][0] }.All(x => x == mover.ToString())
             */

            Console.WriteLine(" _  _  _ " + Environment.NewLine +
                              "|" + fields[0][0] + "|" + fields[1][0] + "|" + fields[2][0] + "|" + Environment.NewLine +
                              "|" + fields[1][0] + "|" + fields[1][1] + "|" + fields[1][0] + "|" + Environment.NewLine +
                              "|" + fields[2][0] + "|" + fields[2][1] + "|" + fields[2][2] + "|" + Environment.NewLine +
                              " _  _  _ " + Environment.NewLine
                              );

            Console.WriteLine();
            Console.WriteLine(resultText);
        }

        static void start()
        {


            int moves = 0;
            int movesMax = 9;

            mover = generateStarter();

            while (moves < movesMax && hasWinner == false) //
            {

                int[] currentField = randomField();

                int currentFieldX = currentField[0];
                int currentFieldY = currentField[1];

                while (fields[currentFieldX][currentFieldY] != null)
                {

                    currentFieldX = currentField[0];
                    currentFieldY = currentField[1];


                }

                fields[currentFieldX][currentFieldY] = mover.ToString();

                hasWinner = checkWin(fields, mover);
                moves++;

                if (mover == 0)
                {
                    mover = 1;
                }
                else
                {
                    mover = 0;
                }


            }


        }

        static bool checkWin(List<List<string>> fields, int mover)
        {
            if (new[] { fields[0][0], fields[1][0], fields[2][0] }.All(x => x == mover.ToString())
                || new[] { fields[0][1], fields[1][1], fields[2][1] }.All(x => x == mover.ToString())
                || new[] { fields[0][1], fields[1][2], fields[2][2] }.All(x => x == mover.ToString())
                || new[] { fields[0][0], fields[0][1], fields[0][1] }.All(x => x == mover.ToString())
                || new[] { fields[1][0], fields[1][1], fields[1][2] }.All(x => x == mover.ToString())
                || new[] { fields[2][0], fields[2][1], fields[2][2] }.All(x => x == mover.ToString())
                || new[] { fields[0][0], fields[1][1], fields[2][2] }.All(x => x == mover.ToString())
                || new[] { fields[0][1], fields[1][1], fields[2][0] }.All(x => x == mover.ToString())
                )
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        static int generateStarter()
        {

            Random rnd = new Random();

            if (rnd.Next(2) == 0)
            {
                return 0;
            }

            return 1;
        }

        static int[] randomField()
        {
            Random rnd = new Random();

            return new int[] { rnd.Next(0, amountFieldsX), rnd.Next(0, amountFieldsY) };

        }

    }
}
