using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BruffGame
{
    class Game
    {
        /// <summary>
        ///     Writes the specified data, followed by the current line terminator, to the standard output stream, while wrapping lines that would otherwise break words.
        /// </summary>
        /// <param name="paragraph">The value to write.</param>
        /// <param name="tabSize">The value that indicates the column width of tab characters.</param>
        public static void Message(string paragraph, int tabSize = 8)
        {
            string[] lines = paragraph
                .Replace("\t", new String(' ', tabSize))
                .Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            for (int i = 0; i < lines.Length; i++)
            {
                string process = lines[i];
                List<String> wrapped = new List<string>();

                while (process.Length > Console.WindowWidth)
                {
                    int wrapAt = process.LastIndexOf(' ', Math.Min(Console.WindowWidth - 1, process.Length));
                    if (wrapAt <= 0) break;

                    wrapped.Add(process.Substring(0, wrapAt));
                    process = process.Remove(0, wrapAt + 1);
                }

                foreach (string wrap in wrapped)
                {
                    Console.WriteLine(wrap);
                }

                Console.WriteLine(process);
            }
        }
        public static List<Room> GAME_ROOMS { get; set; }
        public static void StartGame(Character c)
        {
            Console.SetWindowSize(150, 50);
            Console.ForegroundColor = ConsoleColor.Red;
            Message("");
            Message("");
            Message("");
            Message("");
            Console.WriteLine(" ▄▄▄▄    ██▀███   █    ██   █████▒ █████▒▓█████▓██   ██▓  ██████     ▄▄▄      ▓█████▄  ██▒   █▓▓█████  ███▄    █ ▄▄▄█████▓ █    ██  ██▀███  ▓█████ ");
            Console.WriteLine("▓█████▄ ▓██ ▒ ██▒ ██  ▓██▒▓██   ▒▓██   ▒ ▓█   ▀ ▒██  ██▒▒██    ▒    ▒████▄    ▒██▀ ██▌▓██░   █▒▓█   ▀  ██ ▀█   █ ▓  ██▒ ▓▒ ██  ▓██▒▓██ ▒ ██▒▓█   ▀ ");
            Console.WriteLine("▒██▒ ▄██▓██ ░▄█ ▒▓██  ▒██░▒████ ░▒████ ░ ▒███    ▒██ ██░░ ▓██▄      ▒██  ▀█▄  ░██   █▌ ▓██  █▒░▒███   ▓██  ▀█ ██▒▒ ▓██░ ▒░▓██  ▒██░▓██ ░▄█ ▒▒███   ");
            Console.WriteLine("▒██░█▀  ▒██▀▀█▄  ▓▓█  ░██░░▓█▒  ░░▓█▒  ░ ▒▓█  ▄  ░ ▐██▓░  ▒   ██▒   ░██▄▄▄▄██ ░▓█▄   ▌  ▒██ █░░▒▓█  ▄ ▓██▒  ▐▌██▒░ ▓██▓ ░ ▓▓█  ░██░▒██▀▀█▄  ▒▓█  ▄ ");
            Console.WriteLine("░▓█  ▀█▓░██▓ ▒██▒▒▒█████▓ ░▒█░   ░▒█░    ░▒████▒ ░ ██▒▓░▒██████▒▒    ▓█   ▓██▒░▒████▓    ▒▀█░  ░▒████▒▒██░   ▓██░  ▒██▒ ░ ▒▒█████▓ ░██▓ ▒██▒░▒████▒");
            Console.WriteLine("░▒▓███▀▒░ ▒▓ ░▒▓░░▒▓▒ ▒ ▒  ▒ ░    ▒ ░    ░░ ▒░ ░  ██▒▒▒ ▒ ▒▓▒ ▒ ░    ▒▒   ▓▒█░ ▒▒▓  ▒    ░ ▐░  ░░ ▒░ ░░ ▒░   ▒ ▒   ▒ ░░   ░▒▓▒ ▒ ▒ ░ ▒▓ ░▒▓░░░ ▒░ ░");
            Console.WriteLine("▒░▒   ░   ░▒ ░ ▒░░░▒░ ░ ░  ░      ░       ░ ░  ░▓██ ░▒░ ░ ░▒  ░ ░     ▒   ▒▒ ░ ░ ▒  ▒    ░ ░░   ░ ░  ░░ ░░   ░ ▒░    ░    ░░▒░ ░ ░   ░▒ ░ ▒░ ░ ░  ░");
            Console.WriteLine(" ░    ░   ░░   ░  ░░░ ░ ░  ░ ░    ░ ░       ░   ▒ ▒ ░░  ░  ░  ░       ░   ▒    ░ ░  ░      ░░     ░      ░   ░ ░   ░       ░░░ ░ ░   ░░   ░    ░   ");
            Console.WriteLine(" ░         ░        ░                       ░  ░░ ░           ░           ░  ░   ░          ░     ░  ░         ░             ░        ░        ░  ░");
            Console.WriteLine("      ░                                         ░ ░                            ░           ░                                                       ");
            Console.WriteLine("           █████   █    ██ ▓█████   ██████ ▄▄▄█████▓     █████▒▒█████   ██▀███      ▄▄▄██▀▀▀█    ██   ██████ ▄▄▄█████▓ ██▓ ▄████▄  ▓█████       ");
            Console.WriteLine("         ▒██▓  ██▒ ██  ▓██▒▓█   ▀ ▒██    ▒ ▓  ██▒ ▓▒   ▓██   ▒▒██▒  ██▒▓██ ▒ ██▒      ▒██   ██  ▓██▒▒██    ▒ ▓  ██▒ ▓▒▓██▒▒██▀ ▀█  ▓█   ▀       ");
            Console.WriteLine("         ▒██▒  ██░▓██  ▒██░▒███   ░ ▓██▄   ▒ ▓██░ ▒░   ▒████ ░▒██░  ██▒▓██ ░▄█ ▒      ░██  ▓██  ▒██░░ ▓██▄   ▒ ▓██░ ▒░▒██▒▒▓█    ▄ ▒███         ");
            Console.WriteLine("         ░██  █▀ ░▓▓█  ░██░▒▓█  ▄   ▒   ██▒░ ▓██▓ ░    ░▓█▒  ░▒██   ██░▒██▀▀█▄     ▓██▄██▓ ▓▓█  ░██░  ▒   ██▒░ ▓██▓ ░ ░██░▒▓▓▄ ▄██▒▒▓█  ▄       ");
            Console.WriteLine("         ░▒███▒█▄ ▒▒█████▓ ░▒████▒▒██████▒▒  ▒██▒ ░    ░▒█░   ░ ████▓▒░░██▓ ▒██▒    ▓███▒  ▒▒█████▓ ▒██████▒▒  ▒██▒ ░ ░██░▒ ▓███▀ ░░▒████▒      ");
            Console.WriteLine("         ░░ ▒▒░ ▒ ░▒▓▒ ▒ ▒ ░░ ▒░ ░▒ ▒▓▒ ▒ ░  ▒ ░░       ▒ ░   ░ ▒░▒░▒░ ░ ▒▓ ░▒▓░    ▒▓▒▒░  ░▒▓▒ ▒ ▒ ▒ ▒▓▒ ▒ ░  ▒ ░░   ░▓  ░ ░▒ ▒  ░░░ ▒░ ░      ");
            Console.WriteLine("          ░ ▒░  ░ ░░▒░ ░ ░  ░ ░  ░░ ░▒  ░ ░    ░        ░       ░ ▒ ▒░   ░▒ ░ ▒░    ▒ ░▒░  ░░▒░ ░ ░ ░ ░▒  ░ ░    ░     ▒ ░  ░  ▒    ░ ░  ░      ");
            Console.WriteLine("            ░   ░  ░░░ ░ ░    ░   ░  ░  ░    ░          ░ ░   ░ ░ ░ ▒    ░░   ░     ░ ░ ░   ░░░ ░ ░ ░  ░  ░    ░       ▒ ░░           ░         ");
            Console.WriteLine("             ░       ░        ░  ░      ░                         ░ ░     ░         ░   ░     ░           ░            ░  ░ ░         ░  ░      ");
            Console.WriteLine("             ░       ░        ░  ░      ░                         ░ ░     ░         ░   ░     ░           ░            ░  ░ ░         ░  ░      ");
            Console.WriteLine("             ░       ░        ░  ░      ░                         ░ ░     ░         ░   ░     ░           ░            ░  ░ ░         ░  ░      ");
            Message("");
            Message("");
            Message("");
            Message("");
            Message("                                                               PRESS ANY KEY TO PLAY                                                            ");
            Message("");
            Message("");
            Message("");
            Console.ReadKey();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            NameCharacter(c);
            Message("");
            GenerateRoomsFromJSON();
            c.MoveRoom(0);
        }

        private static void GenerateRoomsFromJSON()
        {
            GAME_ROOMS = new List<Room>();
            var fileLoc = ConfigurationManager.AppSettings["JSONLocation"];
            var json = File.ReadAllText(fileLoc);
            JObject roomsList = JObject.Parse(json);
            JToken rooms = roomsList["rooms"];
            foreach (var room in rooms)
            {
                Room cur = new Room();
                cur.ID = (int)room["ID"];
                cur.Intro = (string)room["Intro"];
                try
                {
                    cur.North = (int)room["North"];
                }
                catch
                {
                    cur.North = -1;
                }
                try
                {
                    cur.East = (int)room["East"];
                }
                catch
                {
                    cur.East = -1;
                }
                try
                {
                    cur.West = (int)room["West"];
                }
                catch
                {
                    cur.West = -1;
                }
                try
                {
                    cur.South = (int)room["South"];
                }
                catch
                {
                    cur.South = -1;
                }
                if(room["ReadableList"]!=null)
                    cur.ReadableList = JsonConvert.DeserializeObject<Dictionary<string,string>>(room["ReadableList"].ToString());
                if (room["KillableList"] != null)
                    cur.KillableList = JsonConvert.DeserializeObject<List<NPC>>(room["KillableList"].ToString());
                if (room["GettableList"] != null)
                    cur.GettableList = JsonConvert.DeserializeObject<Dictionary<string, string>>(room["GettableList"].ToString());
                if (room["TalkableList"] != null)
                    cur.TalkableList = JsonConvert.DeserializeObject<List<NPC>>(room["TalkableList"].ToString());

                GAME_ROOMS.Add(cur);
            }
        }

        public static void Command(string com, Character c)
        {
            Message("");
            var ran = new Random();
            var tmp = 0;
            com = com.ToLower();
            string comShort;
            if (com.Length > 4)
                comShort = com.Substring(0, 4);
            else comShort = com;
            switch (comShort)
            {
                case "help":
                    Message("Rooms will usually list commands you can do or stuff you can interact with in all caps as you enter.");
                    Message("Below is a list of valid commands: ");
                    Message("stats:    Examine your current level, health, mana, attack, defense, and Experience points.");
                    Message("look:     Looks at the room you're currently in, and tells you what directions you can exit.");
                    Message("inv:      Shows you your inventory.");
                    Message("eq:       Shows you your currently equipped items, which add to your stats.");
                    Message("wear X:   Put on or wield X item. Will automatically remove any item equipped in that slot.");
                    Message("n,s,e,w:  Type n, s, e, or w to move North, South, East, or West.");
                    Message("view X:   Examines X NPC in the room, whether it's a monster or a helpful friend. Reveals their stats and equipment.");
                    Message("hit X:    Performs a basic attack against X enemy in the room. Type the enemy's name.");
                    Message("spells:   Tells you the spells you're able to cast.");
                    Message("cast X Y: Cast X spell on Y target. Type the name of the spell and the name of the target.");
                    Message("quaff X:  Drink X potion that's in your inventory. Typically 'health', 'mana', or 'damage'.");
                    Message("read X:   Reads X in the room. Usually a sign, plaque, etc.");
                    Message("get X:    Gets X, referencing some item in the room.");
                    Message("talk X:   Talk to X, referencing some person in the room. Not everyone can be talked to.");
                    break;
                case "quaf":
                    if (com.Split(' ').Length < 2)
                    {
                        Message("You must specify a potion to quaff, like this: quaff health\n");
                        return;
                    }
                    var whatWeQuaffin = com.Split(' ')[1].ToLower();
                    QuaffPotion(c, whatWeQuaffin);

                    break;

                case "cast":
                    if(com.Split(' ').Length < 3)
                    {
                        Message("You must specify a target for your spell, like this: cast missile rat\n");
                        return;
                    }
                    var whatWeCasting = com.Split(' ')[1].ToLower();
                    var whatWeKilling = com.Split(' ')[2].ToLower();
                    var foundNPC = false;
                    var NPCToRemove = new NPC();
                    var talkingNPCToRemove = new NPC();
                    foreach (var npc in c.CurrentRoom.TalkableList)
                    {
                        if(npc.Name.ToLower()!=whatWeKilling) continue;
                        else
                        {
                            talkingNPCToRemove = npc;
                            break;
                        }
                    }
                    foreach (var npc in c.CurrentRoom.KillableList)
                    {
                        if (npc.Name.ToLower() != whatWeKilling) continue;
                        foundNPC = true;
                        NPCToRemove = npc;
                        var foundSpell = false;
                        foreach(var spell in c.Spells)
                        {
                            if(spell.Name.ToLower()==whatWeCasting)
                            {
                                if(c.Mana<spell.Cost)
                                {
                                    Message("You don't have enough mana to cast that!");
                                    return;
                                }
                                BattleLoop(c, npc, spell);
                                foundSpell = true;
                                break;
                            }
                        }
                        if (!foundSpell)
                        {
                            Message("You don't have that spell available to cast.");
                        }
                        break;
                    }
                    if (!foundNPC)
                    {
                        tmp = ran.Next(0, 5);
                        switch (tmp)
                        {
                            case 0: Message("You try to hit it, but you realize it's not there."); break;
                            case 1: Message("Nobody by that name here can be attacked."); break;
                            case 2: Message("Are you crazy!? You can't attack that!"); break;
                            case 3: Message("Not a possible action at this time."); break;
                            case 4: Message("Let me check on that...nope, not possible."); break;
                        }
                    }
                    else
                    {
                        c.CurrentRoom.KillableList.Remove(NPCToRemove);
                        c.CurrentRoom.TalkableList.Remove(talkingNPCToRemove);
                    }
                    break;
                case "view":
                    var whatWeExamining = com.Split(' ')[1].ToLower();
                    var foundEnemy = false;
                    foreach (var entry in c.CurrentRoom.KillableList)
                    {
                        if (entry.Name.ToLower()==whatWeExamining)
                        {
                            foundEnemy = true;
                            var verbNum = ran.Next(0, 5);
                            var verb = "";
                            switch (verbNum)
                            {
                                case 0:
                                    verb = "with disdain";
                                    break;
                                case 1:
                                    verb = "hatefully";
                                    break;
                                case 2:
                                    verb = "with blood red eyes";
                                    break;
                                case 3:
                                    verb = "with an evil grin";
                                    break;
                                case 4:
                                    verb = "devilishly";
                                    break;
                            }
                            Game.Message("The " + entry.Name + " stares at you " + verb + ".");
                            Game.Message("The " + entry.Name + " is wielding " + entry.EquippedWeapon.Name);
                            Game.Message("And is using " + entry.EquippedArmor.Name + " as armor.");
                            Game.Message("Health: " + entry.Health);
                            break;
                        }
                    }
                    if(!foundEnemy)
                    {
                        int randomNumber = ran.Next(0, 5);
                        switch (randomNumber)
                        {
                            case 0: Message("There's nothing by that name you can examine here."); break;
                            case 1: Message("Have you gone mad? There is nothing called that here."); break;
                            case 2: Message("I don't think you can examine that."); break;
                            case 3: Message("You attempt to examine it, but you realize it's just a figment of your imagination."); break;
                            case 4: Message("That may be here inside your mind, but unfortunately, there's nothing called that in the room."); break;
                        }
                    }
                    break;
                case "stat":
                    Message(string.Format("Hello, {0}, here are your current stats:", c.Name));
                    Message(string.Format("Current Level:      {0}", c.Level));
                    Message(string.Format("Current Health:     {0} out of {1}", c.Health, c.MaxHealth));
                    Message(string.Format("Current Mana:       {0} out of {1}", c.Mana, c.MaxMana));
                    Message(string.Format("Attack Bonus:       {0}", c.Attack));
                    Message(string.Format("Defense Bonus:      {0}", c.Defense));
                    Message(string.Format("Current EXP:        {0}", c.XP));
                    Message(string.Format("EXP for Next Level: {0}", c.XPForNext-c.XP));
                    break;
                case "eq":
                    Message(string.Format("Equipped Weapon: {0}, which gives you an attack bonus of {1}", c.EquippedWeapon.Name, c.EquippedWeapon.DamageMultiplier));
                    Message(string.Format("Equipped Armor: {0}, which gives you a defense bonus of {1}",c.EquippedArmor.Name,c.EquippedArmor.DamageMultiplier));
                    break;
                case "look":
                    Message(c.CurrentRoom.Intro);
                    foreach (var entry in c.CurrentRoom.KillableList)
                        Message(entry.Intro + "\n");
                    foreach (var entry in c.CurrentRoom.GettableList)
                        Message(entry.Value + "\n");
                    foreach (var entry in c.CurrentRoom.TalkableList)
                        Message(entry.Intro + "\n");
                    break;
                case "read":
                    if (com.Split(' ').Length < 2)
                    {
                        Message("You have to specify what you want to read, like this: read plaque");
                        return;
                    }
                    var whatWeReading = com.Split(' ')[1].ToLower();
                    if (c.CurrentRoom.ReadableList.ContainsKey(whatWeReading))
                    {
                        Message(c.CurrentRoom.ReadableList[whatWeReading]);
                    }
                    else
                    {
                        int randomNumber = ran.Next(0, 5);
                        switch (randomNumber)
                        {
                            case 0: Message("There's nothing by that name you can read here."); break;
                            case 1: Message("Have you gone mad? There is nothing called that here."); break;
                            case 2: Message("I don't think you can read that."); break;
                            case 3: Message("You attempt to read it, but there are no words to read."); break;
                            case 4: Message("That may be here inside your mind, but unfortunately, there's nothing called that in the room."); break;
                        }
                    }
                    break;
                case "get ":
                    if (com.Split(' ').Length < 2)
                    {
                        Message("You have to specify what you want to get, like this: get flask");
                        return;
                    }
                    var whatWeGetting = com.Split(' ')[1].ToLower();
                    if (c.CurrentRoom.GettableList.ContainsKey(whatWeGetting))
                    {
                        Message("You pick up the "+ whatWeGetting +" and shove it in your pocket.");
                        c.Inventory.Add(whatWeGetting);
                        c.CurrentRoom.GettableList.Remove(whatWeGetting);
                    }
                    else
                    {
                        int randomNumber = ran.Next(0, 5);
                        switch (randomNumber)
                        {
                            case 0: Message("There's nothing by that name you can read here."); break;
                            case 1: Message("Have you gone mad? There is nothing called that here."); break;
                            case 2: Message("I don't think you can read that."); break;
                            case 3: Message("You attempt to read it, but there are no words to read."); break;
                            case 4: Message("That may be here inside your mind, but unfortunately, there's nothing called that in the room."); break;
                        }
                    }
                    break;

                case "wear":
                    var whatWeWearing = com.Split(' ')[1].ToLower();
                    var found = false;
                    foreach (var i in c.Inventory)
                    {
                        if (i == whatWeWearing)
                        {
                            found = true;
                            c.Inventory.Remove(i);
                            switch (whatWeWearing)
                            {
                                case "grass":
                                    c.EquippedArmor = new Armor() { Name = "Grass Armor", DamageMultiplier = 1.4 };
                                    break;
                                case "wooden":
                                    c.EquippedArmor = new Armor() { Name = "Wooden Armor", DamageMultiplier = 1.3 };
                                    break;
                                case "bronze":
                                    c.EquippedArmor = new Armor() { Name = "Bronze Armor", DamageMultiplier = 1.2 };
                                    break;
                                case "iron":
                                    c.EquippedArmor = new Armor() { Name = "Golden Armor", DamageMultiplier = 0.9 };
                                    break;
                                case "platinum":
                                    c.EquippedArmor = new Armor() { Name = "Platinum Armor", DamageMultiplier = 0.8 };
                                    break;
                                case "diamond":
                                    c.EquippedArmor = new Armor() { Name = "Diamond Armor", DamageMultiplier = 0.4 };
                                    break;
                                case "stick":
                                    c.EquippedWeapon = new Weapon() { Name = "Broken, Old Stick", DamageMultiplier = 0.6, HitVerb="poke"};
                                    break;
                                case "brick":
                                    c.EquippedWeapon = new Weapon() { Name = "Crumbling Brick", DamageMultiplier = 0.7, HitVerb="bash" };
                                    break;
                                case "spear":
                                    c.EquippedWeapon = new Weapon() { Name = "Spear of Azeroth", DamageMultiplier = 1.1, HitVerb="gouge"};
                                    break;
                                case "scythe":
                                    c.EquippedWeapon = new Weapon() { Name = "Gnarly, Serrated Scythe", DamageMultiplier = 1.2, HitVerb="slash"};
                                    break;
                                case "dirk":
                                    c.EquippedWeapon = new Weapon() { Name = "Poison-Tipped Dirk", DamageMultiplier = 1.4, HitVerb = "stab"};
                                    break;
                                case "falchion":
                                    c.EquippedWeapon = new Weapon() { Name = "Falchion Made from the Finest Steel", DamageMultiplier = 2.0, HitVerb="bifurcate"};
                                    break;
                                default:
                                    found = false; break;
                            }
                            break;
                        }
                    }
                    if (!found)
                    {
                        Random random = new Random();
                        int randomNumber = random.Next(0, 5);
                        switch (randomNumber)
                        {
                            case 0: Message("There's nothing by that name you can wear in your inventory."); break;
                            case 1: Message("Have you gone mad? You can't wear that item!"); break;
                            case 2: Message("I don't think you can wear that."); break;
                            case 3: Message("Unfortunately, you're unable to wear figments of your imagination."); break;
                            case 4: Message("That item is not wearable."); break;
                        }
                    }
                    break;
                case "inv":
                    if (c.Inventory.Count < 1) Message("You are carrying nothing.");
                    else
                    {
                        Message("You're currently carrying:");
                        foreach (var item in c.Inventory)
                        {
                            Message(item.ToUpper());
                        }
                    }
                    break;
                case "spel":
                    if (c.Spells.Count < 1) Message("You don't know any spells.");
                    else
                    {
                        Message("You're currently able to cast:");
                        foreach (var spell in c.Spells)
                        {
                            Message(spell.Name.ToUpper() + ": " + spell.Desc);
                        }
                    }
                    break;
                case "n":
                    if (c.CurrentRoom.North != -1)
                    {
                        c.MoveRoom(c.CurrentRoom.North);
                    }
                    else
                    {
                        tmp = ran.Next(0, 5);
                        switch (tmp)
                        {
                            case 0: Message("You try to go north, but you run face first into a wall."); break;
                            case 1: Message("You look to the north for a way to exit, but alas, there is no way out in this direction."); break;
                            case 2: Message("Maybe you should LOOK again, there's no exit to the north."); break;
                            case 3: Message("Not a possible action at this time."); break;
                            case 4: Message("Let me check on that...nope, not possible."); break;
                        }
                    }
                    break;
                case "s":
                    if (c.CurrentRoom.South != -1)
                    {
                        c.MoveRoom(c.CurrentRoom.South);
                    }
                    else
                    {
                        tmp = ran.Next(0, 5);
                        switch (tmp)
                        {
                            case 0: Message("You try to go south, but you run face first into a wall."); break;
                            case 1: Message("You look to the south for a way to exit, but alas, there is no way out in this direction."); break;
                            case 2: Message("Maybe you should LOOK again, there's no exit to the south."); break;
                            case 3: Message("Not a possible action at this time."); break;
                            case 4: Message("Let me check on that...nope, not possible."); break;
                        }
                    }
                    break;
                case "e":
                    if (c.CurrentRoom.ID==0)
                    {
                        if(c.Level<5)
                        {
                            Message("The priest stops you from going to the East. \"I implore you, do not travel East in your current condition. Head NORTH first to hone your skills.\"");
                        }
                    }
                    else if (c.CurrentRoom.East != -1)
                    {
                        c.MoveRoom(c.CurrentRoom.East);
                    }
                    else
                    {
                        tmp = ran.Next(0, 5);
                        switch (tmp)
                        {
                            case 0: Message("You try to go East, but you run face first into a wall."); break;
                            case 1: Message("You look to the East for a way to exit, but alas, there is no way out in this direction."); break;
                            case 2: Message("Maybe you should LOOK again, there's no exit to the East."); break;
                            case 3: Message("Not a possible action at this time."); break;
                            case 4: Message("Let me check on that...nope, not possible."); break;
                        }
                    }
                    break;
                case "w":
                    if (c.CurrentRoom.West != -1)
                    {
                        c.MoveRoom(c.CurrentRoom.West);
                    }
                    else
                    {
                        tmp = ran.Next(0, 5);
                        switch (tmp)
                        {
                            case 0: Message("You try to go West, but you run face first into a wall."); break;
                            case 1: Message("You look to the West for a way to exit, but alas, there is no way out in this direction."); break;
                            case 2: Message("Maybe you should LOOK again, there's no exit to the West."); break;
                            case 3: Message("Not a possible action at this time."); break;
                            case 4: Message("Let me check on that...nope, not possible."); break;
                        }
                    }
                    break;
                case "talk":
                    if (com.Split(' ').Length < 2)
                    {
                        Message("You must specify who you want to talk to, like this: talk priest");
                        return;
                    }
                    var whoWeTalking = com.Split(' ')[1].ToLower();
                    foundNPC = false;
                    foreach (var npc in c.CurrentRoom.TalkableList)
                    {
                        if (npc.Name.ToLower() != whoWeTalking) continue;
                        foundNPC = true;
                        NPCToRemove = npc;
                        InteractionLoop(npc);
                        break;
                    }
                    if (!foundNPC)
                    {
                        tmp = ran.Next(0, 5);
                        switch (tmp)
                        {
                            case 0: Message("You try to hit it, but you realize it's not there."); break;
                            case 1: Message("Nobody by that name here can be attacked."); break;
                            case 2: Message("Are you crazy!? You can't attack that!"); break;
                            case 3: Message("Not a possible action at this time."); break;
                            case 4: Message("Let me check on that...nope, not possible."); break;
                        }

                    }
                    break;

                case "hit ":
                    if (com.Split(' ').Length < 2)
                    {
                        Message("You must specify what you want to hit, like this: hit rat");
                        return;
                    }
                    var whoWeHitting = com.Split(' ')[1].ToLower();
                    foundNPC = false;
                    NPCToRemove = new NPC();
                    talkingNPCToRemove = new NPC();
                    foreach(var npc in c.CurrentRoom.TalkableList)
                    {
                        if (npc.Name.ToLower() != whoWeHitting) continue;
                        talkingNPCToRemove = npc;
                        break;
                    }
                    foreach (var npc in c.CurrentRoom.KillableList)
                    {
                        if (npc.Name.ToLower() != whoWeHitting) continue;
                        foundNPC = true;
                        NPCToRemove = npc;
                        BattleLoop(c, npc);
                        break;
                    }
                    if (!foundNPC)
                    {
                        tmp = ran.Next(0, 5);
                        switch (tmp)
                        {
                            case 0: Message("You try to hit it, but you realize it's not there."); break;
                            case 1: Message("Nobody by that name here can be attacked."); break;
                            case 2: Message("Are you crazy!? You can't attack that!"); break;
                            case 3: Message("Not a possible action at this time."); break;
                            case 4: Message("Let me check on that...nope, not possible."); break;
                        }

                    }
                    else
                    {
                        c.CurrentRoom.KillableList.Remove(NPCToRemove);
                        c.CurrentRoom.TalkableList.Remove(talkingNPCToRemove);
                    }
                    break;
                default:
                    tmp = ran.Next(0, 5);
                    switch (tmp)
                    {
                        case 0: Message("Invalid command."); break;
                        case 1: Message("I'm afraid you can't do that."); break;
                        case 2: Message("What?"); break;
                        case 3: Message("Not a possible action at this time."); break;
                        case 4: Message("Let me check on that...nope, not possible."); break;
                    }
                    break;


            }
            Message("");
        }

        private static void InteractionLoop(NPC npc)
        {
            foreach(var chat in npc.ChatReferences)
            {
                Message(chat.Key);
            }
            var answer = "";
            while(answer!="0")
            {
                Message("\nWhat do you ask of the " + npc.Name + "? Enter just the number before the response.");
                answer = Console.ReadLine();
                var found = false;
                foreach(var chat in npc.ChatReferences)
                {
                    var number = chat.Key.Substring(0, 1);
                    if(number==answer)
                    {
                        Message(chat.Value);
                        found = true;
                    }
                }
                if (!found)
                    Message("You can't ask that. Try typing one of the numbers listed.");
            }
        }

        private static void QuaffPotion(Character c, string whatWeQuaffin)
        {

            string toRemove = "";
            foreach (var item in c.Inventory)
            {
                if (item.ToLower().Split(' ')[0] == whatWeQuaffin)
                {
                    if (whatWeQuaffin == "health")
                    {
                        if (c.Health == c.MaxHealth)
                        {
                            Message("\nYou already have maximum health, so you don't drink the potion as to not waste it.\n");
                            return;
                        }
                        toRemove = item;
                        Message("\nYou chug the health potion, gaining 50 HP.\n");
                        c.Health += 50;
                        if (c.Health > c.MaxHealth) c.Health = c.MaxHealth;
                    }
                    if (whatWeQuaffin == "mana")
                    {
                        if (c.Mana == c.MaxMana)
                        {
                            Message("\nYou already have maximum mana, so you put the potion back in your pocket and save it for later.\n");
                            return;
                        }
                        toRemove = item;
                        Message("\nYou chug the mana potion, gaining 50 MP.\n");
                        c.Mana += 50;
                        if (c.Mana > c.MaxMana) c.Mana = c.MaxMana;
                    }
                    break;
                }
            }
            if(toRemove=="")
            {
                Message("\nYou don't have a potion by that name!\n");
            }
            else
                c.Inventory.Remove(toRemove);
        }

        static void NameCharacter(Character c)
        {
            Message("Choose a name: ");
            c.Name = Console.ReadLine();
            Message(String.Format("Welcome to the temple, {0}. You must complete all 8 trials to obtain fragments that restore the key that unlocks the Righteous Chest.\n", c.Name));
            Message("Next to your command input, you'll see (H: XXX, M: XXX) which indicates your current health and mana.\n");
            Message("If your health reaches 0, you will die. If your mana reaches 0, you'll be temporarily unable to cast spells.\n");
            Message("If you need assistance at any time, just type \"help\".\n");
        }
        static void BattleLoop(Character c, NPC n, Spell s = null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            var rand = new Random();
            while (n.Health > 0 && c.Health > 0)
            {
                if(s!=null)
                {
                        c.Mana -= s.Cost;
                        var spellDamage = rand.Next(s.MinDamage, s.MaxDamage);
                        n.Health -= spellDamage;
                        Message("\nYou blast the " + n.Name + " with a magic " + s.Name + ", ouch! It deals " + spellDamage + " damage! He now has " + n.Health + " health.");
                }
                var charHit = (int)Math.Ceiling(((rand.Next(1, 11)+c.Attack) * c.EquippedWeapon.DamageMultiplier)*n.EquippedArmor.DamageMultiplier);
                var npcHit = (int)Math.Ceiling(((rand.Next(n.MinDamage, n.Strength)-(c.Defense*.1))* n.EquippedWeapon.DamageMultiplier)*c.EquippedArmor.DamageMultiplier);
                n.Health -= charHit;
                Message("\nYou " + c.EquippedWeapon.HitVerb + " the " + n.Name + " for " + charHit + " damage, leaving them with " + n.Health + " remaining life.");
                if (n.Health < 1) break;
                Message("The " + n.Name + " hits you with a " + n.EquippedWeapon.HitVerb + ", dealing " + npcHit + " damage!\n");
                c.Damage(npcHit);
                var tmp = true;
                while (tmp)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("HIT, QUAFF [POTION], or CAST [SPELL], {0}? (H: {1}, M: {2}): ", c.Name, c.Health, c.Mana);
                    Console.ForegroundColor = ConsoleColor.Red;
                    var answer = Console.ReadLine();
                    switch (answer.ToString().Split(' ')[0].ToLower())
                    {
                        case "hit":
                            tmp = false;
                            s = null;
                            break;
                        case "cast":
                            if (answer.ToString().Split(' ').Length > 1)
                            {
                                var foundSpell = false;
                                var spellName = answer.ToString().Split(' ')[1];
                                foreach (var spell in c.Spells)
                                {
                                    if (spell.Name.ToLower() == spellName)
                                    {
                                        foundSpell = true;
                                        if (c.Mana < spell.Cost)
                                            Message("\nYour spell fizzles into dust as it leaves your hands. You don't have enough mana!\n");
                                        else
                                        {
                                            s = spell;
                                            tmp = false;
                                        }
                                        break;
                                    }
                                }
                                if (!foundSpell)
                                {
                                    Message("\nYou don't have that spell available to cast.\n");
                                }
                            }
                            else
                                Message("\nCast what? You have to name a spell.\n");
                            break;
                        case "quaff":
                            if (answer.ToString().Split(' ').Length < 2)
                            {
                                Message("\nYou must specify a potion to quaff, like this: quaff health\n");
                                continue;
                            }
                            var whatWeQuaffin = answer.ToString().Split(' ')[1].ToLower();
                            QuaffPotion(c, whatWeQuaffin);
                            break;
                        default:
                            Message("\nWhat!?\n");
                            break;
                    }
                }
            }
            Message("The " + n.Name + " is DEAD! "+n.DeathMessage+" You get " + n.ExpReward + " experience point(s).\n");
            if (n.Treasure != null && n.Treasure != "")
            {
                var treasure = n.Treasure.Split(',');
                Message("You also find some loot on your enemy's corpse:");
                foreach(var item in treasure)
                {
                    Message(item.ToUpper());
                    c.Inventory.Add(item);
                }
            }
            c.XP += n.ExpReward;
            if (c.XP > c.XPForNext)
                LevelUp(c);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void LevelUp(Character c)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Message("Congratulations! You've leveled UP!\nYour HEALTH and MANA have been fully restored.\n\n");
            c.Level += 1;
            var r = new Random();
            var healthUp = (int)Math.Ceiling(r.Next(2, 11) * (c.Level * .5));
            var manaUp = (int)Math.Ceiling(r.Next(2, 11) * (c.Level * .5));
            var atkUp = (int)Math.Ceiling(r.Next(1, 4) * (c.Level * .3));
            var defUp = (int)Math.Ceiling(r.Next(1, 4) * (c.Level * .3));
            Message("Health:  " + c.MaxHealth + " -> " + (c.MaxHealth + healthUp));
            c.MaxHealth += healthUp;
            Message("Mana:    " + c.MaxMana + " -> " + (c.MaxMana + manaUp));
            c.MaxMana += manaUp;
            Message("Attack:  " + c.Attack + " -> " + (c.Attack + atkUp));
            c.Attack += atkUp;
            Message("Defense: " + c.Defense + " -> " + (c.Defense + defUp));
            c.Defense += defUp;
            switch(c.Level)
            {
                case 2:
                    Message("You learned a new spell, FROSTBOLT! It's an upgrade on Magic Missile, dealing 3-5 damage and costing 9 mana. Stab your enemies with magic ice!");
                    c.Spells.Add(new Spell { Cost = 9, Name = "FrostBolt", Desc = "A bolt of frost, the size of a small icicle, pierces into your enemy's flesh. 3-5 damage.", MinDamage = 3, MaxDamage = 5, SelfCast = false });
                    break;
                case 5:
                    Message("You learned a new spell, FIREBALL! Engulf your enemy in hellish flame for just 12 mana, dealing 3-9 damage.");
                    c.Spells.Add(new Spell { Cost = 12, Name = "Fireball", Desc = "Blast a ball of flames at your enemy, engulfing them in hellfire. 2-8 damage.", MinDamage = 3, MaxDamage = 8, SelfCast = false });
                    break;
                case 10:
                    Message("You've learned a new spell, LAVABEAM! Blast holes in your enemies privates for the low cost of 15 mana, dealing 5-11 damage.");
                    c.Spells.Add(new Spell { Cost = 15, Name = "LavaBeam", Desc = "A beam of pure lava blasts holes through unprotected flesh. 5-11 damage.",MinDamage=5,MaxDamage=11,SelfCast=false});
                    break;
            }
            Message("");
            Console.ForegroundColor = ConsoleColor.White;
            c.XPForNext = (int)(c.XPForNext*2.1);
            c.Health = c.MaxHealth;
            c.Mana = c.MaxMana;
            //If we leveled up twice XP for next level minus current xp will be negative, so level up again
            if (c.XPForNext-c.XP < 0)
                LevelUp(c);
        }
    }
    
}
