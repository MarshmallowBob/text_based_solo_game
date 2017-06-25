using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BruffGame
{
    class Room
    {
        public int ID { get; set; }
        public string Intro { get; set; }
        public Dictionary<string, string> ReadableList { get; set; }
        public Dictionary<string, string> GettableList { get; set; }
        public List<NPC> TalkableList { get; set; }
        public List<NPC> KillableList { get; set; }
        public int West { get; set; }
        public int East { get; set; }
        public int North { get; set; }
        public int South { get; set; }
        public Room()
        {
            ReadableList = new Dictionary<string, string>();
            GettableList = new Dictionary<string, string>();
            KillableList = new List<NPC>();
            TalkableList = new List<NPC>();
            North = -1;
            West = -1;
            South = -1;
            East = -1;
        }
    }
}
