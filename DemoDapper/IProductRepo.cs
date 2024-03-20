using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDapper
{
    public interface IProductRepo
    {
        public IEnumerable<Product> GetAllProducts();
        public void CreateProduct(string name, decimal price, int categoryID, bool newOnSale, int newStockLevel);
        public void UpdateProductName(int productID, string newName);
        public void DeleteProduct(int productID);
    }
}
