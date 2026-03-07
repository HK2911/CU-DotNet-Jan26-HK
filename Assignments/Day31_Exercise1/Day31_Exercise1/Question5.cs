using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day31_Exercise1
{
    class Customer
    {
        public int Id;
        public string Name;
        public string City;
    }

    class Order
    {
        public int OrderId;
        public int CustomerId;
        public double Amount;
    }

    internal class Question5
    {
        static void Main()
        {
            var customers = new List<Customer>
        {
            new Customer{Id=1, Name="Ajay", City="Delhi"},
            new Customer{Id=2, Name="Sunita", City="Mumbai"},
            new Customer{Id=3, Name="Rahul", City="Chennai"} // No orders
        };

            var orders = new List<Order>
        {
            new Order{OrderId=1, CustomerId=1, Amount=20000},
            new Order{OrderId=2, CustomerId=1, Amount=40000},
            new Order{OrderId=3, CustomerId=2, Amount=30000}
        };

            // 1️⃣ Total order amount per customer
            var totalPerCustomer = customers
                .GroupJoin(orders,
                    c => c.Id,
                    o => o.CustomerId,
                    (c, customerOrders) => new
                    {
                        c.Name,
                        TotalAmount = customerOrders.Sum(o => o.Amount)
                    });

            Console.WriteLine("Total Order Amount Per Customer:");
            foreach (var item in totalPerCustomer)
            {
                Console.WriteLine($"{item.Name} - ₹{item.TotalAmount}");
            }

            // 2️⃣ Customers with no orders
            var customersWithNoOrders = customers
                .GroupJoin(orders,
                    c => c.Id,
                    o => o.CustomerId,
                    (c, customerOrders) => new
                    {
                        c.Name,
                        OrderCount = customerOrders.Count()
                    })
                .Where(x => x.OrderCount == 0);

            Console.WriteLine("\nCustomers With No Orders:");
            foreach (var item in customersWithNoOrders)
            {
                Console.WriteLine(item.Name);
            }

            // 3️⃣ Customers who spent above ₹50,000
            var bigSpenders = customers
                .GroupJoin(orders,
                    c => c.Id,
                    o => o.CustomerId,
                    (c, customerOrders) => new
                    {
                        c.Name,
                        TotalAmount = customerOrders.Sum(o => o.Amount)
                    })
                .Where(x => x.TotalAmount > 50000);

            Console.WriteLine("\nCustomers Who Spent Above ₹50,000:");
            foreach (var item in bigSpenders)
            {
                Console.WriteLine($"{item.Name} - ₹{item.TotalAmount}");
            }

            // 4️⃣ Sort customers by total spending (Descending)
            var sortedCustomers = customers
                .GroupJoin(orders,
                    c => c.Id,
                    o => o.CustomerId,
                    (c, customerOrders) => new
                    {
                        c.Name,
                        TotalAmount = customerOrders.Sum(o => o.Amount)
                    })
                .OrderByDescending(x => x.TotalAmount);

            Console.WriteLine("\nCustomers Sorted By Total Spending:");
            foreach (var item in sortedCustomers)
            {
                Console.WriteLine($"{item.Name} - ₹{item.TotalAmount}");
            }

            // 5️⃣ SelectMany Example (Flatten Customer + Orders)
            var customerOrderDetails = customers
                .GroupJoin(orders,
                    c => c.Id,
                    o => o.CustomerId,
                    (c, customerOrders) => new { c, customerOrders })
                .SelectMany(x => x.customerOrders,
                    (x, o) => new
                    {
                        x.c.Name,
                        o.OrderId,
                        o.Amount
                    });

            Console.WriteLine("\nCustomer Order Details (Flattened):");
            foreach (var item in customerOrderDetails)
            {
                Console.WriteLine($"{item.Name} - OrderId:{item.OrderId} - ₹{item.Amount}");
            }
        }
    }
}
