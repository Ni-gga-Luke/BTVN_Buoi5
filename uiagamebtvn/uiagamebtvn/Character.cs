using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uiagamebtvn
{
    public abstract class Character
    {
        public int PosX { get; protected set; }
        public int PosY { get; protected set; }
        public double Health { get; protected set; }
        public double Damage { get; protected set; }
        public int RangeAttack { get; protected set; }
        public string Symbol { get; protected set; }

        protected Character(int x, int y, double health, double damage, int rangeAttack, string symbol)
        {
            PosX = x;
            PosY = y;
            Health = health;
            Damage = damage;
            RangeAttack = rangeAttack;
            Symbol = symbol;
        }

        public abstract void Move(char direction, Tile[,] grid);

        public virtual void TakeDamage(double damage)
        {
            Health -= damage;
            if (Health < 0) Health = 0;
        }

        public virtual void Attack(Tile[,] grid)
        {
            Character target = CheckRangeAttack(grid);
            if (target != null)
            {
                target.TakeDamage(Damage);
                Console.WriteLine($"{GetType().Name} tấn công {target.GetType().Name}, gây {Damage} sát thương!");
            }
        }

        public abstract Character CheckRangeAttack(Tile[,] grid);

        public bool IsAlive()
        {
            return Health > 0;
        }

        protected bool IsValidPosition(int x, int y, Tile[,] grid)
        {
            return x >= 0 && x < grid.GetLength(0) &&
                   y >= 0 && y < grid.GetLength(1) &&
                   !grid[x, y].IsOccupied();
        }
    }
}

