using System;
using WarehouseSystem.Models;
using WarehouseSystem.Repositories;
using WarehouseSystem.Exceptions;

namespace WarehouseSystem.App
{
    public class WarehouseApp
    {
        private Repository<Electronic> _electronicsRepo = new Repository<Electronic>();
        private Repository<Grocery> _groceryRepo = new Repository<Grocery>();

        public void SeedData()
        {
            _electronicsRepo.Add(new Electronic(1, "Laptop", "Dell", 1200m), e => e.Id == 1);
            _electronicsRepo.Add(new Electronic(2, "Smartphone", "Samsung", 800m), e => e.Id == 2);

            _groceryRepo.Add(new Grocery(1, "Rice", "Grain", 50m), g => g.Id == 1);
            _groceryRepo.Add(new Grocery(2, "Apple", "Fruit", 5m), g => g.Id == 2);
        }

        public void DisplayAllItems()
        {
            Console.WriteLine("\n--- Electronics ---");
            foreach (var e in _electronicsRepo.GetAll())
                Console.WriteLine(e);

            Console.WriteLine("\n--- Groceries ---");
            foreach (var g in _groceryRepo.GetAll())
                Console.WriteLine(g);
        }

        public void AddElectronic(Electronic item)
        {
            try
            {
                _electronicsRepo.Add(item, e => e.Id == item.Id);
                Console.WriteLine("Electronic item added successfully!");
            }
            catch (DuplicateItemException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void AddGrocery(Grocery item)
        {
            try
            {
                _groceryRepo.Add(item, g => g.Id == item.Id);
                Console.WriteLine("Grocery item added successfully!");
            }
            catch (DuplicateItemException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void RemoveElectronic(int id)
        {
            try
            {
                _electronicsRepo.Remove(e => e.Id == id);
                Console.WriteLine("Electronic item removed successfully!");
            }
            catch (ItemNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void RemoveGrocery(int id)
        {
            try
            {
                _groceryRepo.Remove(g => g.Id == id);
                Console.WriteLine("Grocery item removed successfully!");
            }
            catch (ItemNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
