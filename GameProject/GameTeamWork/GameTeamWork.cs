using System;
using System.Collections.Generic;
using System.Threading;

public class GameTeamWork
{
    //1.Structure "Object" contains four variables - coordinates, color, and its symbols.
    struct Object
    {
        public int x;
        public int y;
        public ConsoleColor color;
        public char symbol;
    }

    public static void Main()
    {
        int livesCount = 6;

        //2.Draw playfield
        int playfieldWidth = 9;
        Console.BufferHeight = Console.WindowHeight = 30;//This is the size of the console window height.
        Console.BufferWidth = Console.WindowWidth = 40;//size of window width.                              
        Console.BackgroundColor = ConsoleColor.DarkRed;//color of playfield

        //3.Make object
        Object userObject = new Object();
        userObject.x = 2;
        userObject.y = Console.WindowHeight - 1;
        userObject.symbol = '@';
        userObject.color = ConsoleColor.Black;

      
        List<Object> objects = new List<Object>();
        Random randomGenerator = new Random();
        while (true)
        {
            bool hit = false;
            int chance = randomGenerator.Next(0, 100);

            if (chance < 80)
            {
                Object newObject = new Object();
                newObject.color = ConsoleColor.Black;
                newObject.x = randomGenerator.Next(0, playfieldWidth);
                newObject.y = 0;
                newObject.symbol = '$';
                objects.Add(newObject);

            }



            //4.Move our object
            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                if (pressedKey.Key == ConsoleKey.LeftArrow)
                {
                    if (userObject.x - 1 > 0)
                    {
                        userObject.x--;
                    }
                }
                else if (pressedKey.Key == ConsoleKey.RightArrow)
                {
                    if (userObject.x + 1 < playfieldWidth)
                    {
                        userObject.x++;
                    }
                }
            }

            List<object> newList = new List<object>();
            for (int i = 0; i < objects.Count; i++)
            {
                Object oldObject = objects[i];
                Object changeObject = new Object();
                changeObject.x = oldObject.x;
                changeObject.y = oldObject.y + 1;
                changeObject.symbol = oldObject.symbol;
                objects.Remove(oldObject);
                objects.Add(changeObject);
                if (changeObject.symbol == '#' && changeObject.y == userObject.y && changeObject.x == userObject.x)
                    //Check if other cars are hitting us 3
                {
                    livesCount--;
                    //hit = true;
                }

                if (changeObject.y < Console.WindowHeight)
                {
                    newList.Add(changeObject);
                }
            }

           
            //6.Check for other object are hitting

            //7.Clear the console with 
            Console.Clear();
            //Print other object
            foreach (Object element in objects)
            {
                PrintOnPosition(element.x, element.y, element.symbol, element.color);
            }
            //8.print our object
            PrintOnPosition(userObject.x, userObject.y, userObject.symbol, userObject.color);



            //9.Draw info
            //10.Slow down program
            Thread.Sleep(500);

        }

      
    }
    //Method which print object 
    static  void PrintOnPosition(int x, int y, char symbol, ConsoleColor color = ConsoleColor.Black)
    {
        //Console.SetCursorPosition move our cursor in place of what we write.
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.WriteLine(symbol);
    }
}
