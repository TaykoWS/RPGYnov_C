using System;
using System.Collections.Generic;
using System.Text;

namespace RPG2
{
    class Consomable : Item
    {
        public int NbUtilisation;

        public Consomable(string name, int puissance, string description, Item.Effet e, int nbUtilisation)
            : base(name, puissance, description,e)
        {
            NbUtilisation = nbUtilisation;
        }

        public override void Use(Player p)
        {
            if(NbUtilisation > 0)
            {
                base.Use(p);
                NbUtilisation--;
                Console.WriteLine("Tu as utilisé : " + Name + " Il te reste : " + NbUtilisation + " " + Name);

                if (NbUtilisation <= 0)
                {
                    p.Inventory.Remove(this);
                }
            }    
        }
    }
}
