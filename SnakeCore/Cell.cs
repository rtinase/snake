namespace SnakeCore;

public class Cell
{
    public Cell(int x, int y)
    {
        X = x;
        Y = y;
    }

    public Cell(int x, int y, CellType type)
    {
        X = x;
        Y = y;
        Type = type;
    }
    public int X { get; set; }

    public int Y { get; set; }

    public CellType Type { get; set; }
}