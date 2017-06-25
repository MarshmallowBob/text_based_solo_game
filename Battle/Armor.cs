using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BruffGame
{
    class Armor
    {
        public double DamageMultiplier { get; set; }
        public string Name { get; set; }
        public Armor()
        {
            DamageMultiplier = 1.5;
            Name = "Loincloth";
        }
        public Armor(string n, double damage)
        {
            DamageMultiplier = damage;
            Name = n;
        }
    }
}
