using DemoInheritance.Entities;
using System.Globalization;

namespace DemoInheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of products: ");
            int n = Convert.ToInt32(Console.ReadLine());
            List<Product> products = new List<Product>();
            for (int i = 1;  i <= n; i++)
            {
                Console.WriteLine($"Product #{i} data:");
                Console.Write("Common, used or imported (c/u/i): ");
                char ch = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Price : ");
                double price = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture);

                if(ch == 'c' || ch == 'C')
                {
                    products.Add(new Product(name, price));
                }
                else if (ch == 'i' || ch == 'I')
                {
                    Console.Write("Customs fee : ");
                    double customsFee = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture);
                    products.Add(new ImportedProduct(name!, price,customsFee));
                }
                else
                {
                    Console.Write("Manufacture date (DD/MM/YYYY) : ");
                    DateTime date = DateTime.Parse(Console.ReadLine());
                    products.Add(new UsedProduct(name!, price, date));
                }
            }
            Console.WriteLine("\nPRICE TAGS:");
            foreach(Product product in products)
            {
                Console.WriteLine(product.PriceTag());
            }
        }
    }
}