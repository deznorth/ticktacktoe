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
            return ((int)key - 97);
        }

        public static int[] parseBoxKey(string key)
        {
            char[] split = key.ToCharArray();
            int row = parseRowKey(split[0]);
            int col = (int)(Char.GetNumericValue(split[1])-1);
            return new int[] { col, row };
        }

    }
}
