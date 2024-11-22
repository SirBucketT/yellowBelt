namespace Exam_Kata;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Sargent, what is your name?");
            
        string name = Console.ReadLine();
        Player player = new Player(name, 10, 20, 15, 0);
        Console.WriteLine($"Sargent {player.Name} says: Reporting for duty!");
        
        //Gameloop
        bool isAlive = true;
        while (isAlive)
        {
            isAlive = RandomEncounter();
        }
        
        //Random number generator deciding what encounter you face
        bool RandomEncounter()
        { 
            bool isAlive = true;
            Random random = new Random(); 
            int EncounterNumber = random.Next(0, 3);
            
            if (EncounterNumber == 0) 
            { 
                isAlive = Goblin(); 
            }

            else if (EncounterNumber == 1)
            {
                Events.Shop();
                isAlive = true;
            }

            else if (EncounterNumber == 2)
            {
                Events.Villager();
                isAlive = true;
            }
            return isAlive;
        }
        
        bool Goblin() 
        { 
            bool isAlive;
            Enemy enemy = new Enemy("Goblin", 100, 50);
            
            isAlive= ConditionalCheck();
            
            Console.WriteLine($"A wild Goblin appears with {enemy.Health} health and {enemy.Damage} damage! \n "); 
            Console.WriteLine($"Choose a action: \n 1. Attack! \n 2. Heal!"); 
            
            int action = Convert.ToInt32(Console.ReadLine());
            if (action == 1) 
            { 
                enemy.Attack(player, 5000);
                ConditionalCheck();
                player.Attack(enemy, 50);
                ConditionalCheck();
            }
            else if (action == 2)
            { 
                player.Healing(25);
                ConditionalCheck();
                enemy.Attack(player, 20000);
                ConditionalCheck();
                Console.WriteLine();
            }
            
            bool ConditionalCheck()
            {
                bool isAlive;
                if (enemy.Health <= 0) 
                { 
                    player.Experience += 30;
                    Console.WriteLine(player.Experience);
                    Conditions.WinCondition();
                    isAlive = false;
                }

                if (player.Health <= 0) 
                {
                    Conditions.LoseCondition();
                    isAlive = false;
                }
                else
                {
                    Console.WriteLine("press any button to continue...");
                    Console.WriteLine($"\n ...\n ");
                    Console.ReadLine();
                    RandomEncounter();
                    action = 3;
                    isAlive = true;
                }
                return isAlive; 
            }

            return isAlive;
        }
    }

    class Events
    {
        public static void Shop()
        {
            Merchant merchant = new Merchant("Hammer the Merchant");
            Console.WriteLine($"{merchant.Name}");
            Merchant.Trade();

            Console.WriteLine("press any button to continue...");
            Console.WriteLine($"\n ...\n ");
            Console.ReadLine();
        }

        public static void Villager()
        {
            Console.WriteLine("You encounter a Villager. \n Villager says: Welcome to our village!");
            Console.WriteLine("press any button to continue...");
            Console.WriteLine($"\n ...\n ");
            Console.ReadLine();
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
        public int Experience { get; set;}

        public Player(string name, int health, int damage, int heal, int exp)
        {
            Name = name;
            Health = health;
            Damage = damage;
            Heal = heal;
            Experience = exp;
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
            Console.WriteLine("Select what item you wish to buy:");
            string[] inventoryItems = { "1. Sword", "2. Shield", "3. Potion" };
            
            foreach (var i in inventoryItems)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine();

            List<string> playerInventoryList = new List<string>(inventoryItems);
            
            string input = Console.ReadLine();
            if (input == "1")
            {
                playerInventoryList.Remove("1. Sword");
            } else if (input == "2")
            {
                playerInventoryList.Remove("2. Shield");
            }
            else
            {
                playerInventoryList.Remove("3. Potion");
            }
       
            inventoryItems = playerInventoryList.ToArray();
       
            Console.WriteLine("Items left in stock:");
       
            foreach (var i in inventoryItems)
            {
                Console.WriteLine(i);
            }
        }
    }
}