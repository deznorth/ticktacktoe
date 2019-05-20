using System;
using System.Collections.Generic;

namespace TickTackToe
{
    class Game
    {
        static void Main(string[] args)
        {
            GameState state = new GameState();
            Board board = state.getBoard();
            Console.WriteLine("  TickTackToe!");
            render(board);
            Console.ReadKey();
        }

        static void render(Board board)
        {
            string[,] bValues = board.Values;

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

    class GameState //keeps track of the currentBoard and other game parameters
    {
        private Board _currentBoard;
        private int _round;
        private int _currentPlayer;
        private bool _isGameOver;
        
        public GameState()
        {
            _currentBoard = new Board();
            _round = 1;
            _currentPlayer = 1;
            _isGameOver = false;
        }

        public Board getBoard() => _currentBoard;

        public static void updateState(Board newBoard)
        {

        }

        public static void updateState(int round, int nextPlayer)
        {

        }

        public static void updateState(Board newBoard, int round, int nextPlayer)
        {

        }

        public static void updateState(bool isGameOver)
        {

        }

        public static void updateState(Board newBoard, int round, int nextPlayer, bool isGameOver)
        {

        }

        //Getters and Setters
        public int Round
        {
            get => _round;
            set => _round = value;
        }

        public int CurrentPlayer
        {
            get => _currentPlayer;
            set => _currentPlayer = value;
        }

        public bool IsGameOver
        {
            get => _isGameOver;
            set => _isGameOver = value;
        }
    }

    class BoardState //keeps track of the content of each Box
    {
        public string[,] _bContent;
        private Dictionary<string, Box> _boxes;

        public BoardState(Dictionary<string, Box> boxes, string[,] bContent)
        {
            _boxes = boxes;
            _bContent = bContent;
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
        private BoardState state;
        private int rows, cols;

        public Board(int rows = 3, int cols = 3)
        {
            string[,] newBoard = createBoard(rows, cols);
            Dictionary<string, Box> newIdentifier = createIdentifier(newBoard);

            this.rows = rows;
            this.cols = cols;
            this.state = new BoardState(newIdentifier, newBoard);
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

        public string[,] Values
        {
            get => state._bContent;
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
                Console.WriteLine();
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
