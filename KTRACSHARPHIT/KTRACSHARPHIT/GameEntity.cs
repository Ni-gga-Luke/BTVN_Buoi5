using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTRACSHARPHIT
{
    public abstract class GameEntity
    {
        private string name;
        public string Name
        { 
            get { return name; }
            set { name = value; }
        }

        private int heal;
        public int Heal
        {
            get { return heal; }
            set {  heal = value; }
        }

        private int damage;
        public int Damage
        {
            get { return damage; }
            set { damage = value; }
        }

        public GameEntity(string name, int heal, int damage)
        {
            this.name = name;
            this.heal = heal;
            this.damage = damage;
        }
        public GameEntity()
        {
        }
        public virtual void TakeDamage(int damage)
        {
            this.damage = damage;
            
        }
        public bool IsAlive()
        {
            if(heal <= 0)
            {
                Console.WriteLine(name+" đã bị tiêu diệt!");
                return false;
            }
            return true;
        }
        public virtual void PerformAttack(GameEntity e)
        {
           
        }

    }

}
