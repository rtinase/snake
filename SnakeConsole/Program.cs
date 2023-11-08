using SnakeCore;

namespace SnakeConsole;

internal static class Program
{
    private static void Main()
    {
        var settings = new GameSettings(30, 10);
        var ui = new Ui(settings);
        var game = new Game(ui,settings);
        game.StartGame();
        while (true)
        {
            UserInput.ReadInput(game);
        }
    }
}