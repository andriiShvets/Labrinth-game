using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace studying
{
    internal class Program
    {
        // Map char array for the game
        static public char[,] MAP =
           {
                { '|', '—', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '|' },
                { '|', '@', '|', ' ', ' ', ' ', ' ', ' ', '|', '@', ' ', '|', ' ', ' ', ' ', ' ', '|' },
                { '|', ' ', '|', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', '|', ' ', ' ', '|', ' ', '|' },
                { '|', ' ', '|', ' ', ' ', ' ', ' ', ' ', '|', '-', ' ', '|', ' ', ' ', '|', '@', '|' },
                { '|', ' ', '|', ' ', ' ', ' ', ' ', ' ', '|', '-', ' ', '|', ' ', ' ', '|', '-', '|' },
                { '|', ' ', '|', '@', ' ', ' ', ' ', ' ', '|', ' ', ' ', '|', ' ', ' ', ' ', ' ', '|' },
                { '|', ' ', '|', ' ', ' ', ' ', ' ', ' ', '|', ' ', '-', '|', ' ', ' ', ' ', ' ', '|' },
                { '|', ' ', ' ', ' ', ' ', ' ', '|', ' ', '|', ' ', ' ', '|', ' ', ' ', ' ', ' ', '|' },
                { '|', ' ', ' ', ' ', ' ', ' ', '|', ' ', '|', '-', ' ', '|', ' ', ' ', ' ', ' ', '|' },
                { '|', ' ', ' ', ' ', ' ', ' ', '|', ' ', '|', ' ', ' ', '|', ' ', '@', ' ', ' ', '|' },
                { '|', ' ', ' ', ' ', ' ', ' ', '|', ' ', '|', ' ', '-', ' ', ' ', ' ', ' ', ' ', '|' },
                { '|', ' ', ' ', ' ', ' ', ' ', '|', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
                { '|', ' ', ' ', '-', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', '|', '-', '-', ' ', '|' },
                { '|', '-', ' ', '|', '@', ' ', ' ', ' ', '|', ' ', ' ', ' ', '|', ' ', ' ', ' ', '|' },
                { '|', ' ', ' ', '|', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', '|', ' ', ' ', ' ', '|' },
                { '|', ' ', '-', '|', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', '|', ' ', '-', '-', '|' },
                { '|', ' ', ' ', '|', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', '|', ' ', ' ', ' ', '|' },
                { '|', '-', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '-', ' ', ' ', '|' },
                { '|', '@', ' ', '|', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', '|', '@', '|' },
                { '|', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '|' },

            };

        static void Main()
        {

            // Setting the initial position of the user on the map
            int userX = 6, userY = 6;

            // Asking the user to input their hero character
            char hero = CheckUserImput();

            // Clearing the console and hide cursore possition
            Console.Clear();
            Console.CursorVisible = false;

            // Displaying the game instructions for 1 second, then clear the console
            Console.SetCursorPosition(10, 10);
            Console.WriteLine("CLAM ALL TREASURES!");
            Thread.Sleep(1000);
            Console.Clear();

            bool isOpen = true;
            char[] bag = new char[1];

            // Initializing the game loop
            while (isOpen)
            {
                // Drawing the map and the bag of treasures
                DrawMap(bag);
                DrawHero(hero, ref userX, ref userY, ref bag);

                Console.Clear();

                // If the player has collected all the treasures, ending the game loop
                if (bag.Length == 9)
                {
                    isOpen = false;
                    Thread.Sleep(1000);
                    Console.Clear();
                }
            }

            // Displaying the congratulations message and wait for a key press to exit the game
            Console.SetCursorPosition(10, 10);
            Console.Beep(784, 500);
            Console.WriteLine("CONGRATULATIONS, YOU WIN THE GAME!");
            Console.ReadKey();

        }

        // The function checks if the user entered correct symbol for the hero
        static char CheckUserImput()
        {
            Console.SetCursorPosition(10, 10);

            // Prompting the user to enter a character for the hero and read their input
            Console.Write("Enter ur hero character : ");
            string input = Console.ReadLine().Trim();

            // Keeping prompting the user until they enter a single character for the hero character
            while (!Regex.IsMatch(input, @"^[a-zA-Z]$"))
            {
                Console.Clear();
                Console.SetCursorPosition(3, 10);
                Console.Write("Invalid input, please enter a single letter for hero character: ");
                input = Console.ReadLine().Trim();
            }

            // Converting the user's input to a character and return it
            char hero = Convert.ToChar(input);
            return hero;
        }

        //This method resceives an array of characters and displays the map array and display info with gaining points according to data in the recived array
        static void DrawMap(char[] bag)
        {
            // Setting the console cursor position to the top-left corner of the console window
            Console.SetCursorPosition(0, 0);

            // Drawing the map by looping through each element of the 'map' array and printing it to the console
            for (int i = 0; i < MAP.GetLength(0); i++)
            {
                for (int j = 0; j < MAP.GetLength(1); j++)
                {
                    Console.Write(MAP[i, j]);
                }
                Console.WriteLine();
            }

            // Drawing the contents of the bag array to the console
            DrawBag(bag);
        }

        // This method recives character to display as a hero and indexes as the user moves, and the bag[] to add points if user find one 
        static void DrawHero(char hero, ref int userX, ref int userY, ref char[] bag)
        {
            // Setting the console cursor position to the current location of the hero
            Console.SetCursorPosition(userY, userX);
            
            ConsoleColor defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;

            // Drawing the hero character to the console
            Console.Write(hero);

            Console.ForegroundColor = defaultColor;
            
            // Waiting for the user to input a movement command using the arrow keys
            ConsoleKeyInfo charKey = Console.ReadKey();

            // Moving the hero character up, down, left or right depending on the user's input
            switch (charKey.Key)
            {
                case ConsoleKey.UpArrow:
                    if (MAP[userX - 1, userY] != '|' && MAP[userX - 1, userY] != '-')
                    {
                        --userX;
                    }
                    break;

                case ConsoleKey.DownArrow:
                    if (MAP[userX + 1, userY] != '|' && MAP[userX + 1, userY] != '-')
                    {
                        ++userX;
                    }
                    break;

                case ConsoleKey.LeftArrow:
                    if (MAP[userX, userY - 1] != '|' && MAP[userX, userY - 1] != '-')
                    {
                        --userY;
                    }
                    break;

                case ConsoleKey.RightArrow:
                    if (MAP[userX, userY + 1] != '|' && MAP[userX, userY + 1] != '-')
                    {
                        ++userY;
                    }
                    break;
            }

            // If the hero is currently on a location with a treasure, adding it to the bag array
            Treserous(ref bag, userX, userY);
        }

        // This method receives an array of characters and displays it on the screen, separated by a comma. If the array is empty, it displays an empty message.
        static void Treserous(ref char[] bag, int userX, int userY)
        {
            // Checking if the user's current position is matcing a treasure location
            if (MAP[userX, userY] == '@')
            {
                // Changing treasure char with '0'
                Console.Beep(523, 250);
                MAP[userX, userY] = '0';

                char[] tempBag = new char[bag.Length + 1];

                for (int i = 0; i < bag.Length; i++)
                {
                    tempBag[i] = bag[i];
                }

                tempBag[^1] = ' ';
                bag = tempBag;
            }
        }

        // Printing the contents of the user's bag with colorful bar
        static void DrawBag(char[] bag)
        {
            Console.SetCursorPosition(0, 23);

            Console.Write("bag: ");
            ConsoleColor defaultColor = Console.BackgroundColor;
            Console.Write('[');

            // Drawing bar according to nuber os counted treasures
            for (int i = 0; i < bag.Length; i++)
            {
                if (bag.Length < 3)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write(bag[i]);
                }
                if (bag.Length >= 3 && bag.Length < 6)
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.Write(bag[i]);
                }
                if (bag.Length >= 6)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.Write(bag[i]);
                }
            }

            // Filling the rest of the bar with empty space
            Console.BackgroundColor = defaultColor;

            for (int i = bag.Length - 1; i < 9; i++)
            {
                Console.Write(" ");
            }

            Console.Write(']');
        }
    }
}