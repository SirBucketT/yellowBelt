namespace Kata_6;

class Program
{
    static void Main(string[] args) 
    {
       string[] enemylist = { "Goblin", "Orc", "Troll", "Skeleton", "Dragon" };

       Console.WriteLine("Enemies:");
       
       foreach (var i in enemylist)
       {
           Console.WriteLine(i);
       }

       string[] playerInventory = { "Sword", "Shield", "Potion" };
       
       Console.WriteLine();
       Console.WriteLine("Player Inventory:");

       foreach (var i in playerInventory)
       {
           Console.WriteLine(i);
       }

       Console.WriteLine();

       List<string> playerInventoryList = new List<string>(playerInventory);
       
       playerInventoryList.Add("Helmet");
       playerInventoryList.Add("Armor");
       playerInventoryList.Remove("Potion");
       
       playerInventory = playerInventoryList.ToArray();
       
       Console.WriteLine("Updated Inventory:");
       
       foreach (var i in playerInventory)
       {
           Console.WriteLine(i);
       }

       Console.WriteLine();
       Console.WriteLine($"Total Items in Inventory: {playerInventoryList.Count}");
    }
}

