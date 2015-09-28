using System;
using System.Security.Cryptography.X509Certificates;
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
        //2.We will insert all in while-loop
        while (true)
        {
            //3.Move our key pressed
            //4.Move our object
            //5.Check for other object are hitting
            //6.Clear the console with (Console.Clear)
            //7.Draw playfield
            Console.BufferHeight = Console.WindowHeight = 30;//This is the size of the console window height.
            Console.BufferWidth = Console.WindowWidth = 40;//size of window width.
            Console.BackgroundColor = ConsoleColor.DarkRed;//color of playfield
            //8.Draw info
            //9.Slow down program
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

