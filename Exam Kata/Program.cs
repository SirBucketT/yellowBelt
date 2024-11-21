namespace Exam_Kata;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Sargent, what is your name?");
            
        string name = Console.ReadLine();
        Player player = new Player(name, 100, 20, 15);
        NPC npc = new NPC("NPC");
        Console.WriteLine($"Sargent {player.Name} says: Reporting for duty!");
        
        //Gameloop
        bool isAlive = true;
        while (isAlive)
        {
            RandomEncounter();
        }
        
        //Random number generator deciding what encounter you face
        void RandomEncounter()
        { 
            Random random = new Random(); 
            int EncounterNumber = 1; //random.Next(0, 5);
                                     
            Console.WriteLine($"Encounter {EncounterNumber}");
            if (EncounterNumber == 0) 
            { 
                Goblin(); 
            }

            if (EncounterNumber == 1)
            {
                Events.Shop();
                Merchant.Trade();
                isAlive = false;
            }
        }
        
        void Goblin() 
        { 
            Enemy enemy = new Enemy("Goblin", 30, 50);
            if (enemy.Health <= 0) 
            { 
                Conditions.WinCondition(); 
            }
            Console.WriteLine($"A wild Goblin appears with {enemy.Health} health and {enemy.Damage} damage! \n "); 
            Console.WriteLine($"Choose a action: \n 1. Attack! \n 2. Heal!"); 
            
            int action = Convert.ToInt32(Console.ReadLine());
            if (action == 1) 
            { 
                enemy.Attack(player, 50); 
                player.Attack(enemy, 20); 
                RandomEncounter();
            }
            else 
            { 
                enemy.Attack(player, 50); 
                player.Healing(15); 
                RandomEncounter();
            }

            if (player.Health <= 0 || player.Health < 0) 
            {
                isAlive = false; 
                Conditions.LoseCondition();
            }
        }
    }

    class Events
    {
        public static void Shop()
        {
            Merchant merchant = new Merchant("Hammer the Merchant");
            Console.WriteLine($"{merchant.Name}");
        }
    }

    class Conditions
    {
        public static void WinCondition()
        {
            Console.WriteLine($"Goblin defeated. Congratulations!");
        }

        public static void LoseCondition()
        {
            Console.WriteLine($"You lost!");
        }
    }
    
    class Player
    {
        public string Name {get; set;}
        public int Health { get; set;}
        public int Heal { get; set;}
        public int Level { get; set;}
        public int Damage { get; set;}

        public Player(string name, int health, int damage, int heal)
        {
            Name = name;
            Health = health;
            Damage = damage;
            Heal = heal;
        }

        public void Healing(int heal)
        {
            Console.WriteLine($"{Name} uses heal and healed {heal} health points!");
            Health += heal;
        }

        public void Attack(Enemy enemy, int damage)
        {
            Console.WriteLine($"{Name} attacks {enemy.Type} and deals {damage} damage.");
            enemy.TakeDamage(this, damage);
        }
        
        public void TakeDamage(Enemy enemy, int damage)
        {
            enemy.Health -= damage;
            Console.WriteLine($"{enemy.Type} takes {damage} damage. Remaining health: {enemy.Health}");
        }
    }
    
    class Enemy
    {
        public string Type {get; set;}
        public int Health {get; set;}
        public int Damage {get; set;}

        public Enemy(string type, int health, int damage)
        {
            Type = type;
            Health = health;
            Damage = damage;
        }

        public void TakeDamage(Player player, int damage)
        {
            Health -= player.Damage;
            Console.WriteLine($"{Type} takes {damage} damage. Remaining health: {Health}");
        }
        
        public void Attack(Player player, int damage)
        {
            Console.WriteLine($"{Type} attacks {player.Name} and deals {damage} damage.");
            player.TakeDamage(this, damage);
        }
    }

    class NPC
    {
        public string Name {get; private set;}
        public string Dialogue {get; set;}

        public NPC(string name)
        {
            Name = name;
        }

        public void Speak()
        {
            Console.WriteLine($"{Name} says: Welcome to our village");
        }
    }

    class Merchant
    {
        public string Name {get; set;}
        //public string Inventory {get; private set;}
        public Merchant(string name)
        {
            Name = name;
        }

        public static void Trade()
        {
            string[] inventoryItems = { "1. Sword", "2. Shield", "3. Potion" };
            
            foreach (var i in inventoryItems)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine();

            List<string> playerInventoryList = new List<string>(inventoryItems);
            
            playerInventoryList.Remove("3. Potion");
       
            inventoryItems = playerInventoryList.ToArray();
       
            Console.WriteLine("Updated Inventory:");
       
            foreach (var i in inventoryItems)
            {
                Console.WriteLine(i);
            }
        }
    }
}