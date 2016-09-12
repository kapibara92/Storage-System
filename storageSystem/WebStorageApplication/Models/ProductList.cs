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
    public class ProductList
    {
        public int id { get; set; }
        public long code { get; set; }
        public string name { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public Nullable<System.DateTime> guaranteeDate { get; set; }
        public string Type { get; set; }
        [Required, RangeAttribute(0, int.MaxValue)]
        public Nullable<int> quantity { get; set; }

        /// <summary>
        /// nowy produkt
        /// </summary>
        /// <param name="id">id produktu</param>
        /// <param name="code">kod produktu</param>
        /// <param name="name">nazwa produktu</param>
        /// <param name="date">data gwarancji</param>
        /// <param name="type">rodzaj produktu</param>
        /// <param name="quantity">ilość produktu</param>
        public ProductList(int id, long code, string name, DateTime date, string type, int quantity)
        {
            this.id = id;
            this.code = code;
            this.name = name;
            this.guaranteeDate = date;
            this.Type = type;
            this.quantity = quantity;
        }
    }
}
