using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace PacManv1
{
    class Map
    {
        int[,] map;

        public Map(int[,] _map)
        {
            if (_map != null && _map.Length != 0)
            {
                map = new int[_map.GetLength(0), _map.GetLength(1)];
                for (int i = 0; i < _map.GetLength(0); i++)
                {
                    for (int j = 0; j < _map.GetLength(1); j++)
                    {
                        map[i, j] = _map[i, j];
                    }
                }
            }

        }
        public int[,] GetMap
        {
            get { return map; }
            set { map = value; }
        }

        public void ToPrintMap(PacManPlayer p1, Ghost g1, Ghost g2, Ghost g3, Ghost g4)
        {
            Console.Write("+ + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +\n+");
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (i == p1.GetPosX && j == p1.GetPosY)
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(" ☺ ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        if (i == g1.GetPosX && j == g1.GetPosY && g1.GetIsAlive == true)
                        {
                            if (g1.GetMode == false)
                            {
                                Console.BackgroundColor = ConsoleColor.Yellow;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write("^W^");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.Write("^W^");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                        }
                        else
                        {
                            if (i == g2.GetPosX && j == g2.GetPosY && g2.GetIsAlive == true)
                            {
                                if (g2.GetMode == false)
                                {
                                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.Write("^W^");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.BackgroundColor = ConsoleColor.Black;
                                }
                                else
                                {
                                    Console.BackgroundColor = ConsoleColor.Red;
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write("^W^");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.BackgroundColor = ConsoleColor.Black;
                                }
                            }
                            else
                            {
                                if (i == g3.GetPosX && j == g3.GetPosY && g3.GetIsAlive == true)
                                {
                                    if (g3.GetMode == false)
                                    {
                                        Console.BackgroundColor = ConsoleColor.Magenta;
                                        Console.ForegroundColor = ConsoleColor.Black;
                                        Console.Write("^W^");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.BackgroundColor = ConsoleColor.Black;
                                    }
                                    else
                                    {
                                        Console.BackgroundColor = ConsoleColor.Red;
                                        Console.ForegroundColor = ConsoleColor.Magenta;
                                        Console.Write("^W^");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.BackgroundColor = ConsoleColor.Black;
                                    }
                                }
                                else
                                {
                                    if (i == g4.GetPosX && j == g4.GetPosY && g4.GetIsAlive == true)
                                    {
                                        if (g4.GetMode == false)
                                        {
                                            Console.BackgroundColor = ConsoleColor.DarkRed;
                                            Console.ForegroundColor = ConsoleColor.Black;
                                            Console.Write("^W^");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.BackgroundColor = ConsoleColor.Black;
                                        }
                                        else
                                        {
                                            Console.BackgroundColor = ConsoleColor.Red;
                                            Console.ForegroundColor = ConsoleColor.Magenta;
                                            Console.Write("^W^");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.BackgroundColor = ConsoleColor.Black;
                                        }

                                    }
                                    else
                                    {
                                        if (i == 10 && (j == 13 || j == 14))
                                        {
                                            Console.BackgroundColor = ConsoleColor.Gray;
                                            Console.Write("   ");
                                            Console.BackgroundColor = ConsoleColor.Black;
                                        }
                                        else
                                        {
                                            if (map[i, j] == -1)
                                            {
                                                Console.BackgroundColor = ConsoleColor.DarkBlue;
                                                Console.Write("   ");
                                                Console.BackgroundColor = ConsoleColor.Black;
                                            }
                                            if (map[i, j] == 0)
                                            {
                                                Console.Write("   ");
                                            }
                                            if (map[i, j] == 1)
                                            {
                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                Console.Write(" o ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                            }
                                            if (map[i, j] == 10)
                                            {
                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write(" ¤ ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                            }
                                        }

                                    }
                                }
                            }

                        }
                    }
                }
                Console.Write("+\n+");
            }
            Console.WriteLine(" + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +");
        }

        /// <summary>
        /// Displays uniquely the title, the map and "score"
        /// </summary>
        public void ToPrintMapv2()
        {
            Console.Write("+ + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +\n+");
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {

                    if (i == 10 && (j == 13 || j == 14))
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.Write("   ");
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        if (map[i, j] == -1)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.Write("   ");
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        if (map[i, j] == 0)
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write("   ");
                        }
                        if (map[i, j] == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(" o ");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        if (map[i, j] == 10)
                        {
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write(" ¤ ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                    }
                }
                Console.Write("+\n+");

            }

            Console.WriteLine(" + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +");


            for (int i = 0; i < 6; i++)
            {
                Console.SetCursorPosition(10, 35+i);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                if (i == 0) Console.Write("   _____  _____ ____  _____  ______ \t\t");
                if (i == 1) Console.Write("  / ____|/ ____/ __ \\|  __ \\|  ____|\t\t");
                if (i == 2) Console.Write(" | (___ | |   | |  | | |__) | |__   \t\t");
                if (i == 3) Console.Write("  \\___ \\| |   | |  | |  _  /|  __|  \t\t");
                if (i == 4) Console.Write("  ____) | |___| |__| | | \\ \\| |____ \t\t");
                if (i == 5) Console.Write(" |_____/ \\_____\\____/|_|  \\_|______|\t\t");
            }
        }
    }
    
}
