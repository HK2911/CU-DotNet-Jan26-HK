using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Day31_Exercise1
{
    class CartItem
    {
        public string Name;
        public string Category;
        public double Price;
        public int Qty;
    }

    class CartSummaryDTO
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public double TotalPrice { get; set; }
        public double DiscountedPrice { get; set; }
    }

    internal class Question8
    {

    public static void Main(String[] args)
            {
                var cart = new List<CartItem>
                 {
                        new CartItem{Name="TV", Category="Electronics", Price=30000, Qty=1},
                        new CartItem{Name="Sofa", Category="Furniture", Price=15000, Qty=1},
                        new CartItem{Name="Mobile", Category="Electronics", Price=20000, Qty=2}
                    };

                // 1️⃣ Calculate total cart value
                double totalCartValue = cart.Sum(item => item.Price * item.Qty);

                Console.WriteLine("Total Cart Value: ₹" + totalCartValue);


                // 2️⃣ Group by Category and total category cost
                var categoryTotals = cart
                    .GroupBy(item => item.Category)
                    .Select(group => new
                    {
                        Category = group.Key,
                        TotalCost = group.Sum(item => item.Price * item.Qty)
                    });

                Console.WriteLine("\nCategory Wise Total:");
                foreach (var category in categoryTotals)
                {
                    Console.WriteLine($"{category.Category} - ₹{category.TotalCost}");
                }


                // 3️⃣ Apply 10% discount for Electronics category
                var discountedCart = cart
                    .Select(item => new
                    {
                        item.Name,
                        item.Category,
                        OriginalTotal = item.Price * item.Qty,
                        DiscountedTotal = item.Category == "Electronics"
                                            ? item.Price * item.Qty * 0.9
                                            : item.Price * item.Qty
                    });

                Console.WriteLine("\nDiscount Applied (Electronics 10%):");
                foreach (var item in discountedCart)
                {
                    Console.WriteLine($"{item.Name} - ₹{item.DiscountedTotal}");
                }


                // 4️⃣ Return Cart Summary DTO objects (Projection)
                var cartSummary = cart
                    .Select(item => new CartSummaryDTO
                    {
                        Name = item.Name,
                        Category = item.Category,
                        TotalPrice = item.Price * item.Qty,
                        DiscountedPrice = item.Category == "Electronics"
                                            ? item.Price * item.Qty * 0.9
                                            : item.Price * item.Qty
                    })
                    .ToList();

                Console.WriteLine("\nCart Summary DTO:");
                foreach (var item in cartSummary)
                {
                    Console.WriteLine($"{item.Name} | {item.Category} | Total: ₹{item.TotalPrice} | Final: ₹{item.DiscountedPrice}");
                }
            }

        }
}
