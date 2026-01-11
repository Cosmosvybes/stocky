using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Inventory.Functions;
namespace Inventory

{
    public class Store
    {
        public string Name { set; get; }
        public bool IsOpen { set; get; }

        public List<Product> ProductList { set; get; } = [];

        public async Task AddSingleProduct(Product product)
        {

            Product existing_product = ProductList.Find(p => p.Name == product.Name);
            if (existing_product != null)
            {
                existing_product.Quantity = product.Quantity;
                existing_product.Price = product.Price;
                existing_product.IsAvailable = product.IsAvailable;
                Console.WriteLine("Product exist, quantity updated");
                return;
            }
            ProductList.Add(product);
            Console.WriteLine("Adding new product...please wait");
            await Task.Delay(4000);
            Console.WriteLine(product.Name + " new Product successfully added to " + Name + "✅");
            Console.WriteLine("Store length is: " + ProductList.Count);
        }

        public async Task DeleteProduct(Product product)
        {
            bool deleted = ProductList.Remove(product);
            if (deleted)
            {
                Console.WriteLine(product.Name + " successfully removed from the store");
                Brain.SaveData();
            }
            else
            {
                Console.WriteLine("Operation failed");
            }
        }
        public async Task UpdateProductPrice(Product _product, double value)
        {
            Product product = ProductList.Find(p => p == _product);
            product.Price = value;
            Console.WriteLine("product price has been updated to new price " + product.Price);
            Brain.SaveData();
        }
        public async Task LogSales(Product _product, int quatity_sold)
        {
            Product product = ProductList.Find(p => p == _product);
            Console.WriteLine("current quantity is " + product.Quantity);
            product.Quantity -= quatity_sold;
            Console.WriteLine("new quantity is " + product.Quantity);
        }

    }
}