namespace Kata_5;

class Program
{
    static void Main(string[] args)
    {
       AttackEnemy();
       HealPlayer();
    }
    
    static void AttackEnemy()
    {
        string enemyName = "Goblin";
        int damage = 20;
        
        Console.WriteLine($"Attacked {enemyName} and dealt {damage} damage");
    }

    static void HealPlayer()
    {
        string playerName = "Arin";
        int healAmount = 15;
        
        Console.WriteLine($"Player {playerName} healed {healAmount} health points!");
    }

}