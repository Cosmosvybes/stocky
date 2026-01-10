using System;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace Inventory

{
    class Store
    {
        public string Name;
        private readonly bool IsOpen;

        public List<Product> product_list = [];

        public async Task AddSingleProduct(Product product)
        {
            product_list.Add(product);
            Console.WriteLine("Adding new product...please wait");
            await Task.Delay(4000);
            Console.WriteLine(product.Name + " new Product successfully added to " + Name + "✅");
            Console.WriteLine("Store length is: " + product_list.Count);
        }

        public async Task DeleteProduct(Product product)
        {
            bool deleted = product_list.Remove(product);
            if (deleted) Console.WriteLine(product.Name + " successfully removed from the store");
            else
            {
                Console.WriteLine("Operation failed");
            }
        }
        public async Task UpdateProductPrice(Product _product, double value)
        {
            Product product = product_list.Find(p => p == _product);
            product.Price = value;
            Console.WriteLine("product price has been updated to new price " + product.Price);
        }

    }
}