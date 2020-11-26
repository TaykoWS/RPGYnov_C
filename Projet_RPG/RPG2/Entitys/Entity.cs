using System;
using System.Collections.Generic;
using System.Text;

namespace RPG2
{
    class Entity
    {
        public string Name;
        public int Hp;
        public int Atk;
        public int Def;

        public Entity(string name)
        {
            Name = name;
        }
    }
}
