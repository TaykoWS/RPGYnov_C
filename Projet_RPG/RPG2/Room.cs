using System;
using System.Collections.Generic;
using System.Text;

namespace RPG2
{
    class Room
    {
        public Alien Monster;
        public string Name;
        public bool RisClean;
        public Room(string name, Alien monster, bool rIsClean)
        {
            Name = name;
            Monster = monster;
            RisClean = rIsClean;
        }

        public void PrintDescription()
        {
            Console.WriteLine("Tu est rentré dans " + Name);
            
            if(RisClean == true)
            {
                Console.WriteLine("Tu as déjà nettoyé cette zone ! ");
            }
            else
            {
                Console.WriteLine("Attention !! Tu est attaqué par " + Monster.Name + " un " + Monster.r);
            }
        }
    }
}
