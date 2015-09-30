using System;
using System.Collections.Generic;
using System.Threading;

public class GameTeamWork
{
    //1.Structure "Object" contains four variables - coordinates, color, and its symbols.
    public class Object
    {
        public int x;
        public int y;
        public ConsoleColor color;
        public char symbol;
    }

    private static readonly Random RandomGenerator = new Random();
    private static int playfieldWidth = 9;
    public static void Main()
    {
        int livesCount = 6;
        int point = 0;
        double speed = 100.0;
        double acceleration = 0.5;

        //2.Draw playfield
        DrawPlayfield();

        //3.Make user object
        var userObject = MakeUserObject();
        
        List<Object> objects = new List<Object>();
        while (true)
        {
            PrintTheSideBoard();
            speed += acceleration;
            if (speed > 400)
            {
                speed = 400;
            }
            bool hit = false;
            int chance = RandomGenerator.Next(0, 100);

            if (chance < 50)
            {
               MakeObjects(objects, '§', ConsoleColor.Green);
            }
            if (chance < 5)
            {
                MakeObjects(objects, '$', ConsoleColor.DarkRed);
            }
            //4.Move our object
            PressedKey(userObject, playfieldWidth);

            //Struct was converted to Class , so now we can change (y) easily!
            for (int i = 0; i < objects.Count; i++)
            {
                //is hit?
                if (objects[0].symbol == '$' && objects[0].y == userObject.y && objects[0].x == userObject.x)
                {
                    livesCount--;
                    hit = true;
                    Console.Beep(658, 125); Console.Beep(1320, 500);//sound
                }

                if (objects[0].symbol == '$' && objects[0].y == userObject.y && objects[0].x == userObject.x)
                {
                    point++;             
                    //Console.Beep(658, 125); Console.Beep(1320, 500);//sound
                }

                if (objects[0].y == Console.WindowHeight - 1)
                {
                    objects.RemoveAt(0);
                }
                if (objects[i].y < Console.WindowHeight - 1)
                {
                    objects[i].y = objects[i].y + 1;
                }

            }
   
            Console.Clear();

            foreach (Object element in objects)
            {
                PrintOnPosition(element.x, element.y, element.symbol, element.color);
            }

            PrintOnPosition(userObject.x, userObject.y, userObject.symbol, userObject.color);

            //9.Draw info

            Thread.Sleep(500);
        }
    }

    private static void PressedKey(Object userObject, int playfieldWidth)
    {
        while (Console.KeyAvailable)
        {
            ConsoleKeyInfo pressedKey = Console.ReadKey(true);
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }
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
    }
    /// <summary>
    /// Make user player
    /// </summary>
    /// <returns></returns>
    private static Object MakeUserObject()
    {
        Object userObject = new Object();
        userObject.x = 2;
        userObject.y = Console.WindowHeight - 1;
        userObject.symbol = '@';
        userObject.color = ConsoleColor.DarkRed;
        return userObject;
    }

    /// <summary>
    /// Objects generator.
    /// </summary>
    /// <param name="objects">list of object where we added</param>
    /// <param name="symbol">Symbol of object</param>
    /// <param name="color">Color of object</param>
    private static void MakeObjects(List<Object> objects, char symbol, ConsoleColor color)
    {
        Object newObject = new Object();
        newObject.color = color;
        newObject.x = RandomGenerator.Next(0, playfieldWidth);
        newObject.y = 0;
        newObject.symbol = symbol;
        objects.Add(newObject);
    }

    /// <summary>
    /// Draw play field
    /// </summary>
    private static void DrawPlayfield()
    {
        Console.BufferHeight = Console.WindowHeight = 30; //This is the size of the console window height.
        Console.BufferWidth = Console.WindowWidth = 40; //size of window width.                              
        Console.BackgroundColor = ConsoleColor.Black; //color of playfield
    }

    /// <summary>
    /// Print object on position
    /// </summary>
    /// <param name="x">position x</param>
    /// <param name="y">position y</param>
    /// <param name="symbol">Symbol of player</param>
    /// <param name="color">Color of player</param>
    private static void PrintOnPosition(int x, int y, char symbol, ConsoleColor color = ConsoleColor.Green)
    {
        //Console.SetCursorPosition move our cursor in place of what we write.
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(symbol);
    }using System;
using System.Collections.Generic;
using System.Threading;

public class GameTeamWork
{
    //1.Structure "Object" contains four variables - coordinates, color, and its symbols.
    public class Object
    {
        public int x;
        public int y;
        public ConsoleColor color;
        public char symbol;
    }

