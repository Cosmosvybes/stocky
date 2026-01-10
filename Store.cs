using System;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace Inventory

{
    class Store
    {
        public string Name;
        private readonly bool IsOpen;

        private readonly List<Product> product_list = [];

        public async Task AddSingleProduct(string _name, double _price, bool _status, int _quantity)
        {
            Product product = new() { Name = _name, IsAvailable = _status, Price = _price, Quantity = _quantity };
            product_list.Add(product);
            Console.WriteLine("Adding new product..... please wait");
            await Task.Delay(4000);
            Console.WriteLine(product.Name + " New Product successfully added to " + Name + "✅");

        }
        public async Task AddManyProduct()
        {

        }
        public void DeleteProduct()
        {

        }
        public void UpdateProduct()
        {

        }
        public async Task ReadProduct(string _stock_name)
        {

        }
    }
}