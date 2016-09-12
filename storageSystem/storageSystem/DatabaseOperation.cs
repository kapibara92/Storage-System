using storageSystem.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace storageSystem
{
    /// <summary>
    /// klasa zawierająca funkcje statyczne operujące na bazie danych
    /// </summary>
    public class DatabaseOperation
    {
        static WarehouseTEntities database;

        /// <summary>
        /// metoda dodająca produkt
        /// </summary>
        /// <param name="Code">kod produktu</param>
        /// <param name="Name">nazwa produktu</param>
        /// <param name="Date">data grawanrcji</param>
        /// <param name="Type">typ produktu</param>
        /// <param name="Quantity">ilość produktu</param>
        public static void addProduct(long Code, string Name, DateTime? Date, string Type, int Quantity)
        {
            using (database = new WarehouseTEntities())
            {
                database.insertWare(Code, Name, Date, Quantity, Type);
                database.SaveChangesAsync();
            }
        }

        /// <summary>
        /// metoda edytująca produkt w bazie
        /// </summary>
        /// <param name="Code">kod produktu</param>
        /// <param name="Name">nazwa produktu</param>
        /// <param name="Date">data grawanrcji</param>
        /// <param name="Type">typ produktu</param>
        /// <param name="Quantity">ilość produktu</param>
        public static void editProduct(int Id, long Code, string Name, DateTime? Date, string Type, int Quantity)
        {
            try
            {
                using (database = new WarehouseTEntities())
                {
                    database.editProducts(Id, Code, Name, Date, Type, Quantity);
                    database.SaveChangesAsync();
                }
            }
            catch(Exception e)
            {
                throw new InvalidOperationException("data coudn't be updated");
            }
        }

        /// <summary>
        /// metoda realizująca zamówienie
        /// </summary>
        /// <param name="id">id zamówienia</param>
        public static void realiseOrder(int id)
        {
            using (database = new WarehouseTEntities())
            {
                database.realizeOrders(id);
                database.SaveChangesAsync();
            }
        }

        /// <summary>
        /// metoda usuwająca produkt z bazy
        /// </summary>
        /// <param name="Id">id produktu</param>
        public static void deleteProduct(int Id)
        {
            using (database = new WarehouseTEntities())
            {
                database.deleteUnsolicitedProducts(Id);
                database.SaveChanges();
            }
        }
        /// <summary>
        /// metoda filtrująca produkty 
        /// </summary>
        /// <param name="Code">filtr po kodzie produktu</param>
        /// <param name="Name">filtr po nazwie produktu</param>
        /// <returns>lkolekcja produktów</returns>
        public static ObservableCollection<ProductList> filterProducts(string Code, string Name)
        {
            IEnumerable<ProductList> data = (from v in getProducts()
                                             where v.code.ToString().Contains(Code)
                                             && v.name.Contains(Name)
                                             select v).ToList<ProductList>();
           ObservableCollection<ProductList> ProductList = new ObservableCollection<Models.ProductList>(data);
            return ProductList;
        }

        /// <summary>
        /// metoda pobierająca wszystkie produkty z bazy
        /// </summary>
        /// <returns>kolekcja produktów</returns>
        public static ObservableCollection<ProductList> getProducts()
        {
            ObservableCollection<ProductList> productList = new ObservableCollection<Models.ProductList>(); ;
            using (database = new WarehouseTEntities())
            {
                var list = database.showProducts().ToList();
                string type = list.ToString();
                ProductList product;
                foreach (var i in list)
                {
                    product = new ProductList(i.id, i.code, i.name, i.guaranteeDate.Value, i.type, (i.quantity.Value));
                    productList.Add(product);
                }
            }
            return productList;
        }

        /// <summary>
        /// metoda pobierająca zamówienia z bazy
        /// </summary>
        /// <returns>kolekcja zamówień</returns>
        public static ObservableCollection<OrderList> getOrders()
        {
            ObservableCollection<OrderList> orders = new ObservableCollection<OrderList>();
            OrderList order;
            using (database = new WarehouseTEntities())
            {
                var entities = database.showOrders();
                foreach (var i in entities)
                {
                    order = new OrderList(i.id, i.orderDate, i.address, i.method, i.name, i.quantity.Value);
                    orders.Add(order);
                }
                return orders;
            }
        }
    }
}
