//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int id { get; set; }
        public Nullable<System.DateTime> orderDate { get; set; }
        public string address { get; set; }
        public int delivery { get; set; }
        public int IdProduct { get; set; }
        public Nullable<int> quantity { get; set; }
    
        public virtual DeliveryMethod DeliveryMethod { get; set; }
        public virtual Product Product { get; set; }
    }
}
