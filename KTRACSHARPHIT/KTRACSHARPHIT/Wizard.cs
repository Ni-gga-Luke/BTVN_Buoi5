using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTRACSHARPHIT
{
    internal class Wizard
    {
        private string name;
        public string Name 
        {
            get { return name; }
            set { name = value; }
        }

        private int damage;
        public int Damage
        { 
          get { return damage; } 
          set { damage = value; } 
        }

        private int mana;

        public Wizard()
        {
        }

        public int Mana
        { 
            get { return mana; }
            set { mana = value; }
        }

        public Wizard(string name, int damage, int mana)
        {
            this.name = name;
            this.damage = damage;
            this.mana = mana;
        }


        public void CastSpell()
        {
            Console.WriteLine(name+" gây "+damage+" sát thương với "+mana+" Mana!");
        }
    }
}
