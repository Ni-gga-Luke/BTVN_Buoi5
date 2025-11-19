using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uiagamebtvn
{
    public class Player : Character
    {
        public Weapon CurrentWeapon { get; private set; }
        public string ClassName { get; private set; }

        // Original constructor (kept for compatibility)
        public Player(int x, int y, Weapon weapon)
            : base(x, y, 10, weapon.Damage, weapon.RangeAttack, "P")
        {
            CurrentWeapon = weapon;
            ClassName = "Player";
        }

        // New overload used by GameManager to set custom health, class name and symbol
        public Player(int x, int y, Weapon weapon, double health, string className, string symbol)
            : base(x, y, health, weapon.Damage, weapon.RangeAttack, symbol)
        {
            CurrentWeapon = weapon;
            ClassName = className ?? "Player";
        }

        public override void Move(char direction, Tile[,] grid)
        {
            int newX = PosX;
            int newY = PosY;

            switch (char.ToUpper(direction))
            {
                case 'W': newX--; break;
                case 'S': newX++; break;
                case 'A': newY--; break;
                case 'D': newY++; break;
                default: return;
            }

            if (IsValidPosition(newX, newY, grid))
            {
                PosX = newX;
                PosY = newY;
                Console.WriteLine($"Bạn di chuyển đến vị trí ({PosX}, {PosY})");
            }
            else
            {
                Console.WriteLine("Không thể di chuyển đến vị trí này!");
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
                        if (tile.IsOccupied() && tile.Occupant is Enemy)
                        {
                            return tile.Occupant;
                        }
                    }
                }
            }
            return null;
        }

        public void DisplayStatus()
        {
            Console.WriteLine($"Nhân vật: {ClassName}");
            Console.WriteLine($"Ký hiệu: {Symbol}");
            Console.WriteLine($"Vũ khí: {CurrentWeapon.Name}");
            Console.WriteLine($"Sát thương: {Damage}");
            Console.WriteLine($"Tầm đánh: {RangeAttack}");
            Console.WriteLine($"Máu: {Health}");
        }
    }
}
