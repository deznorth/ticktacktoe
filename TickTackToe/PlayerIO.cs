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

        public bool execInput(string input, int currentPlayer)
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
                    if(p == "")
                    {
                        m.Send($"Try something like \"play a1\"", 'e');
                        return false;
                    }
                    return play(p, playing);
                default:
                    m.Send($"Command \"{command}\" does not exist.", 'e');
                    return false;
            }
        }

        private bool play(string key, char playing)
        {
            //Validate input
            int[] position = Tools.parseBoxKey(key);

            if(position[0]<0 || position[1] < 0)
            {
                m.Send("The selected box does not exist.", 'e');
                return false;
            }
            else
            {
                if(!b.updateBox(position, playing))
                {
                    m.Send("The selected box is not empty.", 'e');
                    return false;
                }
                return true;
            }
        }
    }
}
