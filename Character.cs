using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BruffGame
{
    class Character
    {
        public string Name { get; set; }
        public int MaxHealth { get; set; }
        public int MaxMana { get; set; }
        public int Health { get; set; }
        public int Mana { get; set; }
        public int Level { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int XP { get; set; }
        public int XPForNext { get; set; }
        public Weapon EquippedWeapon { get; set; }
        public Armor EquippedArmor { get; set; }
        public Room CurrentRoom { get; set; }
        public List<string> Inventory { get; set; }
        public List<Spell> Spells { get; set; }
        public Character()
        {
            MaxHealth = 100;
            MaxMana = 100;
            Health = 100;
            Mana = 100;
            XPForNext = 100;
            Level = 1;
            Attack = 1;
            Defense = 1;
            Name = "Mr. Default (why not Ms. Default!?)";
            Inventory = new List<string>();
            Inventory.Add("health potion");
            Inventory.Add("health potion");
            Inventory.Add("mana potion");
            Spells = new List<Spell>();
            Spells.Add(new Spell
            {
                MinDamage = 1,
                MaxDamage = 3,
                Cost = 5,
                Name = "Missile",
                Desc = "Fires a tiny little missile made of magic, just big enough to kill your average-sized cricket.",
                SelfCast = false
            });
            EquippedWeapon = new Weapon();
            EquippedArmor = new Armor();
        }
        public void MoveRoom(int rID)
        {
            foreach(var room in Game.GAME_ROOMS)
            {
                if(room.ID==rID)
                {
                    CurrentRoom = room;
                    Game.Message(CurrentRoom.Intro);
                    foreach (var enemy in CurrentRoom.KillableList)
                    {
                        Game.Message(enemy.Intro + "\n");
                    }
                    foreach (var item in CurrentRoom.GettableList)
                    {
                        Game.Message(item.Value + "\n");
                    }

                    foreach (var entry in CurrentRoom.TalkableList)
                        Game.Message(entry.Intro+"\n");
                }
            }
        }
        internal bool Damage(int d)
        {
            Health = Health - d;
            if (Health < 1)
            {
                YerDead();
                return false;
            }
            return true;
        }
        private void YerDead()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Game.Message("You have died. Your corpse is immediately looted by local thieves and left to rot in the sun.");
            Game.Message("   ______       _       ____    ____  ________        ___   ____   ____  ________  _______     ");
            Game.Message(" .' ___  |     / \\     |_   \\  /   _||_   __  |     .'   `.|_  _| |_  _||_   __  ||_   __ \\    ");
            Game.Message("/ .'   \\_|    / _ \\      |   \\/   |    | |_ \\_|    /  .-.  \\ \\ \\   / /    | |_ \\_|  | |__) |   ");
            Game.Message("| |   ____   / ___ \\     | |\\  /| |    |  _| _     | |   | |  \\ \\ / /     |  _| _   |  __ /    ");
            Game.Message("\\ `.___]  |_/ /   \\ \\_  _| |_\\/_| |_  _| |__/ |    \\  `-'  /   \\ ' /     _| |__/ | _| |  \\ \\_  ");
            Game.Message(" `._____.'|____| |____||_____||_____||________|     `.___.'     \\_/     |________||____| |___| ");
            Console.Beep(658, 125);
            Console.Beep(1320, 500);
            Console.Beep(990, 250);
            Console.Beep(1056, 250);
            Console.Beep(1188, 250);
            Console.Beep(1320, 125);
            Console.Beep(1188, 125);
            Console.Beep(1056, 250);
            Console.Read();
            Environment.Exit(0);
        }
    }
}
