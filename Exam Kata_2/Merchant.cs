class Merchant
{
    public string Name {get; set;}
    //public string Inventory {get; private set;}
    public Merchant(string name)
    {
        Name = name;
    }

    public static void Trade()
    {
        Console.WriteLine("Select what item you wish to buy:");
        string[] inventoryItems = { "1. Sword", "2. Shield", "3. Potion" };
            
        foreach (var i in inventoryItems)
        {
            Console.WriteLine(i);
        }

        Console.WriteLine();

        List<string> playerInventoryList = new List<string>(inventoryItems);
            
        string input = Console.ReadLine();
        if (input == "1")
        {
            playerInventoryList.Remove("1. Sword");
        } else if (input == "2")
        {
            playerInventoryList.Remove("2. Shield");
        }
        else
        {
            playerInventoryList.Remove("3. Potion");
        }
       
        inventoryItems = playerInventoryList.ToArray();
       
        Console.WriteLine("Items left in stock:");
       
        foreach (var i in inventoryItems)
        {
            Console.WriteLine(i);
        }
    }
    public static void Shop()
    {
        Merchant merchant = new Merchant("Hammer the Merchant");
        Console.WriteLine($"{merchant.Name}");
        Merchant.Trade();

        Console.WriteLine("press any button to continue...");
        Console.WriteLine($"\n ...\n ");
        Console.ReadLine();
    }
}