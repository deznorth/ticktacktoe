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
            render(Board);
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

    class Box
    {
        private int[] _position;

        public Box(int[] position)
        {
            _position = position;
        }

        public Box(int x, int y)
        {
            _position = new int[] { x, y };
        }

        public int[] position
        {
            get => _position;
            set => _position = value;
        }

        public int x
        {
            get => _position[0];
            set => _position[0] = value;
        }

        public int y
        {
            get => _position[1];
            set => _position[1] = value;
        }
        

    }

    class Board
    {
        public string[,] boxes;
        public Dictionary<string, Box> keyring;
        private int rows, cols;

        public Board(int rows = 3, int cols = 3)
        {
            string[,] newBoard = createBoard(rows, cols);
            Dictionary<string, Box> newIdentifier = createIdentifier(newBoard);
            
            this.rows = rows;
            this.cols = cols;
            this.boxes = newBoard;
            this.keyring = newIdentifier;
        }

        public int Rows
        {
            get => rows;
            set => rows = value;
        }

        public int Cols
        {
            get => cols;
            set => cols = value;
        }

        public char getBox(string key) //Get content inside the specified box
        {
            string content = boxes[keyring[key].x, keyring[key].y];
            return content.ToCharArray()[1];
        }

        private string[,] createBoard(int rows, int cols)
        {
            string[,] board = new string[rows,cols];

            for(int i = 0; i<rows; i++)
            {
                for(int j = 0; j<cols; j++)
                {
                    board[i, j] = "[ ]";
                }
            }

            return board;
        }

        private Dictionary<string, Box> createIdentifier(string[,] board)
        {
            Dictionary<string, Box> identifier = new Dictionary<string, Box>();

            for(int i = 0; i<board.GetLength(0); i++)
            {
                for(int j = 0; j<board.GetLength(1); j++)
                {
                    string key = Tools.getBoardRow(i) + (j + 1).ToString();
                    Box newBox = new Box(j, i);

                    identifier.Add(key, newBox);
                    //Console.WriteLine($"key:{key} - x:{identifier[key].x} - y:{identifier[key].y}");
                }
            }


            return identifier;
        }
    }

    class Tools
    {
        public static char getBoardRow(int num)
        {
            switch (num)
            {
                case -1:
                    return ' ';
                default:
                    return (char)(num + 97);
            }
        }

        public static int parseRowKey(char key)
        {
            return ((int)key-96);
        }
        
    }
}
