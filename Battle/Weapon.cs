using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BruffGame
{
    class Weapon
    {
        public double DamageMultiplier { get; set; }
        public string Name { get; set; }
        public string HitVerb { get; set; }
        public Weapon()
        {
            DamageMultiplier = 0.5;
            Name = "fist";
            HitVerb = "punch";
        }
        public Weapon(string n, double damage)
        {
            DamageMultiplier = damage;
            Name = n;
        }
    }

}
