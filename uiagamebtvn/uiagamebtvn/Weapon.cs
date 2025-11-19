using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uiagamebtvn
{
    public class Weapon
    {
        public string Name { get; private set; }
        public double Damage { get; private set; }
        public int RangeAttack { get; private set; }

        public Weapon(string name, double damage, int rangeAttack)
        {
            Name = name;
            Damage = damage;
            RangeAttack = rangeAttack;
        }
    }
}
