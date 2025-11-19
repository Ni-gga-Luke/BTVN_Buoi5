using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uiagamebtvn
{
    using System;
    using System.Text;

    namespace uiagamebtvn
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Thiết lập encoding để hiển thị tiếng Việt
                Console.OutputEncoding = Encoding.UTF8;
                Console.InputEncoding = Encoding.UTF8;

                Console.WriteLine("CHÀO MỪNG ĐẾN VỚI TRÒ CHƠI!");
                Console.WriteLine("Di chuyển: W (lên), S (xuống), A (trái), D (phải)");
                Console.WriteLine("Ký hiệu: P (Player), E (Enemy), X (Ô trống)");
                Console.WriteLine("Nhấn phím bất kỳ để bắt đầu...");
                Console.ReadKey();

                // Tạo game với bản đồ 5x5
                GameManager gameManager = new GameManager(5, 5);
                gameManager.StartBattle();

                Console.WriteLine("\nNhấn phím bất kỳ để thoát...");
                Console.ReadKey();
            }
        }
    }
}
