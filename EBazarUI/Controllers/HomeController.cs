using EBazarUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EBazarUI.Controllers
{
    public class HomeController : Controller
    {
        ECommerceDBEntities db = new ECommerceDBEntities();
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.MenProduct = db.Products.Where(x => x.Category.Category_Name.Equals("Men")).ToList();
            ViewBag.WomenProduct = db.Products.Where(x => x.Category.Category_Name.Equals("Women")).ToList();
            ViewBag.SportsProduct = db.Products.Where(x => x.Category.Category_Name.Equals("Sports")).ToList();
            ViewBag.ElectronicsProduct = db.Products.Where(x => x.Category.Category_Name.Equals("Phones")).ToList();
            //ViewBag.Slider = db.genMainSliders.ToList();
            this.GetDefaultData();
            return View();
        }
    }
}