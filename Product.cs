using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Product
    {
        public int Id;        // Product number
        public string Name;   // Product name
        public int Price;     // Base price
        public bool IsDress;  // Dress or Accessory

        public Product(int id, string name, int price, bool isDress)
        {
            Id = id;
            Name = name;
            Price = price;
            IsDress = isDress;
        }
    }

}

