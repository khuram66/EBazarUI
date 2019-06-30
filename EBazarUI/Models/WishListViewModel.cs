using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EBazarUI.Models
{
    public class WishListViewModel
    {
        public int ID { get; set; }
        public int Customer_ID { get; set; }
        public int Product_ID { get; set; }
        public Nullable<bool> isActive { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}