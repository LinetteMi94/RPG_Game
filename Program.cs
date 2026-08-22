using RPG_Game.Game;

namespace RPG_Game;

internal static class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        GameLoop game = new GameLoop();
        game.Start();
    }
}