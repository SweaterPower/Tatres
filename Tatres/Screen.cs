using System;
using System.Collections.Generic;
using System.Text;

namespace Tatres
{
    class Screen
    {
        public void Draw()
        {
            Console.Clear();
        }

        public void Redraw()
        {
            Console.Clear();//TODO partial redraw

            string debug = "Debug: ";
            string line = "--";
            for (int i = 0; i < Game.Field.SizeX; i++)
            {
                line += '-';
            }
            Console.WriteLine(line);
            for (int i = 0; i < Game.Field.SizeY; i++)
            {
                Console.Write('|');
                for (int j = 0; j < Game.Field.SizeX; j++)
                {
                    char c = ' ';
                    if (Game.Field[j,i])
                    {
                        c = '0';
                    }
                    Console.Write(c);
                }
                Console.WriteLine('|');
            }
            Console.WriteLine(line);

            var current = Game.TetraminoSet.GetCurrent();
            for (int i = 0; i < current.SizeX; i++)
            {
                for (int j = 0; j < current.SizeY; j++)
                {
                    if (current[i, j])
                    {
                        char c = 'X';
                        int x = current.Point.X + i + 1;
                        int y = current.Point.Y + j + 1;
                        if (x < Game.Field.SizeX && y < Game.Field.SizeY)
                        {
                            Console.SetCursorPosition(x, y);
                            Console.Write(c);
                        }
                    }
                }
            }

            debug += current.Point.ToString();
            Console.SetCursorPosition(Game.Field.SizeX + 2, 0);
            Console.Write(debug);
        }

        public void Reset()
        {
            Console.Clear();
        }
    }
}
