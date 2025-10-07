using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class CartItem
    {
        public Product Product;  // Product reference
        public string Fabric;    // Cotton/Silk/Wool (only for dresses)
        public int Quantity;     // Quantity of product
        public bool GiftWrap;    // Gift wrap option

        public CartItem(Product product, string fabric, int qty, bool giftWrap)
        {
            Product = product;
            Fabric = fabric;
            Quantity = qty;
            GiftWrap = giftWrap;
        }

        public int GetPrice()
        {
            int finalPrice = Product.Price;

            // Fabric cost (only for dresses)
            if (Product.IsDress)
            {
                if (Fabric.ToLower() == "silk") finalPrice += 500;
                else if (Fabric.ToLower() == "wool") finalPrice += 700;
                // Cotton → no extra cost
            }

            // Price with quantity and gift wrap
            return finalPrice * Quantity + (GiftWrap ? 200 * Quantity : 0);
        }
    
    }
}
