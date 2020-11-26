using System;   
using System.Collections.Generic;
using System.Text;

namespace RPG2
{
    class Game
    {
        private Player p;  
        private List<Room> rooms;
        private Room currentRoom;
        private int roomClean;
        private bool pIsDead;
        private bool mIsDead;


        public Game()
        {
            CreateRoom();
            CreatePlayer();
            //Quand toutes les salles sont "clean" le jeu est fini
            while (roomClean != rooms.Count && pIsDead == false)
            {
                Console.WriteLine("Nombre de salle Clean : " + roomClean);
                MoveToRoom();
                Fight();
            }
            if (roomClean == rooms.Count && pIsDead == false)
            {
                Console.WriteLine("Bravo ! Tu as survecu à cette invasion sur ton vaisseau. Désormais tu peux enfin rentrer chez toi !");
            }
        }

        private void CreateRoom()
        {
            //Créer des rooms avec des monstres
            rooms = new List<Room>();
            rooms.Add(new Room("Dortoir", new Alien(Alien.Role.Alien, "Zorg"), false));
            rooms.Add(new Room("Pont", new Alien(Alien.Role.Alien, "Rozweld"), false));
            rooms.Add(new Room("Salle De Commandement", new Alien(Alien.Role.Robot, "Brax89700"), false));
            rooms.Add(new Room("Infirmerie", new Alien(Alien.Role.Alien, "Blob"), false));
            rooms.Add(new Room("Salle d'Armement", new Alien(Alien.Role.Zombie, "Harold"), false));
        }
        private void CreatePlayer()
        {
            //Créer un joueur personnalisé à l'aide du script player
            Console.WriteLine("Quel Classe veux tu jouer ? ");
            Console.WriteLine("0 : Warrior | 1 : Assassin");
            int choixR = AskUser(2);
            switch (choixR)
            {
                case 0:
                    p = new Player(Player.Role.Warrior, "");
                    p.Inventory.Add(new Consomable("Potion de force moyenne ", 30, " Augmente l'ATK de 30", Item.Effet.ATK, 2));
                    break;
                case 1:
                    p = new Player(Player.Role.Assassin, "");
                    p.Inventory.Add(new Consomable("Vodka ", 50, " Rend 50 PV", Item.Effet.HP, 2));
                    break;
            }
            Console.WriteLine("Quel est ton nom ? ");
            p.Name = Console.ReadLine();
            Console.WriteLine("Tu t'appelle : " + p.Name + " et tu est un : " + p.r);
            Console.WriteLine("Tu possède : " + p.Inventory.Count + " objet sur toi, c'est une " + p.Inventory[0].Name);
        }

        private void MoveToRoom()
        {
            //Permet de se déplacer de salle en salle
            int r = 0;
            while (p.Hp > 0)
            {
                Console.WriteLine("Où veux tu aller ? ");
                foreach(Room room in rooms)
                {
                    Console.WriteLine(r + " " + room.Name);
                    r += 1;
                }
                int currentRoomIndex = AskUser(rooms.Count);
                currentRoom = rooms[currentRoomIndex];
                currentRoom.PrintDescription();
                return;
            }
        }
        private void Fight()
        {
            //Système de combat
            Alien a = currentRoom.Monster;

            while (a.Hp > 0 && p.Hp > 0)
            {
                Console.WriteLine("Quel action veux tu faire ? ");
                Console.WriteLine("0 : Atk | 1 : Inventaire | 2 : Fuite | 3: Quitter le jeu ");
                int choix = AskUser(4);
                switch(choix)
                {
                    case 0:
                        Attaque();
                        break;
                    case 1:
                        Inventaire();
                        break;
                    case 2:
                        Console.WriteLine("Tu prends la fuite.... ");
                        return;
                    case 3:
                        Quit();
                        break;
                }
            }

            if (p.Hp > 0 && mIsDead == false)
            {
                mIsDead = true;
                p.Inventory.Add(currentRoom.Monster.Loot);
                Console.WriteLine("Tu as vaincu : " + currentRoom.Monster.Name + " ,tu as récupérer sur lui un " + currentRoom.Monster.Loot.Name);
            }
            else if (p.Hp <= 0 && pIsDead == false)
            {
                pIsDead = true;
                Console.WriteLine("Aie ! Tu as été vaincu... Ton vaisseau a sombré avec toi à son bord. ");
                return;
            }

            if (mIsDead == true && currentRoom.RisClean == false)
            {
                currentRoom.RisClean = true;
                roomClean++;
            }
            return;
        }

        private void Attaque()
        {
            mIsDead = false;
            currentRoom.Monster.Hp -= p.Atk - currentRoom.Monster.Def;
            p.Hp -= currentRoom.Monster.Atk - p.Def;

            Console.WriteLine(p.Name + " PV :" + p.Hp + " " + currentRoom.Monster.Name + " Pv :" + currentRoom.Monster.Hp);
        }
        private void Inventaire()
        {
            int c = 0;
            Console.WriteLine("Quel objet veux tu utiliser ? ");
            foreach (Item i in p.Inventory)
            {
                if (i.GetType() == typeof(Consomable))
                {
                    Console.WriteLine(c + " " + i.Name + " " + i.Description);
                    c += 1;
                }
                else if(i.GetType() == typeof(Equipment))
                {
                    Console.WriteLine(c + " " + i.Name + " " + i.Description);
                    c += 1;
                }
            }
            if (p.Inventory.Count == 0)
            {
                Console.WriteLine("Ton inventaire est vide... ");
                return;
            }
            int choix = AskUser(c);
            p.Inventory[choix].Use(p);
        }
        private void Quit()
        {
            Environment.Exit(0);
        }

        private int AskUser(int nbChoix)
        {
            int choix = int.Parse( Console.ReadLine());

            while (choix < 0 || choix >= nbChoix)
            {
                Console.WriteLine("Ce n'est pas un choix valide, merci de choisir le nombre ci-dessus ! ");
                choix = int.Parse(Console.ReadLine());
            }

            return choix;
        }

    }
}
