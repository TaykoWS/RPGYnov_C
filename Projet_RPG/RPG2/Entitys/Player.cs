using System;
using System.Collections.Generic;
using System.Text;

namespace RPG2
{
    class Player : Entity
    {
        public enum Role { Warrior, Assassin }

        public Role r;

        public List<Item> Inventory;
        public Player(Role role, string name) : base(name)
        {
            r = role;

            Inventory = new List<Item>();

            switch (role)
            {
                case Role.Warrior:
                    Hp = 27;
                    Atk = 5;
                    Def = 6;
                    break;
                case Role.Assassin:
                    Hp = 10;
                    Atk = 25;
                    Def = 3;
                    break;

            }
        }
    }
}
