using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EBazarUI.Models
{
    public class OrderViewModel
    {
        public int ID { get; set; }
        public Nullable<int> Discount { get; set; }
        public Nullable<int> Taxes { get; set; }
        public Nullable<int> TotalAmount { get; set; }
        public Nullable<bool> isCompleted { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public Nullable<bool> DIspatched { get; set; }
        public Nullable<System.DateTime> DispatchedDate { get; set; }
        public Nullable<bool> Shipped { get; set; }
        public Nullable<System.DateTime> ShippingDate { get; set; }
        public Nullable<bool> Deliver { get; set; }
        public Nullable<System.DateTime> DeliveryDate { get; set; }
        public string Notes { get; set; }
        public Nullable<bool> CancelOrder { get; set; }
        public Nullable<int> ProductID { get; set; }
        public Nullable<int> CustomerID { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
        
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }

        public Nullable<int> OrderID { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public Nullable<int> Quantity { get; set; }

        public virtual Order Order { get; set; }

    }
}