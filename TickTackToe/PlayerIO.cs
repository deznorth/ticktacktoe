using System;
using System.Collections.Generic;
using System.Text;

namespace TickTackToe
{
    class PlayerIO
    {
        public static string prompt(int currentPlayer)
        {
            Console.Write("Input: ");
            return (string)Console.ReadLine();
        }

        public static void execInput(string input)
        {
            string[] line = input.Split(' ');
            string command = line[0];
            if (line.Length > 1)
            {
                string p1 = line[1];
            }

            switch (command)
            {
                case "play":
                    //Insert play method here
                    break;
                default:
                    Console.WriteLine($"Command \"{command}\" does not exist.");
                    break;
            }
        }
    }
}
