namespace Mini_Kata_6;

class Program
{
    static void Main(string[] args)
    {
        string[] enemies = {"Goblin", "Orc", "troll" };
        Console.WriteLine($"Enemies:");
        
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine(enemies[i]);
        }Console.WriteLine();
        
        string[] playerInventory = { "Sword", "Shield", "Potion" };
        
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine(playerInventory[i]);
        }Console.WriteLine();
        
        List<string> inventoryList = new List<string>(playerInventory);
        
        inventoryList.Add("Helmet");
        
        playerInventory = inventoryList.ToArray();
        
        for (int i = 0; i < 4; i++)
        {
            Console.WriteLine(playerInventory[i]);
        }Console.WriteLine();
    }
}