using System;
using System.Collections.Generic;

namespace TickTackToe
{
    class Game
    {
        static void Main(string[] args)
        {
            Messenger m = new Messenger();
            Board board = new Board();
            PlayerIO pIO = new PlayerIO(m, board);
            int currentRound = 1;
            int currentPlayer = 1;
            bool isGameOver = false;
            bool actionSuccess;

            while (!isGameOver)
            {
                Console.Clear();
                Colorize.WriteLine(ConsoleColor.Green, "  TickTackToe!\n");
                GameRenderer.DrawStats(currentRound, currentPlayer);
                GameRenderer.DrawBoard(board);
                if (m.message.txt != "")
                {
                    GameRenderer.DrawMessage(m.message);
                }
                actionSuccess = pIO.execInput(pIO.prompt(), currentPlayer);
                if (actionSuccess)
                {
                    currentRound++;
                    currentPlayer = currentPlayer == 0 ? 1 : 0;
                }
            }

            Console.ReadKey();
        }
    }

    

    class GameRenderer
    {
        public static void DrawBoard(Board board)
        {
            string[,] bValues = board.boxes;

            for (int i = -1; i < board.Rows; i++)
            {
                for (int j = -1; j < board.Cols; j++)
                {
                    if (i < 0)
                    {
                        if (j < 0)
                        {
                            Console.Write($" {Tools.getBoardRow(i)} ");
                        }
                        else
                        {
                            Colorize.Write(ConsoleColor.Yellow, $" {j + 1} ");
                        }
                    }
                    else
                    {
                        if (j < 0)
                        {
                            Colorize.Write(ConsoleColor.Yellow, $" {Tools.getBoardRow(i)} ");
                        }
                        else
                        {
                            Console.Write(bValues[i, j]);
                        }
                    }
                }
                Console.Write("\n");
            }
        }
        public static void DrawStats(int currentRound, int currentPlayer)
        {
            char playing = currentPlayer == 0 ? 'x' : 'o';
            Colorize.WriteLine(ConsoleColor.Magenta, $"Round:{currentRound} - Playing:'{playing}'");
        }
        public static void DrawMessage(Message message)
        {
            ConsoleColor color = ConsoleColor.White;
            switch (message.type)
            {
                case 'e':
                    color = ConsoleColor.Red;
                    break;
                case 'd':
                    color = ConsoleColor.Green;
                    break;
                default:
                    break;
            }
            Colorize.WriteLine(color, $"{message.type}: {message.txt}");
        }
        
    }

    class Colorize
    {
        public static void WriteLine(ConsoleColor color, string str)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(str);
            Console.ResetColor();
        }
        public static void WriteLine(ConsoleColor[] colors, string[] strs)
        {
            foreach (ConsoleColor color in colors)
                foreach (string str in strs)
                {
                    Console.ForegroundColor = color;
                    Console.WriteLine(str);
                    Console.ResetColor();
                }
        }
        public static void Write(ConsoleColor color, string str)
        {
            Console.ForegroundColor = color;
            Console.Write(str);
            Console.ResetColor();
        }
        public static void Write(ConsoleColor[] colors, string[] strs)
        {
            foreach(ConsoleColor color in colors)
                foreach(string str in strs)
                {
                    Console.ForegroundColor = color;
                    Console.Write(str);
                    Console.ResetColor();
                }
        }
    }
}
