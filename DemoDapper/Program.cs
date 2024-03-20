using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using DemoDapper;
//^^^^MUST HAVE USING DIRECTIVES^^^^

var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
string connString = config.GetConnectionString("DefaultConnection");

IDbConnection conn = new MySqlConnection(connString);

//var departmentRepo = new DepartmentRepo(conn);

//var departments = departmentRepo.GetAllDepartments();

// departmentRepo.InsertDepartment("Home Entertainment");

//foreach (var department in departments)
//{
//    Console.WriteLine($"{department.DepartmentID} | {department.Name}");
//}


var productRepo = new DapperProductRepo(conn);

// productRepo.CreateProduct("Cyberpunk 2077", 79.99m, 8, false, 150);

// productRepo.DeleteProduct(945);

// productRepo.UpdateProductName(944, "Cyberpunk 2077: Phantom Liberty");

var products = productRepo.GetAllProducts();

Console.WriteLine("------------------------------------------------------------------------------------------------------------------");

foreach (var product in products)
{
    Console.WriteLine($"ID: {product.ProductID} | NAME: {product.Name} | PRICE: ${product.Price} " +
                      $"| ON SALE: {product.OnSale} | STOCK: {product.StockLevel}\n");
}

