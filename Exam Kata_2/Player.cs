namespace Exam_Kata_2;

public class Player
{
    public string? Name {get; private set ;}
    public int Health { get; set;}
    public int Heal = 20;
    public int Level { get; set;}
    public int Damage { get; set;}
    public int Experience { get; set;}

    public bool IsAlive = true;

    public Player(string? name, int health, int damage, int exp)
    {
        Name = name;
        Health = health;
        Damage = damage;
        Experience = exp;
    }

    public void Healing(int heal)
    {
        Console.WriteLine($"{Name} uses heal and healed {heal} health points!");
        Health += heal;
    }

    public void Attack(Enemy enemy)
    {
        Console.WriteLine($"{Name} attacks {enemy.Type} and deals {Damage} damage.");
        enemy.TakeDamage(this, Damage);
    }
        
    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            IsAlive = false;
            Health = 0;
        }

        Console.WriteLine($"{Name} takes {damage} damage. Remaining health: {Health}");
    }

    public int GetExp()
    {
        return Experience += 30;
    }
}