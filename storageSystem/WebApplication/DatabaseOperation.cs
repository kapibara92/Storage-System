using storageSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication
{
    public class DatabaseOperation
    {
        private static WarehouseTEntities database;
        public static List<ProductList> showProducts()
        {
            List<ProductList>  Products = new List<ProductList>();
            using (WarehouseTEntities database = new WarehouseTEntities())
            {
                var list = database.showProducts();
                ProductList product;
                foreach (var i in list)
                {
                    product = new ProductList(i.id, i.code, i.name, i.guaranteeDate.Value, i.type, (i.quantity.Value));
                    Products.Add(product);
                }

            }
            return Products;
        }
        public static List<ProductList> filterProducts(string name = "", string code = "")
        {
            List<ProductList> filteredProducts=new List<ProductList>();
            filteredProducts = (from v in showProducts()
                                             where v.code.ToString().Contains(code)
                                             && v.name.Contains(name)
                                             select v).ToList<ProductList>();
            return filteredProducts;

        }
        public static void realiseOrder(string nameProduct, string method, string address, int? Quantity, long? codeProduct)
        {
            using (database=new WarehouseTEntities())
            {
                database.addOrder(nameProduct, method, address, Quantity, codeProduct);
                database.SaveChangesAsync();
            }
        }



    }
}