using System.Timers;
using Timer = System.Timers.Timer;

namespace SnakeCore;

public class Game
{
    private readonly GameSettings gameSettings;
    private readonly IRender render;
    private readonly Timer timer;
    private Board board;
    private int score;
    private Snake snake = new Snake();
    private GameState state = GameState.NotStarted;

    public Game(IRender render, GameSettings gameSettings)
    {
        board = new Board(gameSettings.BoardSize);
        timer = new Timer(10 * gameSettings.Speed);
        this.gameSettings = gameSettings;
        timer.Elapsed += ExecuteOnTick;
        this.render = render;
    }

    public GameState GetState()
    {
        return state;
    }

    public void SetGameState(GameState newState)
    {
        this.state = newState;
    }

    private void ExecuteOnTick(object? sender, ElapsedEventArgs e)
    {
        render.RenewScore(score);
        render.RenderArray(board);
        ComputingNextMove();
    }

    public void Move(MovementSide direction)
    {
        snake.ChangeDirection(direction);
    }

    public void StartGame()
    {
        state = GameState.Running;
        timer.Start();
    }

    private void ComputingNextMove()
    {
        MoveSnake();
        if (board.CheckBoundaryCollision(snake.Head) || snake.CheckBodyCollision())
        {
            GameOver();
        }

        if (board.IsHeadOnFood(snake.Head))
        {
            snake.Grow(score);
            score++;
            board.CreateNewFood();
        }

        board.AddSnakeToBoard(snake.GetSnakeBody());
    }

    public void GameOver()
    {
        timer.Stop();
        render.GameOver();
    }

    public void StopGame()
    {
        timer.Stop();
    }

    private void MoveSnake()
    {
        var tailCell = snake.GetSnakeBody().Last();
        board.SetCellType(tailCell.X, tailCell.Y, CellType.Empty);
        snake.Move();
    }

    public void Restart()
    {
        timer.Interval = 10 * gameSettings.Speed;
        state = GameState.Running;
        timer.Start();
        score = 0;
        board = new Board(gameSettings.BoardSize);
        board.FillArray();
        snake = new Snake();
        board.CreateNewFood();
    }

    public void Pause()
    {
        if (state != GameState.Pause)
        {
            timer.Stop();
            state = GameState.Pause;
        }
        else
        {
            timer.Start();
            state = GameState.Running;
        }
    }
}