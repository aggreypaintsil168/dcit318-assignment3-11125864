using WarehouseSystem.Interfaces;

namespace WarehouseSystem.Models
{
    public class Grocery : IWarehouseItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }

        public Grocery(int id, string name, string category, decimal price)
        {
            Id = id;
            Name = name;
            Category = category;
            Price = price;
        }

        public override string ToString()
        {
            return $"[Grocery] ID: {Id}, Name: {Name}, Category: {Category}, Price: {Price:C}";
        }
    }
}
