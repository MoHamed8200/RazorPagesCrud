using System.Collections.Generic;
using RazorPagesCrud.Models;

namespace RazorPagesCrud.Data
{
    public class ProductContext
    {
        public List<Product> Products { get; set; } = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 1200.00m },
            new Product { Id = 2, Name = "Smartphone", Price = 800.00m },
            new Product { Id = 3, Name = "Tablet", Price = 600.00m }
        };
    }
}