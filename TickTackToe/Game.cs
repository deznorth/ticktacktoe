using System;

namespace TickTackToe
{
    class Game
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Board board = new Board();
            Console.ReadKey();
        }
    }

    struct State //IMPORTANT! continue this.
    {
        //GameState - keeps track of the currentBoard and other game parameters
        private Board _currentBoard;
        private int _round;
        private int _currentPlayer;
        private bool _isGameOver;

        //BoardState - keeps track of the content of each Box
        private Box[][] _boxes;

        private void gameInit()
        {
            _currentBoard = new Board();
            _round = 1;
            _currentPlayer = 1;
            _isGameOver = false;
        }
    }

    struct Box
    {
        private int _x, _y;

        public int[] position
        {
            get => { _x, _y};
        }
    }

    class Board
    {
        private int rows, cols;

        public Board(int rows = 3, int cols = 3)
        {
            this.rows = rows;
            this.cols = cols;
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
    }
}
