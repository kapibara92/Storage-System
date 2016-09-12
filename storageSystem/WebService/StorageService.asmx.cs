using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Services;
using WebService.Models;

namespace WebService
{
    /// <summary>
    /// Summary description for StorageService
    /// </summary>
    [WebService(Namespace = "http://storageService.org",Description ="WebServices sluzacy do poloczenia z bazą magazynu")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class StorageService : System.Web.Services.WebService
    {
        public StorageService()
        {

        }
        [WebMethod(Description ="dodawanie zamowienia", TransactionOption = TransactionOption.RequiresNew)]
        public void AddOrder(string nameProduct, string delivery,string address, int quantity, long code)
        {
            DatabaseOperation.realiseOrder(nameProduct, delivery, address, quantity, code);
        }

        [WebMethod(Description ="Wyswietlanie dostepnych produktow", BufferResponse =false, TransactionOption = TransactionOption.Required)]
        public List<ProductList> showProducts()
        {
           List<ProductList> productList= DatabaseOperation.showProducts();
            return productList;

        }
        [WebMethod(Description ="pobieranie dostepnych rodzajow przesylki",TransactionOption =TransactionOption.Required)]
        public List<string> getDeliveryType()
        {
            List<string> deliveryList= DatabaseOperation.showDeliveryType();
            return deliveryList;
        }
    }
}
