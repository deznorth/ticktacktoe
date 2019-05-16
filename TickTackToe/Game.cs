using System;

namespace TickTackToe
{
    class Game
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Board board = new Board();
            Console.WriteLine(board.Cols);
            Console.ReadKey();
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
