namespace Kata_7;

class Program
{
    static void Main(string[] args)
    {
        Player player = new Player();
        Enemy enemy = new Enemy();

        player.Attack(damage:50);
        enemy.TakeDamage(damage:50);
    }

    class Player
    {
        public string name = "Arin";
        public int Health = 100;
        public int Level = 1;
        public int Experience = 50;
        public int Damage = 50;

        public void Attack(int damage)
        {
            Console.WriteLine($"{name} attacks the enemy and deals {damage} damage");
        }

        public void GainExperience(int exp)
        {
            Experience += exp;
            Console.WriteLine($"{name} Gained {exp} Experience.");
        }
        
    }

    class Enemy
    {
        public string Type = "Orc";
        public int Health = 100;

        public void TakeDamage(int damage)
        {
            if (damage <= 0)
            {
                Console.WriteLine($"{Type} has been defeated");
                damage = 0;
                return;
            }
            Health -= damage;
            Console.WriteLine($"{Type} takes {damage} damage. Remaining Health: {Health}");
        }
    }

}