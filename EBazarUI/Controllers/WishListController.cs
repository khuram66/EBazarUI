using EBazarUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EBazarUI.Controllers
{
    public class WishListController : Controller
    {
        ECommerceDBEntities db = new ECommerceDBEntities();
        // GET: WishList
        public ActionResult Index()
        {
            this.GetDefaultData();

            var wishlistProducts = db.Wishlists.Where(x => x.Customer_ID == TempShpData.UserID).ToList();
            return View(wishlistProducts);
        }

        //REMOVE ITEM FROM WISHLIST
        public ActionResult Remove(int id)
        {
            db.Wishlists.Remove(db.Wishlists.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        //ADD TO CART WISHLIST
        //public ActionResult AddToCart(int id)
        //{
        //    OrderDetail OD = new OrderDetail();

        //    int pid = db.Wishlists.Find(id).Product_ID;
        //    OD.ProductID = pid;
        //    int Qty = 1;
        //    decimal price = db.Products.Find(pid).UnitPrice;
        //    OD.Quantity = Qty;
        //    OD.UnitPrice = price;
        //    OD.TotalAmount = Qty * price;
        //    OD.Product = db.Products.Find(pid);

        //    if (TempShpData.items == null)
        //    {
        //        TempShpData.items = new List<OrderDetail>();
        //    }
        //    TempShpData.items.Add(OD);

        //    db.Wishlists.Remove(db.Wishlists.Find(id));
        //    db.SaveChanges();

        //    return Redirect(TempData["returnURL"].ToString());

        //}
        //WISHLIST
        public ActionResult WishList(int id)
        {

            WishListViewModel wlvm = new WishListViewModel();
            wlvm.Product_ID = id;
            wlvm.Customer_ID = TempShpData.UserID;
            Wishlist wishlist = new Wishlist
            {
                Product_ID = wlvm.Product_ID,
                Customer_ID = wlvm.Customer_ID
            };
            db.Wishlists.Add(wishlist);
            db.SaveChanges();
            ProductController prodc = new ProductController();
            prodc.AddRecentViewProduct(id);
            ViewBag.WlItemsNo = db.Wishlists.Where(x => x.Customer_ID == TempShpData.UserID).ToList().Count();
            if (TempData["returnURL"].ToString() == "/")
            {
                return RedirectToAction("Index", "Home");
            }
            return Redirect(TempData["returnURL"].ToString());
        }
    }
}