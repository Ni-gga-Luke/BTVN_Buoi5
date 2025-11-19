using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTRACSHARPHIT
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Wizard wizard = new Wizard();
            wizard.Name = "Thầy pháp Quang Minh";
            wizard.Damage = 20;
            wizard.Mana = 50;
            wizard.CastSpell();
            Console.Clear();

            Warrior warrior01 = new Warrior();
            warrior01.Name = "Quang Minh";
            warrior01.Heal = 20;
            Warrior warrior02 = new Warrior();
            warrior02.Name = " Olaf";
            warrior02.Heal = 20;
            Mage mage01 = new Mage();
            mage01.Name = " Quagmire";
            warrior01.UseAbility(); mage01.UseAbility(); warrior02.UseAbility();
            Console.Clear();

            Player player01 = new Player();
            player01.Name = "Hiệp sĩ";
            player01.Heal = 100;
            player01.Damage = 25;
            Enemy enemy01 = new Enemy();
            enemy01.Name = "Slime";
            enemy01.Heal = 100;
            enemy01.Damage = 5;

            while (player01.IsAlive()&&enemy01.IsAlive()) {
                Console.WriteLine(player01.Name + " tấn công " + enemy01.Name + ", gây " + player01.Damage + " sát thương! " + enemy01.Name + " còn " + (enemy01.Heal - player01.Damage) + " HP.");
                enemy01.Heal = enemy01.Heal - player01.Damage;
                
                Console.WriteLine(enemy01.Name + " cắn " + player01.Name + ", gây " + enemy01.Damage + " sát thương! " + player01.Name + " còn " + (player01.Heal - enemy01.Damage) + " HP.");
                player01.Heal = player01.Heal - enemy01.Damage;
                
            }
            
            
        }
    }
}
