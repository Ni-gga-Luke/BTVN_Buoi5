using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTRACSHARPHIT
{
    internal class Mage:Character
    {
        public override void UseAbility()
        {
            base.UseAbility();
            Console.Write(Name + " niệm Chú Ngủ!");
        }
    }
}
