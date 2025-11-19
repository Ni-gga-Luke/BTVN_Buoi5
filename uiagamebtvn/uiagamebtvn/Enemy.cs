using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uiagamebtvn
{
    public class Enemy : Character
    {
        private static Random random = new Random();
        public int Id { get; private set; }

        public Enemy(int id, int x, int y)
            : base(x, y, 6, 2, 1, "E")
        {
            Id = id;
        }

        public override void Move(char direction, Tile[,] grid)
        {
            // Di chuyển ngẫu nhiên
            char[] directions = { 'W', 'S', 'A', 'D' };
            char randomDirection = directions[random.Next(directions.Length)];

            int newX = PosX;
            int newY = PosY;

            switch (randomDirection)
            {
                case 'W': newX--; break;
                case 'S': newX++; break;
                case 'A': newY--; break;
                case 'D': newY++; break;
            }

            if (IsValidPosition(newX, newY, grid))
            {
                PosX = newX;
                PosY = newY;
            }
        }

        public override Character CheckRangeAttack(Tile[,] grid)
        {
            for (int dx = -RangeAttack; dx <= RangeAttack; dx++)
            {
                for (int dy = -RangeAttack; dy <= RangeAttack; dy++)
                {
                    int checkX = PosX + dx;
                    int checkY = PosY + dy;

                    if (checkX >= 0 && checkX < grid.GetLength(0) &&
                        checkY >= 0 && checkY < grid.GetLength(1))
                    {
                        Tile tile = grid[checkX, checkY];
                        if (tile.IsOccupied() && tile.Occupant is Player)
                        {
                            return tile.Occupant;
                        }
                    }
                }
            }
            return null;
        }
    }
}
