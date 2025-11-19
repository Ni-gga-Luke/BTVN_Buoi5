using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uiagamebtvn
{
    public class GridManager
    {
        public int XWide { get; private set; }
        public int YHigh { get; private set; }
        public Tile[,] Grid { get; private set; }
        public List<Enemy> Enemies { get; private set; }
        public Player Player { get; private set; }

        public GridManager(int xWide, int yHigh)
        {
            XWide = xWide;
            YHigh = yHigh;
            Grid = new Tile[XWide, YHigh];
            Enemies = new List<Enemy>();
            SpawnTiles();
        }

        private void SpawnTiles()
        {
            for (int x = 0; x < XWide; x++)
            {
                for (int y = 0; y < YHigh; y++)
                {
                    Grid[x, y] = new Tile(x, y);
                }
            }
        }

        public void SpawnPlayer(Player player)
        {
            Player = player;
            UpdateGrid();
        }

        public void SpawnEnemy(Enemy enemy)
        {
            Enemies.Add(enemy);
            UpdateGrid();
        }

        public void UpdateGrid()
        {
            // Reset grid
            for (int x = 0; x < XWide; x++)
            {
                for (int y = 0; y < YHigh; y++)
                {
                    Grid[x, y].Occupant = null;
                }
            }

            // Update player position
            if (Player != null && Player.IsAlive())
            {
                Grid[Player.PosX, Player.PosY].Occupant = Player;
            }

            // Update enemy positions
            foreach (var enemy in Enemies)
            {
                if (enemy.IsAlive())
                {
                    Grid[enemy.PosX, enemy.PosY].Occupant = enemy;
                }
            }
        }

        public void DrawGrid()
        {
            Console.WriteLine("-------------------------");
            for (int x = 0; x < XWide; x++)
            {
                for (int y = 0; y < YHigh; y++)
                {
                    Console.Write(Grid[x, y].GetDisplaySymbol() + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("-------------------------");
        }

        public void DisplayEnemiesStatus()
        {
            for (int i = 0; i < Enemies.Count; i++)
            {
                if (Enemies[i].IsAlive())
                {
                    Console.WriteLine($"Enemy {i + 1}: {Enemies[i].Health} HP");
                }
            }
        }
    }
}
