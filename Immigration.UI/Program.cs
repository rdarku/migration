using System;

namespace Immigration.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Green Card Game";
            var game = new Game();
            game.Play();
        }
    }
}
