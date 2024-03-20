using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DemoDapper
{
    public class DapperProductRepo : IProductRepo
    {
        private readonly IDbConnection _conn;
        public DapperProductRepo(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _conn.Query<Product>("SELECT * FROM products");
        }

        public void CreateProduct(string newProductName, decimal newProductPrice, int newProductCategoryID, bool newOnSale, int newStockLevel)
        {
            _conn.Execute("INSERT INTO products (Name, Price, CategoryID, OnSale, StockLevel) " +
                          "VALUES (@newProductName, @newProductPrice, @newProductCategoryID, @newOnSale, @newStockLevel)",
                          new { newProductName, newProductPrice, newProductCategoryID, newOnSale, newStockLevel });
        }

        public void UpdateProductName(int productID, string newName)
        {
            _conn.Execute("UPDATE products " +
                          "SET Name = @newName " +
                          "WHERE ProductID = @productID ", new { productID, newName });
        }

        public void DeleteProduct(int productID)
        {
            _conn.Execute("DELETE FROM reviews WHERE ProductID = @productID", new { productID });
            _conn.Execute("DELETE FROM sales WHERE ProductID = @productID", new { productID });
            _conn.Execute("DELETE FROM products WHERE ProductID = @productID", new { productID });
        }
    }
}
