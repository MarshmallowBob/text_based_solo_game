using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BruffGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Character c = new Character();
            Game.StartGame(c);
            var notDeadYet = true;
            while (notDeadYet)
            {
                Console.Write("What say you, {0}? (H: {1}, M: {2}): ", c.Name, c.Health, c.Mana);
                Game.Command(Console.ReadLine(),c);
            }
            Console.ReadKey();
        }
    }
}
