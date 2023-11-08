namespace SnakeCore;

public class GameSettings
{
    public int BoardSize;
    public int Speed;

    public GameSettings(int size, int speed)
    {
        BoardSize = size;
        Speed = speed;
    }
}