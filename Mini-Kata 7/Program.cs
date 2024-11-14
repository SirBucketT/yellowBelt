namespace Mini_Kata_7;

class Program
{
    static void Main(string[] args)
    {
        Player player = new Player();

        player.Name = "Arin";
        player.Health = 100;
        player.Level = 1;

        Console.WriteLine($"Player Info: \n " +
                          $"Name: {player.Name} \n " +
                          $"Health: {player.Health} \n " +
                          $"Level: {player.Level}");

        Console.WriteLine();

        Enemy enemy = new Enemy();

        enemy.Type = "Goblin";
        enemy.Health = 50;
        enemy.Damage = 10;

        Console.WriteLine($"Enemy Info: \n " +
                          $"Type: {enemy.Type} \n " +
                          $"Health: {enemy.Health} \n " +
                          $"Damage: {enemy.Damage}");
    }

    class Player
    {
        public string Name;
        public int Health;
        public int Level;
    }

    class Enemy
    {
        public string Type;
        public int Health;
        public int Damage;
    }
}