using System;
using WarehouseSystem.App;
using WarehouseSystem.Models;

namespace WarehouseSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new WarehouseApp();
            app.SeedData();

            app.DisplayAllItems();

            Console.WriteLine("\nAdding a new Electronic:");
            app.AddElectronic(new Electronic(3, "Tablet", "Apple", 600m));

            Console.WriteLine("\nAdding a duplicate Grocery:");
            app.AddGrocery(new Grocery(1, "Rice", "Grain", 50m)); // Will throw duplicate exception

            Console.WriteLine("\nRemoving Grocery ID 2:");
            app.RemoveGrocery(2);

            Console.WriteLine("\nRemoving non-existing Electronic ID 10:");
            app.RemoveElectronic(10);

            Console.WriteLine("\nFinal List:");
            app.DisplayAllItems();
        }
    }
}
