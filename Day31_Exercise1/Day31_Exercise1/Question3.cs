using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day31_Exercise1
{
    class Product { public int Id; public string Name; public string Category; public double Price; }
    class Sale
    {
        public int ProductId; public int Qty;
    }


    internal class Question3
    {
        static void Main(String[] args)
        {
            var products = new List<Product>
            {
                new Product{Id=1, Name="Laptop", Category="Electronics", Price=50000},
                new Product{Id=2, Name="Phone", Category="Electronics", Price=20000},
                new Product{Id=3, Name="Table", Category="Furniture", Price=5000}
            };

                        var sales = new List<Sale>
            {
                new Sale{ProductId=1, Qty=10},
                new Sale{ProductId=2, Qty=20}
            };

            var joined = products.Join(
                sales,
                p => p.Id,
                s => s.ProductId,
                (p, s) => new
                {
                    p.Name,
                    s.Qty,
                    revenue=p.Price*s.Qty
                });

            Console.WriteLine("Joined products with sales");
            foreach(var v in joined)
            {
                Console.WriteLine($"{v.Name} - Qty:{v.Qty} Revnue: {v.revenue} ");
            }

            var revenuePerProduct = products
            .GroupJoin(
            sales,
            p => p.Id,
            s => s.ProductId,
            (p, saleGroup) => new
            {
                ProductName = p.Name,
                TotalRevenue = saleGroup.Sum(s => s.Qty * p.Price)
            });

            Console.WriteLine("\nTotal Revenue Per Product:");
            foreach (var item in revenuePerProduct)
            {
                Console.WriteLine($"{item.ProductName} - Revenue: {item.TotalRevenue}");
            }

            var bestProduct = revenuePerProduct.OrderByDescending(p => p.TotalRevenue).First();
            Console.WriteLine($"\nBest Selling Product: {bestProduct.ProductName} - Revenue: {bestProduct.TotalRevenue}");

            var zeroSales = products
    .GroupJoin(
        sales,
        p => p.Id,
        s => s.ProductId,
        (p, saleGroup) => new
        {
            ProductName = p.Name,
            TotalQty = saleGroup.Sum(s => s.Qty)
        })
    .Where(p => p.TotalQty == 0);

            Console.WriteLine("\nProducts with Zero Sales:");
            foreach (var item in zeroSales)
            {
                Console.WriteLine(item.ProductName);
            }

        }

    }
}
