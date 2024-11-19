namespace Exam_Kata;

class Program
{
    static void Main(string[] args)
    {
        string name = Console.ReadLine();
        Player player = new Player(name, 100, 20);
        Enemy enemy = new Enemy("Goblin", 30, 50);
        NPC npc = new NPC("NPC");
        Merchant merchant = new Merchant();
        
        Console.WriteLine($"Sargent {player.Name}: Reporting for duty!");
        
        Random random = new Random();
        random.Next(0, 5);
    }

    class Player
    {
        public string Name {get; set;}
        public int Health { get; set;}
        public int Level { get; set;}
        public int Damage { get; set;}

        public Player(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
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