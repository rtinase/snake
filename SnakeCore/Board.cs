namespace SnakeCore;

public class Board
{
    private readonly Cell[,] arrayOfCells;
    private readonly int size;

    public Board(int size)
    {
        this.size = size;
        arrayOfCells = new Cell[size, size];
        FillArray();
        CreateNewFood();
    }

    public int GetSize()
    {
        return size;
    }

    public Cell[,] GetArrayOfCells()
    {
        return arrayOfCells;
    }

    public void CreateNewFood()
    {
        int x;
        int y;
        var rnd = new Random();
        do
        {
            y = rnd.Next(1, size);
            x = rnd.Next(1, size);
        } while (!IsCellEmpty(x, y));

        SetCellType(x, y, CellType.Food);
    }

    public void FillArray()
    {
        for (var i = 0; i < size; i++)
        {
            for (var k = 0; k < size; k++)
            {
                arrayOfCells[i, k] = new Cell(i, k);

                if (i == 0 || k == 0 || i == size - 1 || k == size - 1)
                {
                    arrayOfCells[i, k].Type = CellType.Boundary;
                }
                else
                {
                    arrayOfCells[i, k].Type = CellType.Empty;
                }
            }
        }
    }

    public void AddSnakeToBoard(List<Cell> snakeBody)
    {
        foreach (var cell in snakeBody)
        {
            SetCellType(cell.X, cell.Y, cell.Type);
        }
    }

    public bool IsHeadOnFood(Cell head)
    {
        return arrayOfCells[head.X, head.Y].Type == CellType.Food;
    }

    public void SetCellType(int x, int y, CellType type)
    {
        arrayOfCells[x, y].Type = type;
    }

    public bool CheckBoundaryCollision(Cell head)
    {
        return head.X == 0 || head.Y == 0 || head.X == size - 1 || head.Y == size - 1;
    }

    private bool IsCellEmpty(int x, int y)
    {
        return arrayOfCells[x, y].Type == CellType.Empty;
    }
}