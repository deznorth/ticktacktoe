using System;
using System.Collections.Generic;
using System.Text;

namespace TickTackToe
{
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

        public void updateBox(int[] position, char value)
        {
            boxes[position[1], position[0]] = $"[{value}]";
        }

        public void checkBoard(char playing)
        {

        }

        public void checkHorizontal(char playing) { }
        public void checkVertical(char playing) { }
        public void checkDiagonal(char playing) { }

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
            string[,] board = new string[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    board[i, j] = "[ ]";
                }
            }

            return board;
        }

        private Dictionary<string, Box> createIdentifier(string[,] board)
        {
            Dictionary<string, Box> identifier = new Dictionary<string, Box>();

            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
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
}
