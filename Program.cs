using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace studying
{
    internal class Program
    {
        static public char[,] map =
           {
                { '|', '—', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '|' },
                { '|', '@', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
                { '|', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', '|' },
                { '|', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', '@', '|' },
                { '|', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', '-', '|' },
                { '|', ' ', '|', '@', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
                { '|', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
                { '|', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', '@', ' ', ' ', ' ', ' ', '|' },
                { '|', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
                { '|', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', '@', ' ', ' ', '|' },
                { '|', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
                { '|', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
                { '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', '|' },
                { '|', '|', '-', '|', '@', ' ', ' ', ' ', '|', ' ', ' ', ' ', '|', ' ', ' ', ' ', '|' },
                { '|', '|', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', '|', ' ', ' ', ' ', '|' },
                { '|', '|', ' ', '|', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', '|', ' ', ' ', ' ', '|' },
                { '|', '|', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', '@', ' ', '|' },
                { '|', '|', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', '|' },
                { '|', '|', '@', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', '|' },
                { '|', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '|' },

            };
        static void Main()
        {
            Console.SetCursorPosition(10, 10);

            int userX = 6, userY = 6;
            Console.SetCursorPosition(10, 10);
            char[] bag = new char[1];

            Console.Write("Enter ur hero character : ");
            char hero = Convert.ToChar(Console.ReadLine());

            Console.Clear();
            Console.CursorVisible = false;

            Console.SetCursorPosition(10, 10);
            Console.WriteLine("CLAM ALL TREASURES!");
            Thread.Sleep(1000);
            Console.Clear();

            bool isOpen = true;

            while (isOpen)
            {
                //DrawBag(bag);
                DrawMap(bag);
                DrawHero(hero, ref userX, ref userY, ref bag);

                Console.Clear();
                if (bag.Length == 9)
                {
                    isOpen = false;
                    Thread.Sleep(1000);
                    Console.Clear();
                }
            }
            Console.SetCursorPosition(10, 10);
            Console.Beep(784, 500);
            Console.WriteLine("CONGRATULATIONS, U WIN THE GAME!");
            Console.ReadKey();
            
        }

        static void DrawMap(char[] bag)
        {


            Console.SetCursorPosition(0, 0);

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
            DrawBag(bag);
        }

        static void DrawHero(char hero, ref int userX, ref int userY, ref char[] bag)
        {
            Console.SetCursorPosition(userY, userX);

            Console.Write(hero);

            ConsoleKeyInfo charKey = Console.ReadKey();

            switch (charKey.Key)
            {
                case ConsoleKey.UpArrow:
                    if (map[userX - 1, userY] != '|' && map[userX - 1, userY] != '-')
                    {
                        --userX;
                    }
                    break;

                case ConsoleKey.DownArrow:
                    if (map[userX + 1, userY] != '|' && map[userX + 1, userY] != '-')
                    {
                        ++userX;
                    }
                    break;

                case ConsoleKey.LeftArrow:
                    if (map[userX, userY - 1] != '|' && map[userX, userY - 1] != '-')
                    {
                        --userY;
                    }
                    break;

                case ConsoleKey.RightArrow:
                    if (map[userX, userY + 1] != '|' && map[userX, userY + 1] != '-')
                    {
                        ++userY;
                    }
                    break;
            }

            Treserous(ref bag, userX, userY);
        }

        static void Treserous(ref char[] bag, int userX, int userY)
        {
            if (map[userX, userY] == '@')
            {
                Console.Beep(523, 250);
                map[userX, userY] = '0';

                char[] tempBag = new char[bag.Length + 1];

                for (int i = 0; i < bag.Length; i++)
                {
                    tempBag[i] = bag[i];
                }

                tempBag[^1] = ' ';
                bag = tempBag;
            }
        }
        static void DrawBag(char[] bag)
        {
            Console.SetCursorPosition(0, 23);

            Console.Write("bag: ");
            ConsoleColor defaultColor = Console.BackgroundColor;
            Console.Write('[');
            Console.BackgroundColor = ConsoleColor.Magenta;
            for (int i = 0; i < bag.Length; i++)
            {
                Console.Write(bag[i]);
            }
            Console.BackgroundColor = defaultColor;
            for (int i = bag.Length - 1; i < 9; i++)
            {
                Console.Write(" ");
            }
            Console.Write(']');

        }

    }
}