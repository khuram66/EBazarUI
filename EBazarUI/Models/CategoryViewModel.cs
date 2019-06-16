using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EBazarUI.Models
{
    public class CategoryViewModel
    {
        public int ID { get; set; }
        public string Category_Name { get; set; }
        public string Category_Image_Path { get; set; }
        public string Is_Active { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}