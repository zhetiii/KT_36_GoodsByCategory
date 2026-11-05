using System;
using System.Collections.Generic;
using System.Linq;

namespace KT_36_GoodsByCategory
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }

        public Product(string name, decimal price, string category)
        {
            Name = name;
            Price = price;
            Category = category;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>
            {
                new Product("Мышь", 1500m, "Электроника"),
                new Product("Клавиатура", 3500m, "Электроника"),
                new Product("Монитор", 25000m, "Электроника"),
                new Product("Адаптер", 800m, "Аксессуары"),
                new Product("Коврик", 500m, "Аксессуары"),
                new Product("Рюкзак", 4000m, "Аксессуары"),
                new Product("Яблоко", 100m, "Продукты"),
                new Product("Молоко", 120m, "Продукты")
            };

            Console.WriteLine("=== Исходный список товаров ===");
            foreach (var p in products)
            {
                Console.WriteLine($"{p.Name} — {p.Price} руб. [{p.Category}]");
            }

            var summary = products
                .GroupBy(p => p.Category)
                .Select(g => new
                {
                    Category = g.Key,
                    Count = g.Count(),
                    AveragePrice = g.Average(p => p.Price)
                });

            Console.WriteLine("\n=== Итоговая сводка по категориям ===");
            foreach (var item in summary)
            {
                Console.WriteLine($"Категория: {item.Category} | Количество товаров: {item.Count} | Средняя цена: {item.AveragePrice:F2} руб.");
            }
        }
    }
}