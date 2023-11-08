namespace SnakeCore;

public interface IRender
{
    public void RenderArray(Board board);
    public void GameOver();
    public void RenewScore(int score);
}