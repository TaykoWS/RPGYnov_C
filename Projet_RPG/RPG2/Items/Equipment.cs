using System;
using System.Collections.Generic;
using System.Text;

namespace RPG2
{
    class Equipment : Item
    {
        public bool IsEquip;
        public Equipment(string name, int puissance, string description, Effet e) 
            :base(name, puissance, description, e)
        {
            IsEquip = false;
        }

        public override void Use(Player p)
        {
            IsEquip = true;
            base.Use(p);

            if(IsEquip == true)
            {
                if(effet == Effet.ATK)
                {
                    Console.WriteLine("Tu viens d'équiper : " + Name + "," + " Voici tes nouvelles stats : " + p.Atk + " ATK");
                }
                else
                {
                    Console.WriteLine("Tu viens d'équiper : " + Name + "," + " Voici tes nouvelles stats : " + p.Def + " DEF");
                }
                p.Inventory.Remove(this);
            }
        }
    }
}
