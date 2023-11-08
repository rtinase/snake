using SnakeCore;
using SnakeWebpage.Pages;

namespace SnakeWebpage.Data;

public class Ui : IRender
{
    private readonly GamePage gamePage;

    public Ui(GamePage gamePage)
    {
        this.gamePage = gamePage;
    }

    public void RenderArray(Board board)
    {
        for (var i = 0; i < board.GetSize(); i++)
        {
            for (var k = 0; k < board.GetSize(); k++)
            {
                var cell = board.GetArrayOfCells()[i, k];
                switch (cell.Type)
                {
                    case CellType.Boundary:
                        gamePage.RectanglesArray[i, k].Color = "darkgreen";
                        break;
                    case CellType.Food:
                        gamePage.RectanglesArray[i, k].Color = "red";
                        break;
                    case CellType.Head:
                        gamePage.RectanglesArray[i, k].Color = "chartreuse";
                        break;
                    case CellType.Body:
                        gamePage.RectanglesArray[i, k].Color = "green";
                        break;
                    case CellType.Empty:
                        gamePage.RectanglesArray[i, k].Color = "seagreen";
                        break;
                }
                
            }
        }
        gamePage.Update();
    }

    public void GameOver()
    {
        gamePage.ChangeGameCondition();
    }

    public void RenewScore(int score)
    {
        gamePage.SetScore(score);
    }
}