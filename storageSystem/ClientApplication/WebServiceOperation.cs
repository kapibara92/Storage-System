using ClientApplication.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApplication
{
    public class WebServiceOperation
    {

        /// <summary>
        /// metoda dodająca zamówienie do bazy danych
        /// </summary>
        /// <param name="nameProduct">nazwa produktu</param>
        /// <param name="delivery">rodzaj przesyłki</param>
        /// <param name="address">adres przesyłki</param>
        /// <param name="quantity">ilość produktu</param>
        /// <param name="code">kod produktu</param>
        public static  void addOrder(string nameProduct, string delivery, string address, int quantity, long code)
        {
            try
            {
                if (quantity >= 0 && code >= 0 && delivery!=null && address !=null)
                {
                    using (ServiceReference.StorageServiceSoapClient client = new ServiceReference.StorageServiceSoapClient())
                    {
                        client.AddOrderAsync(nameProduct, delivery, address, quantity, code);
                        client.Close();
                    }
                }
                else
                {
                    throw new ArgumentException(" Wrong data format");
                }
            }
            catch (Exception e) {
                System.Windows.MessageBox.Show("error while trying connect to server: " + e.Message.ToString());
            }
        }

        /// <summary>
        /// metoda zwracająca kolekcję  produktów
        /// </summary>
        /// <returns>kolekcja produktów</returns>
        public static ObservableCollection<ProductList> showProducts()
        {
            ObservableCollection<ProductList> Products=new ObservableCollection<ProductList>();
            ProductList product;
            using (ServiceReference.StorageServiceSoapClient client = new ServiceReference.StorageServiceSoapClient())
            {
                var tymData = client.showProducts();
                foreach (var row in tymData)
                {
                    product = new ProductList(row.id, row.code, row.name, row.guaranteeDate, row.Type, row.quantity);
                    Products.Add(product);
                }
                client.Close();
            }
            return Products;
        }

        /// <summary>
        /// metoda zwracająca metody wysyłki towaru
        /// </summary>
        /// <returns>lista rodzajów dostawy</returns>
        public static IEnumerable<string> showDeliveryMethod()
        {
            IEnumerable<string> DeliveryMethods;
            using(ServiceReference.StorageServiceSoapClient client=new ServiceReference.StorageServiceSoapClient())
            {
                DeliveryMethods = client.getDeliveryType();
            }
            return DeliveryMethods;
        }
        }
    }
