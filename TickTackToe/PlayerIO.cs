using System;
using System.Collections.Generic;
using System.Text;

namespace TickTackToe
{
    class PlayerIO
    {
        Messenger m;
        Board b;

        public PlayerIO(Messenger m, Board b)
        {
            this.m = m;
            this.b = b;
        }

        public string prompt()
        {
            Colorize.Write(ConsoleColor.Magenta, "Input: ");
            return (string)Console.ReadLine();
        }

        public void execInput(string input, int currentPlayer)
        {
            char playing = currentPlayer == 0 ? 'x' : 'o';
            string[] line = input.Split(' ');
            string command = line[0];
            string p = "";
            if (line.Length > 1)
            {
                p = line[1];
            }

            switch (command)
            {
                case "play":
                    //Insert play method here
                    play(p, playing);
                    break;
                default:
                    m.Send($"Command \"{command}\" does not exist.", 'e');
                    break;
            }
        }

        private void play(string key, char playing)
        {
            //Validate input
            int[] position = Tools.parseBoxKey(key);

            if(position[0]<0 || position[1] < 0)
            {
                m.Send("The selected box does not exist.", 'e');
            }
            else
            {
                b.updateBox(position, playing);
            }
        }
    }
}
