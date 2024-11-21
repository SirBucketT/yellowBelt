namespace Exam_Kata;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Sargent, what is your name?");
            
        string name = Console.ReadLine();
        Player player = new Player(name, 100, 20, 15);
        NPC npc = new NPC("NPC");
        Enemy enemy = new Enemy("Goblin", 30, 50);
        Merchant merchant = new Merchant();
        
        Console.WriteLine($"Sargent {player.Name} says: Reporting for duty!");
        
        //Gameloop
        bool isAlive = true;
        while (isAlive == true)
        {
            randomEncounter();
        }
        
        //Random number generator deciding what encounter you face
        void randomEncounter()
        { 
            Random random = new Random(); 
            int EncounterNumber = 0; //random.Next(0, 5);
                                     
            Console.WriteLine($"Encounter {EncounterNumber}");
            if (EncounterNumber == 0) 
            { 
                Goblin(); 
            }
        } 
        
        void Goblin() 
        { 
            if (enemy.Health <= 0) 
            { 
                Conditions.winCondition(); 
            }
            Console.WriteLine($"A wild Goblin appears with {enemy.Health} health and {enemy.Damage} damage! \n "); 
            Console.WriteLine($"Choose a action: \n 1. Attack! \n 2. Heal!"); 
            
            int action = Convert.ToInt32(Console.ReadLine());
            if (action == 1) 
            { 
                enemy.Attack(player, 50); 
                player.Attack(enemy, 20); 
                randomEncounter();
            }
            else 
            { 
                enemy.Attack(player, 50); 
                player.Healing(15); 
                randomEncounter();
            }

            if (player.Health <= 0 || player.Health < 0) 
            { 
                Conditions.loseCondition(); 
                isAlive = false; 
            }
        }
    }

    class Conditions
    {
        public static void winCondition()
        {
            Console.WriteLine($"Goblin defeated. Congratulations!");
        }

        public static void loseCondition()
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
        public string Inventory {get; private set;}

        public void Trade()
        {
            Inventory = "Sword, Shield, Potion";
            Console.WriteLine($"{Name} inventory: {Inventory}");
        }
    }
}