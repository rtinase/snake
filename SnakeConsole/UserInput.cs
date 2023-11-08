using SnakeCore;

namespace SnakeConsole;

public static class UserInput
{
    public static void ReadInput(Game game)
    {
        var key = Console.ReadKey(intercept: true).Key;
        switch (key)
        {
            case ConsoleKey.UpArrow:
                game.Move(MovementSide.Up);
                break;
            case ConsoleKey.DownArrow:
                game.Move(MovementSide.Down);
                break;
            case ConsoleKey.LeftArrow:
                game.Move(MovementSide.Left);
                break;
            case ConsoleKey.RightArrow:
                game.Move(MovementSide.Right);
                break;
        }
    }
}