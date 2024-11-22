namespace Exam_Kata_2;

public static class Combat
{
    public static void Initialise()
    {
        Enemy enemy = new Enemy("Goblin", 100, 50);
        Console.WriteLine("Hello Sargent, what is your name?");
        string Name = Console.ReadLine();
        Player playerName = new Player(Name, 100, 20, 0);   
        Encounter(enemy, playerName);
    }
    private static bool Encounter(Enemy enemy, Player playerName)
    {
        bool isAlive = true;
        while (isAlive)
        {
            Console.WriteLine($"A wild Goblin appears with {enemy.Health} health and {enemy.Damage} damage! \n "); 
            Console.WriteLine($"Choose a action: \n 1. Attack! \n 2. Heal!"); 
            
            int action = Convert.ToInt32(Console.ReadLine());
            if (action == 1) 
            { 
                enemy.Attack(playerName);
                ConditionalCheck();
                playerName.Attack(enemy);
                ConditionalCheck();
            }
            else if (action == 2)
            { 
                playerName.Healing(25);
                ConditionalCheck();
                enemy.Attack(playerName);
                ConditionalCheck();
                Console.WriteLine();
            }
            
            bool ConditionalCheck()
            {
                
                if (enemy.Health <= 0) 
                { 
                    playerName.Experience += 30;
                    Console.WriteLine(playerName.Experience);
                    win_loss_messages.WinCondition();
                    
                    return isAlive = false;
                }

                if (playerName.Health <= 0) 
                {
                    win_loss_messages.LoseCondition();
                    
                    return isAlive = false;
                }
                else
                {
                    Console.WriteLine("press any button to continue...");
                    Console.WriteLine($"\n ...\n ");
                    Console.ReadLine();
                    RandomEncounter re = new RandomEncounter();
                    re.EncounterGenerator();
                    return isAlive = true;
                }
            }
        }
        return isAlive;
    }
}