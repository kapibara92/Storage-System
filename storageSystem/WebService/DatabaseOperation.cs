using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.Models;

namespace WebService
{
    /// <summary>
    /// klasa zawierająca statyczne metody operujące na bazie danych
    /// </summary>
    public class DatabaseOperation
    {
        private static WarehouseTEntities database;
        /// <summary>
        /// metoda, która zwraca liste dostępnych produktów
        /// </summary>
        /// <returns></returns>
        public static List<ProductList> showProducts()
        {
            try
            {
                List<ProductList> Products = new List<ProductList>();

                using (WarehouseTEntities database = new WarehouseTEntities())
                {
                    var list = database.getAvailableProducts();
                    ProductList product;
                    foreach (var i in list)
                    {
                        product = new ProductList(i.id, i.code, i.name, i.guaranteeDate.Value, i.type, (i.quantity.Value));
                        Products.Add(product);
                    }

                }
                return Products;
            }
            catch
            {
                throw new InvalidOperationException("error during processing database");
            }
        }

        /// <summary>
        /// metoda zwracająca rodzaj przesyłki
        /// </summary>
        /// <returns></returns>
        public static List<string> showDeliveryType()
        {
            try {
                List<string> deliveryType=new List<string>();
                using (WarehouseTEntities database=new WarehouseTEntities())
                {
                    deliveryType = database.showMethodDelivery().ToList<string>();
                }
                return deliveryType;
            }
            catch {
                throw new InvalidOperationException("error during processing database");
            }
        }

        /// <summary>
        /// metoda dodająca zamówienie do bazy
        /// </summary>
        /// <param name="nameProduct">nazwa produktu</param>
        /// <param name="method">metoda przesyłki</param>
        /// <param name="address">adres przesyłki</param>
        /// <param name="Quantity">ilość zamówionych produktów</param>
        /// <param name="codeProduct">kod produktu</param>
        public static void realiseOrder(string nameProduct, string method, string address, int? Quantity, long? codeProduct)
        {
            try
            {
                if (Quantity >= 0 && codeProduct != null)
                {
                    using (database = new WarehouseTEntities())
                    {
                        database.addOrder(nameProduct, method, address, Quantity, codeProduct);
                        database.SaveChangesAsync();
                    }
                }
                else
                {
                    throw new Exception("Data coudn't be updated");
                }
            }
            catch { }
        }



    }
}