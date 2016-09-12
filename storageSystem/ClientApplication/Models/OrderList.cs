using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApplication.Models
{
    public class OrderList
    {
        public int id { get; set; }
        public DateTime? orderDate { get; set; }
        public string address { get; set; }
        public string delivery { get; set; }
        public string nameProduct { get; set; }
        public int quantity { get; set; }
        public OrderList(int id, DateTime? date, string address, string delivery, string nameProduct, int Quantity)
        {
            this.id = id;
            this.orderDate = date;
            this.address = address;
            this.delivery = delivery;
            this.nameProduct = nameProduct;
            this.quantity = Quantity;
        }
    }
}
