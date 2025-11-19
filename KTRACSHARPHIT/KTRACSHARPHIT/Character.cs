using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTRACSHARPHIT
{
    internal class Character
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
            set { heal = value; }
        }

        public Character(string name, int heal)
        {
            this.name = name;
            this.heal = heal;
        }

        public Character()
        {
        }
        public virtual void UseAbility()
        {

        }
    }
}
