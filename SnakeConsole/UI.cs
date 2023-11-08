using SnakeCore;

namespace SnakeConsole;

public class Ui : IRender
{
    private readonly GameSettings gameSettings;

    public Ui(GameSettings gameSettings)
    {
        this.gameSettings = gameSettings;
    }
    public void RenderArray(Board board)
    {
        for (var i = 0; i < gameSettings.BoardSize; i++)
        {
            for (var k = 0; k < gameSettings.BoardSize; k++)
            {
                if (board.GetArrayOfCells()[i, k].Type == CellType.Boundary)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("= ");
                }
                else if (board.GetArrayOfCells()[i, k].Type == CellType.Food)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("@ ");
                }
                else if (board.GetArrayOfCells()[i, k].Type == CellType.Head)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("0 ");
                }
                else if (board.GetArrayOfCells()[i, k].Type == CellType.Body)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("+ ");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(". ");
                }
            }

            Console.WriteLine();
        }
    }

    public void GameOver()
    {
        Console.WriteLine();
        Console.WriteLine("GAME OVER");
        Console.ReadLine();
    }

    public void RenewScore(int score)
    {
        Console.Clear();
        Console.WriteLine("Score " + score);
        Console.WriteLine();
    }
}