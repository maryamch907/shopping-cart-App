using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static List<Product> products = new List<Product>()
        {
            new Product(1, "Men's Dress", 4000, true),
            new Product(2, "Women's Dress", 6000, true),
            new Product(3, "Children's Dress", 3000, true),
            new Product(4, "Hat", 500, false),
            new Product(5, "Scarf", 700, false)
        };

        static List<CartItem> cart = new List<CartItem>();

        static void Main()
        {
            int choice;
            do
            {
                Console.WriteLine("\n=== Shopping Cart Menu ===");
                Console.WriteLine("1. Show Products");
                Console.WriteLine("2. Add to Cart");
                Console.WriteLine("3. View Cart");
                Console.WriteLine("4. Checkout");
                Console.WriteLine("0. Exit");
                Console.Write("Choose option: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1: ShowProducts(); break;
                    case 2: AddToCart(); break;
                    case 3: ViewCart(); break;
                    case 4: Checkout(); break;
                }
            } while (choice != 0);
        }

        static void ShowProducts()
        {
            Console.WriteLine("\n--- Products ---");
            foreach (var p in products)
            {
                Console.WriteLine($"{p.Id}. {p.Name} - Rs.{p.Price}");
            }
        }

        static void AddToCart()
        {
            ShowProducts();
            Console.Write("Enter product id: ");
            int id = int.Parse(Console.ReadLine());

            Product p = products.Find(x => x.Id == id);
            if (p == null) { Console.WriteLine("Invalid product."); return; }

            string fabric = "Cotton";
            if (p.IsDress)
            {
                Console.Write("Fabric (Cotton/Silk/Wool): ");
                fabric = Console.ReadLine();
            }

            Console.Write("Quantity: ");
            int qty = int.Parse(Console.ReadLine());

            Console.Write("Gift wrap (y/n): ");
            bool wrap = Console.ReadLine().ToLower() == "y";

            cart.Add(new CartItem(p, fabric, qty, wrap));
            Console.WriteLine("Item added to cart.");
        }

        static void ViewCart()
        {
            Console.WriteLine("\n--- Your Cart ---");
            int total = 0;
            foreach (var item in cart)
            {
                int price = item.GetPrice();
                Console.WriteLine($"{item.Product.Name} ({item.Fabric}) x{item.Quantity} = Rs.{price}");
                total += price;
            }
            Console.WriteLine($"Cart Total = Rs.{total}");
        }

        static void Checkout()
        {
            if (cart.Count == 0)
            {
                Console.WriteLine("Cart is empty.");
                return;
            }

            Console.WriteLine("\n--- Checkout ---");
            int total = 0;
            foreach (var item in cart)
            {
                int line = item.GetPrice();
                Console.WriteLine($"{item.Product.Name} ({item.Fabric}) x{item.Quantity} = Rs.{line}");
                total += line;
            }

            // Bulk discount: if 3+ same dress
            int bulkDiscount = 0;
            foreach (var item in cart)
            {
                if (item.Product.IsDress && item.Quantity >= 3)
                {
                    int linePrice = item.Product.Price * item.Quantity;
                    bulkDiscount += (linePrice * 10) / 100; // 10%
                }
            }
            total -= bulkDiscount;

            // Seasonal discount: if > 20000
            int seasonal = 0;
            if (total > 20000)
            {
                seasonal = (total * 5) / 100;
                total -= seasonal;
            }

            // Promo code
            Console.Write("Enter promo code (or press Enter): ");
            string code = Console.ReadLine();
            int promo = 0;
            if (code.ToUpper() == "SALE10")
            {
                promo = (total * 10) / 100;
                total -= promo;
            }

            Console.WriteLine($"Bulk Discount: Rs.{bulkDiscount}");
            Console.WriteLine($"Seasonal Discount: Rs.{seasonal}");
            Console.WriteLine($"Promo Discount: Rs.{promo}");
            Console.WriteLine($"Final Total = Rs.{total}");
            cart.Clear();
        

        }
    }
}
