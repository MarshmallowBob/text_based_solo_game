using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BruffGame
{
    class Spell
    {
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }
        public bool SelfCast { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public string Desc { get; set; }
    }
}
