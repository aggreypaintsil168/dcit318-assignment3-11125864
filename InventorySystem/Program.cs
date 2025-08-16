using System;

class Program
{
    static void Main()
    {
        string filePath = "inventory.json";

        // First Session
        InventoryApp app = new InventoryApp(filePath);
        app.SeedSampleData();
        app.SaveData();

        // Simulate new session
        Console.WriteLine("\n💾 Clearing memory & starting new session...\n");
        app = new InventoryApp(filePath);
        app.LoadData();
        app.PrintAllItems();
    }
}
