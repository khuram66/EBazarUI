using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EBazarUI.Models
{
    public class ProductViewModel
    {

        public int ID { get; set; }
        public string Product_Name { get; set; }
        public string Producct_Short_Description { get; set; }
        public string Product_Long_Description { get; set; }
        public string Is_Active { get; set; }
        public string Is_Featured { get; set; }
        public string Is_OnSale { get; set; }
        public Nullable<int> Product_Price { get; set; }
        public Nullable<int> Product_Sale_Price { get; set; }
        public Nullable<int> Product_Quantity { get; set; }
        public string Product_Feature_Image { get; set; }
        public HttpPostedFileBase FeatureImage { get; set; }
        public string Product_Size { get; set; }
        public Nullable<int> Vendor_ID { get; set; }
        public Nullable<int> Category_ID { get; set; }
        public string Created_By { get; set; }
        public string Modified_By { get; set; }
        public Nullable<System.DateTime> Created_On { get; set; }
        public Nullable<System.DateTime> Modified_On { get; set; }

        public virtual ICollection<Order> Order { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<ProdcutImages> ProdcutImages { get; set; }
        public virtual Vendor Vendor { get; set; }

        public string Product_image { get; set; }
        public HttpPostedFileBase[] ProductImages { get; set; }
        public Nullable<int> Product_ID { get; set; }

        public virtual Product Product { get; set; }


    }
}