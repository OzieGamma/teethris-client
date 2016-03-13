using System;
using teethris.NET.MulitPlayerSnakeGame;
using teethris.NET.SDK;

namespace teethris.NET
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("What game would you like to play ?");
            Console.WriteLine("1. Multi Player Snake Game");
            Console.WriteLine("2. Single Player Snake Game");

            var done = false;
            while (!done)
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        Engine.Run<MultiPlayerSnakeGame>();
                        done = true;
                        break;
                    case "2":
                        Engine.Run<MultiPlayerSnakeGame>();
                        done = true;
                        break;
                }   
            }
        }
    }
}
