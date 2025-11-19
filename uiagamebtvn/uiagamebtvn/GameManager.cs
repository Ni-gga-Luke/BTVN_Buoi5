using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uiagamebtvn
{
    public class GameManager
    {
        private GridManager gridManager;
        private Random random;
        private bool gameRunning;

        private class CharacterChoice
        {
            public string Name { get; private set; }
            public double Health { get; private set; }
            public string Symbol { get; private set; }
            public string Description { get; private set; }

            public CharacterChoice(string name, double health, string symbol, string description)
            {
                Name = name;
                Health = health;
                Symbol = symbol;
                Description = description;
            }
        }

        public GameManager(int width, int height)
        {
            gridManager = new GridManager(width, height);
            random = new Random();
            gameRunning = true;
        }

        public void StartBattle()
        {
            Console.WriteLine("Bắt đầu game!");

            // Character choices
            List<CharacterChoice> choices = new List<CharacterChoice>
            {
                new CharacterChoice("Warrior", 14, "W", "High health, melee-oriented"),
                new CharacterChoice("Rogue", 10, "R", "Balanced health, agile"),
                new CharacterChoice("Archer", 8, "A", "Lower health, longer range with bows"),
                new CharacterChoice("Knight", 12, "K", "Good defense and HP")
            };

            Console.WriteLine("\nChọn nhân vật của bạn:");
            for (int i = 0; i < choices.Count; i++)
            {
                var c = choices[i];
                Console.WriteLine($"{i + 1}. {c.Name} - HP: {c.Health} - {c.Description}");
            }

            int selectedIndex = -1;
            while (true)
            {
                Console.Write("Nhập số để chọn (1-" + choices.Count + "): ");
                string input = Console.ReadLine();
                int parsed;
                if (int.TryParse(input, out parsed) && parsed >= 1 && parsed <= choices.Count)
                {
                    selectedIndex = parsed - 1;
                    break;
                }
                Console.WriteLine("Lựa chọn không hợp lệ. Thử lại.");
            }

            var selectedClass = choices[selectedIndex];
            Console.WriteLine($"Bạn chọn: {selectedClass.Name}");

            // Tạo vũ khí
            List<Weapon> weapons = new List<Weapon>
            {
                new Weapon("Sword", 3, 2),
                new Weapon("Axe", 4, 1),
                new Weapon("Bow", 2, 3),
                new Weapon("Spear", 3, 2)
            };

            Weapon randomWeapon = weapons[random.Next(weapons.Count)];
            Console.WriteLine($"Vũ khí của bạn là: {randomWeapon.Name}");

            // Spawn entities with selected class
            SpawnEntities(randomWeapon, selectedClass);

            // Game loop
            while (gameRunning)
            {
                UpdateGameState();
                Console.Clear();

                // Player turn
                TurnPlayer();
                CheckWinOrLose();
                if (!gameRunning) break;

                // Enemy turn
                TurnEnemy();
                CheckWinOrLose();
                Console.WriteLine("\nNhấn phím bất kỳ để tiếp tục...");
                Console.ReadLine();
            }
        }

        private void SpawnEntities(Weapon weapon, CharacterChoice chosen)
        {
            // Spawn player
            int playerX = random.Next(gridManager.XWide);
            int playerY = random.Next(gridManager.YHigh);
            Player player = new Player(playerX, playerY, weapon, chosen.Health, chosen.Name, chosen.Symbol);
            gridManager.SpawnPlayer(player);

            // Spawn enemies (2-4 enemies)
            int enemyCount = random.Next(2, 5);
            for (int i = 0; i < enemyCount; i++)
            {
                int enemyX, enemyY;
                do
                {
                    enemyX = random.Next(gridManager.XWide);
                    enemyY = random.Next(gridManager.YHigh);
                } while (enemyX == playerX && enemyY == playerY);

                Enemy enemy = new Enemy(i + 1, enemyX, enemyY);
                gridManager.SpawnEnemy(enemy);
            }

            gridManager.UpdateGrid();
        }

        private void TurnPlayer()
        {
            Console.WriteLine("\n=== LƯỢT NGƯỜI CHƠI ===");
            gridManager.Player.DisplayStatus();
            gridManager.DisplayEnemiesStatus();
            gridManager.DrawGrid();

            Console.Write("Nhập hướng di chuyển (W/A/S/D): ");
            char direction = Console.ReadKey().KeyChar;
            Console.WriteLine();

            // Di chuyển
            gridManager.Player.Move(direction, gridManager.Grid);
            gridManager.UpdateGrid();

            // Tấn công nếu có mục tiêu
            Character target = gridManager.Player.CheckRangeAttack(gridManager.Grid);
            if (target != null)
            {
                gridManager.Player.Attack(gridManager.Grid);
            }
        }

        private void TurnEnemy()
        {
            Console.WriteLine("\n=== LƯỢT KẺ ĐỊCH ===");
            foreach (var enemy in gridManager.Enemies)
            {
                if (enemy.IsAlive())
                {
                    enemy.Move(' ', gridManager.Grid);
                    gridManager.UpdateGrid();

                    Character target = enemy.CheckRangeAttack(gridManager.Grid);
                    if (target != null)
                    {
                        enemy.Attack(gridManager.Grid);
                    }
                }
            }
        }

        private void CheckWinOrLose()
        {
            // Kiểm tra nếu player chết
            if (!gridManager.Player.IsAlive())
            {
                Console.WriteLine("\n=== GAME OVER ===");
                Console.WriteLine("Bạn đã thua!");
                gameRunning = false;
                return;
            }

            // Kiểm tra nếu tất cả enemy chết
            bool allEnemiesDead = true;
            foreach (var enemy in gridManager.Enemies)
            {
                if (enemy.IsAlive())
                {
                    allEnemiesDead = false;
                    break;
                }
            }

            if (allEnemiesDead)
            {
                Console.WriteLine("\n=== CHIẾN THẮNG ===");
                Console.WriteLine("Bạn đã tiêu diệt tất cả kẻ địch!");
                gameRunning = false;
            }
        }

        private void UpdateGameState()
        {
            // Loại bỏ enemy đã chết
            gridManager.Enemies.RemoveAll(enemy => !enemy.IsAlive());
            gridManager.UpdateGrid();
        }
    }
}
