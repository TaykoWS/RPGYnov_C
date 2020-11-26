using System;
using System.Collections.Generic;
using System.Text;

namespace RPG2
{
    class Item
    {
        public enum Effet { ATK, DEF, HP}

        public Effet effet;
        public string Name;
        public int Puissance;
        public string Description;

        public Item (string name, int puissance, string description, Effet e)
        {
            Name = name;
            Puissance = puissance;
            Description = description;
            effet = e;
        }

        public virtual void Use(Player p)
        {
            switch(effet)
            {
                case Effet.ATK:
                    p.Atk += Puissance;
                    break;
                case Effet.DEF:
                    p.Def += Puissance;
                    break;
                case Effet.HP:
                    p.Hp += Puissance;
                    break;
            }
        }
    }
}