    private static readonly Random RandomGenerator = new Random();
    private static int playfieldWidth = 9;
    public static void Main()
    {
        int livesCount = 6;
        int point = 0;
        double speed = 100.0;
        double acceleration = 0.5;

        //2.Draw playfield
        DrawPlayfield();

        //3.Make user object
        var userObject = MakeUserObject();
        
        List<Object> objects = new List<Object>();
        while (true)
        {
            PrintTheSideBoard();
            speed += acceleration;
            if (speed > 400)
            {
                speed = 400;
            }
            bool hit = false;
            int chance = RandomGenerator.Next(0, 100);

            if (chance < 50)
            {
               MakeObjects(objects, '§', ConsoleColor.Green);
            }
            if (chance < 5)
            {
                MakeObjects(objects, '$', ConsoleColor.DarkRed);
            }
            //4.Move our object
            PressedKey(userObject, playfieldWidth);

            //Struct was converted to Class , so now we can change (y) easily!
            for (int i = 0; i < objects.Count; i++)
            {
                //is hit?
                if (objects[0].symbol == '$' && objects[0].y == userObject.y && objects[0].x == userObject.x)
                {
                    livesCount--;
                    hit = true;
                    Console.Beep(658, 125); Console.Beep(1320, 500);//sound
                }

                if (objects[0].symbol == '$' && objects[0].y == userObject.y && objects[0].x == userObject.x)
                {
                    point++;             
                    //Console.Beep(658, 125); Console.Beep(1320, 500);//sound
                }

                if (objects[0].y == Console.WindowHeight - 1)
                {
                    objects.RemoveAt(0);
                }
                if (objects[i].y < Console.WindowHeight - 1)
                {
                    objects[i].y = objects[i].y + 1;
                }

            }
   
            Console.Clear();

            foreach (Object element in objects)
            {
                PrintOnPosition(element.x, element.y, element.symbol, element.color);
            }

            PrintOnPosition(userObject.x, userObject.y, userObject.symbol, userObject.color);

            //9.Draw info

            Thread.Sleep(500);
        }
    }

    private static void PressedKey(Object userObject, int playfieldWidth)
    {
        while (Console.KeyAvailable)
        {
            ConsoleKeyInfo pressedKey = Console.ReadKey(true);
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }
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
    }
    /// <summary>
    /// Make user player
    /// </summary>
    /// <returns></returns>
    private static Object MakeUserObject()
    {
        Object userObject = new Object();
        userObject.x = 2;
        userObject.y = Console.WindowHeight - 1;
        userObject.symbol = '@';
        userObject.color = ConsoleColor.DarkRed;
        return userObject;
    }

    /// <summary>
    /// Objects generator.
    /// </summary>
    /// <param name="objects">list of object where we added</param>
    /// <param name="symbol">Symbol of object</param>
    /// <param name="color">Color of object</param>
    private static void MakeObjects(List<Object> objects, char symbol, ConsoleColor color)
    {
        Object newObject = new Object();
        newObject.color = color;
        newObject.x = RandomGenerator.Next(0, playfieldWidth);
        newObject.y = 0;
        newObject.symbol = symbol;
        objects.Add(newObject);
    }

    /// <summary>
    /// Draw play field
    /// </summary>
    private static void DrawPlayfield()
    {
        Console.BufferHeight = Console.WindowHeight = 30; //This is the size of the console window height.
        Console.BufferWidth = Console.WindowWidth = 40; //size of window width.                              
        Console.BackgroundColor = ConsoleColor.Black; //color of playfield
    }

    /// <summary>
    /// Print object on position
    /// </summary>
    /// <param name="x">position x</param>
    /// <param name="y">position y</param>
    /// <param name="symbol">Symbol of player</param>
    /// <param name="color">Color of player</param>
    private static void PrintOnPosition(int x, int y, char symbol, ConsoleColor color = ConsoleColor.Green)
    {
        //Console.SetCursorPosition move our cursor in place of what we write.
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(symbol);
    }

    /// <summary>
    /// Print information
    /// </summary>
    /// <param name="x">position x of info</param>
    /// <param name="y">position y info</param>
    /// <param name="str">text</param>
    /// <param name="color">color of text</param>
    private static void PrintStringOnPosition(int x, int y, string str,
     ConsoleColor color = ConsoleColor.DarkCyan) //Draw info 
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.WriteLine(str);
    }

   private static void PrintTheSideBoard()
   {
       for (int i = 0; i < Console.WindowHeight; i++)
       {
           PrintOnPosition(9, i, '|', ConsoleColor.White);
       }
   }
}

    /// <summary>
    /// Print information
    /// </summary>
    /// <param name="x">position x of info</param>
    /// <param name="y">position y info</param>
    /// <param name="str">text</param>
    /// <param name="color">color of text</param>
    private static void PrintStringOnPosition(int x, int y, string str,
     ConsoleColor color = ConsoleColor.DarkCyan) //Draw info 
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(str);
    }

   private static void PrintTheSideBoard()
   {
       for (int i = 0; i < Console.WindowHeight; i++)
       {
           PrintOnPosition(9, i, '|', ConsoleColor.White);
       }
   }
}
