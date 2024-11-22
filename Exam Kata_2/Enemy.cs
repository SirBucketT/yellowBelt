namespace Exam_Kata_2;

public class Enemy
{
    public string Type {get; set;}
    public int Health {get; set;}
    public int Damage {get; set;}

    public bool IsAlive = true;

    public Enemy(string type, int health, int damage)
    {
        Type = type;
        Health = health;
        Damage = damage;
    }

    public void TakeDamage(Player player, int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            IsAlive = false;
            Health = 0;
            player.GetExp();
        }
        Console.WriteLine($"{Type} takes {damage} damage. Remaining health: {Health}");
    }
        
    public void Attack(Player player)
    {
        Console.WriteLine($"{Type} attacks {player.Name} and deals {Damage} damage.");
        player.TakeDamage(Damage);
    }
}