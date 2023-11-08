namespace SnakeCore
{
    public class Snake
    {
        private static MovementSide currentDirection;
        private readonly List<Cell> snakeBody = new();

        public Snake()
        {
            snakeBody.Add(new Cell(5, 5, CellType.Head));
            snakeBody.Add(new Cell(5, 4, CellType.Body));
            currentDirection = MovementSide.Right;
        }

        public Cell Head => snakeBody.First();

        public List<Cell> GetSnakeBody()
        {
            return snakeBody;
        }

        public void ChangeDirection(MovementSide direction)
        {
            if (direction == MovementSide.Up && currentDirection != MovementSide.Down)
            {
                currentDirection = MovementSide.Up;
            }
            else if (direction == MovementSide.Down && currentDirection != MovementSide.Up)
            {
                currentDirection = MovementSide.Down;
            }
            else if (direction == MovementSide.Right && currentDirection != MovementSide.Left)
            {
                currentDirection = MovementSide.Right;
            }
            else if (direction == MovementSide.Left && currentDirection != MovementSide.Right)
            {
                currentDirection = MovementSide.Left;
            }
        }

        public void Grow(int score)
        {
            for (var i = 0; i <= score; i++)
            {
                snakeBody.Add(new Cell(snakeBody.Last().X, snakeBody.Last().Y, CellType.Body));
            }
        }

        public bool CheckBodyCollision()
        {
            var collisionFound = (
                from cell in snakeBody.Skip(1)
                where cell.X == Head.X && cell.Y == Head.Y
                select cell
            ).Any();
            return collisionFound;
        }

        public void Move()
        {
            var newHead = new Cell(Head.X, Head.Y, Head.Type);
            switch (currentDirection)
            {
                case MovementSide.Right:
                    newHead.Y++;
                    break;
                case MovementSide.Left:
                    newHead.Y--;
                    break;
                case MovementSide.Up:
                    newHead.X--;
                    break;
                case MovementSide.Down:
                    newHead.X++;
                    break;
            }

            snakeBody.Insert(0, newHead);
            snakeBody.Remove(snakeBody.Last());
            snakeBody[1].Type = CellType.Body;
        }
    }
}