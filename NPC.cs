using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BruffGame
{
    class NPC
    {
        public int Strength { get; set; }
        public int MinDamage { get; set; }
        public int Health { get; set; }
        public bool Killable { get; set; }
        public Weapon EquippedWeapon { get; set; }
        public Armor EquippedArmor { get; set; }
        public Dictionary<string,string> ChatReferences { get; set; }
        public string Name { get; set; }
        public int ExpReward { get; set; }
        public string Intro { get; set; }
        public string Treasure { get; set; }
        public string DeathMessage { get; set; }
        public NPC()
        {
            ChatReferences = new Dictionary<string, string>();
            ChatReferences.Add("0: Exit Conversation", "You nod and turn away.");
            DeathMessage = "R.I.P.";
        }
    }
}
