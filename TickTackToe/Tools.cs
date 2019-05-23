using System;
using System.Collections.Generic;
using System.Text;

namespace TickTackToe
{
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
            return ((int)key - 96);
        }

    }
}
