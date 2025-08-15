using WarehouseSystem.Interfaces;

namespace WarehouseSystem.Models
{
    public class Electronic : IWarehouseItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }

        public Electronic(int id, string name, string brand, decimal price)
        {
            Id = id;
            Name = name;
            Brand = brand;
            Price = price;
        }

        public override string ToString()
        {
            return $"[Electronic] ID: {Id}, Name: {Name}, Brand: {Brand}, Price: {Price:C}";
        }
    }
}
