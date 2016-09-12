﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService.Models
{
    public class ProductList
    {
        public int id { get; set; }
        public long code { get; set; }
        public string name { get; set; }
        public Nullable<System.DateTime> guaranteeDate { get; set; }
        public string Type { get; set; }
        [Range(typeof(int), "0", "2147483647")]
        public Nullable<int> quantity { get; set; }
        public ProductList() {  }
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
