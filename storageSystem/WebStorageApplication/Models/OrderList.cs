using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStorageApplication.Models
{
    /// <summary>
    /// klasa szablonowa dla bazy
    /// </summary>
    public class OrderList
    {
        [Required, RangeAttribute(0,int.MaxValue)]
        public int id { get; set; }
        public DateTime? orderDate { get; set; }
        [Required, MinLength(7)]
        public string address { get; set; }
        [Required, MinLength(4)]
        public string delivery { get; set; }
        [Required]
        public string nameProduct { get; set; }
        [Required, RangeAttribute(0, int.MaxValue)]
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
        public OrderList() { }
        public OrderList(string nameProduct)
        {
            this.nameProduct = nameProduct;
        }
    }
}
