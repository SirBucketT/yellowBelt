using System.IO.Compression;
using Microsoft.CSharp.RuntimeBinder;

namespace Kata_9;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Merchant merchant = new Merchant();
        Player player = new Player("Arin", 50, 20);
        Enemy enemy = new Enemy("Goblin", 50);
        NPC npc = new NPC("NPC");
        
        player.Attack(enemy, 20);
        enemy.TakeDamage(player, 20);
        npc.Speak();
        
        merchant.Name = "Merchant";
        merchant.Trade();
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
        }
    }

    class Enemy
    {
        public string Type {get; set;}
        public int Health {get; set;}
        public int Damage {get; set;}

        public Enemy(string type, int health)
        {
            Type = type;
            Health = health;
        }

        public void TakeDamage(Player player, int damage)
        {
            Health -= damage;
            Console.WriteLine($"{Type} takes {damage} damage. Remaining health: {Health}");
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