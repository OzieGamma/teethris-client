using System;
using teethris.NET.BoardColorer;
using teethris.NET.MulitPlayerSnakeGame;
using teethris.NET.SDK;
using teethris.NET.SoloSnake;

namespace teethris.NET
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("What game would you like to play ?");
            Console.WriteLine("1. Multi Player Snake");
            Console.WriteLine("2. Single Player Snake");
            Console.WriteLine("3. Multi Player Board Battle");

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
                        Engine.Run<SoloSnakeGame>();
                        done = true;
                        break;
                    case "3":
                        Engine.Run<BoardColorerGame>();
                        done = true;
                        break;
                }   
            }
        }
    }
}
