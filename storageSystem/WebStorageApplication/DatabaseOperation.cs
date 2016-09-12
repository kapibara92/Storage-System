using WebStorageApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebStorageApplication.Models;
using System.Web.Services;
using System.Web.Script.Services;

namespace WebStorageApplication
{
    /// <summary>
    /// clasa przechowująca metody statyczne łączące się z bazą danych
    /// wysyłające/odbierające dane
    /// </summary>
    public class DatabaseOperation
    {
        private static WarehouseTEntities database;
        /// <summary>
        /// funckcja zwraca listę wszystkich produktów
        /// </summary>
        /// <returns>lista produktów</returns>
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
        /// <summary>
        /// funkcja filtrująca produkty po kodzie i nazwa
        /// </summary>
        /// <param name="name">nazwa produktu</param>
        /// <param name="code">kod produktu</param>
        /// <returns>lista produktów</returns>
        public static List<ProductList> filterProducts(string name = "", string code = "")
        {
            List<ProductList> filteredProducts=new List<ProductList>();
            filteredProducts = (from v in showProducts()
                                             where v.code.ToString().Contains(code)
                                             && v.name.Contains(name)
                                             select v).ToList<ProductList>();
            return filteredProducts;

        }
        /// <summary>
        /// funkcja realizująca zamówienie
        /// </summary>
        /// <param name="nameProduct">nazwa zamówionego produktu</param>
        /// <param name="method">metoda wysyłki</param>
        /// <param name="address">adres wysyłki</param>
        /// <param name="Quantity">ilość</param>
        /// <param name="codeProduct">kod produktu</param>
        public static void realiseOrder(string nameProduct, string method, string address, int? Quantity, long? codeProduct)
        {
            using (database=new WarehouseTEntities())
            {
                database.addOrder(nameProduct, method, address, Quantity, codeProduct);
                database.SaveChangesAsync();
            }
        }

        /// <summary>
        /// funkcja zwaracąca listę zapisanych metod wysyłki
        /// </summary>
        /// <returns>lista rodzaju wysyłki</returns>
        public static List<string> showMatchDelivery() {
           List<string> deliveryMethods=new List<string>();
            using (database = new WarehouseTEntities())
            {
                deliveryMethods = database.showMethodDelivery().ToList<string>();
            }
            return deliveryMethods;
        }



    }
}