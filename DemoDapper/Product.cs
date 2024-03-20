using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDapper
{
    public class Product // Model, represents the properties of the data columns
    {
        public int ProductID { get; set; } // Primary Key
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool OnSale { get; set; }
        public string StockLevel { get; set; }

    }
}
