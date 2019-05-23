using System;
using System.Collections.Generic;
using System.Text;

namespace TickTackToe
{
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
}
