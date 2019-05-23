using System;
using System.Collections.Generic;

namespace TickTackToe
{
    class Game
    {
        static void Main(string[] args)
        {
            Board Board = new Board();
            int currentRound = 1;
            int currentPlayer = 1;
            bool isGameOver = false;

            Console.WriteLine("  TickTackToe!");

            while (!isGameOver)
            {
                Console.WriteLine($"\nRound: {currentRound}");
                render(Board);
                PlayerIO.execInput(PlayerIO.prompt(currentPlayer));
                currentRound++;
            }
            
            Console.ReadKey();
        }

        static void render(Board board)
        {
            string[,] bValues = board.boxes;
            
            for(int i = -1; i<board.Rows; i++)
            {
                for(int j = -1; j<board.Cols; j++)
                {
                    if (i < 0)
                    {
                        if (j < 0)
                        {
                            Console.Write($" {Tools.getBoardRow(i)} ");
                        }
                        else
                        {
                            Console.Write($" {j + 1} ");
                        }
                    }
                    else
                    {
                        if (j < 0)
                        {
                            Console.Write($" {Tools.getBoardRow(i)} ");
                        }
                        else
                        {
                            Console.Write(bValues[i,j]);
                        }
                    }
                }
                Console.Write("\n");
            }
        }
    }
}
