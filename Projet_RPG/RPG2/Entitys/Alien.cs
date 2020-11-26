using System;
using System.Collections.Generic;
using System.Text;

namespace RPG2
{
    class Alien : Entity
    {
        public enum Role { Alien, Zombie, Robot}

        public Role r;

        public Item Loot;

        public Alien(Role role, string name) : base(name)
        {
            r = role;

            switch (r)
            {
                case Role.Alien:
                    Hp = 70;
                    Atk = 7;
                    Def = 3;
                    Loot = new Consomable("Pansement", 20, " Rend 20 PV", Item.Effet.HP, 1);
                    break;
                case Role.Zombie:
                    Hp = 140;
                    Atk = 12;
                    Def = 1;
                    Loot = new Equipment("Epee de fracas ",15,"Une belle Epee puissante, +15 ATK",Item.Effet.ATK);
                    break;
                case Role.Robot:
                    Hp = 200;
                    Atk = 15;
                    Def = 2;
                    Loot = new Equipment("Armure de vie ", 6, "Une armure résistante qui soigne des attaques faible, +6 DEF", Item.Effet.DEF);
                    break;
            }
        }
    }
}
