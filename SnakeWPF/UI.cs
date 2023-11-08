using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using SnakeCore;

namespace SnakeWPF;

public class Ui : IRender
{
    private readonly Rectangle[,] rectangleArray;
    private readonly TextBlock scoreText;
    private readonly MainWindow window;
    private readonly GameSettings gameSettings;

    public Ui(MainWindow window, GameSettings gameSettings)
    {
        this.gameSettings = gameSettings;
        var canvas = window.GameCanvas;
        scoreText = window.ScoreText;
        this.window = window;
        this.window.GameCanvas.Children.Clear();
        rectangleArray = new Rectangle[gameSettings.BoardSize, gameSettings.BoardSize];
        for (var i = 0; i < gameSettings.BoardSize; i++)
        {
            for (var j = 0; j < gameSettings.BoardSize; j++)
            {
                rectangleArray[i, j] = new Rectangle { Width = 20, Height = 20 };
                var rectangle = rectangleArray[i, j];
                Canvas.SetLeft(rectangle, j * 20 + 100);
                Canvas.SetTop(rectangle, i * 20 + 100);

                canvas.Children.Add(rectangle);
            }
        }
    }

    public void RenderArray(Board board)
    {
        window.Dispatcher.Invoke(() =>
        {
            for (var i = 0; i < gameSettings.BoardSize; i++)
            {
                for (var k = 0; k < gameSettings.BoardSize; k++)
                {
                    var cell = board.GetArrayOfCells()[i, k];
                    switch (cell.Type)
                    {
                        case CellType.Boundary:
                            DrawRectangle(Brushes.DarkGreen, i, k);
                            break;
                        case CellType.Food:
                            DrawRectangle(Brushes.Red, i, k);
                            break;
                        case CellType.Head:
                            DrawRectangle(Brushes.Chartreuse, i, k);
                            break;
                        case CellType.Body:
                            DrawRectangle(Brushes.Green, i, k);
                            break;
                        case CellType.Empty:
                            DrawRectangle(Brushes.SeaGreen, i, k);
                            break;
                    }
                }
            }
        });
    }

    public void RenewScore(int score)
    {
        window.Dispatcher.Invoke(() => { scoreText.Text = "Score: " + score; });
    }

    public void GameOver()
    {
        window.Dispatcher.Invoke(() => { scoreText.Text = "Game Over"; });
    }

    private void DrawRectangle(Brush fill, int i, int k)
    {
        var rectangle = rectangleArray[i, k];
        rectangle.Fill = fill;
    }
}