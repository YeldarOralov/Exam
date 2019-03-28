using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductList<Product> productList = new ProductList<Product>();
            productList.ProductAdded += ConsoleMessage;
            productList.Add(new Product() { Name = "Coca-Cola", Description = "carbonated drink" });


            Console.Read();
        }

        public static void ConsoleMessage(string text)
        {
            Console.WriteLine(text);
        }
    }
}
