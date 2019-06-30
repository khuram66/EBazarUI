using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EBazarUI.Models
{
    public class TopSoldProductModel
    {
        public Product product { get; set; }
        public int countSold { get; set; }
    }
}