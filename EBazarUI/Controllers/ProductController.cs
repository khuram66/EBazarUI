using EBazarUI.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace EBazarUI.Controllers
{
    public class ProductController : Controller
    {
        ECommerceDBEntities db = new ECommerceDBEntities();
        // GET: Prodcut
        [HttpGet]
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }
        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.categoryID = new SelectList(db.Categories, "ID", "Category_Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ProductViewModel pvm)
        {

            if (ModelState.IsValid)
            {
                if (pvm.FeatureImage != null)
                {
                    var featureimage = Path.GetFileNameWithoutExtension(pvm.FeatureImage.FileName);
                    var extention = Path.GetExtension(pvm.FeatureImage.FileName);
                    featureimage = featureimage + "_" + DateTime.Now.Date.ToString("ddMMyyyy") + extention;
                    pvm.Product_Feature_Image = "~/ProductImages/" + featureimage;
                    var serverpath = Path.Combine(Server.MapPath("~/ProductImages/"), featureimage);
                    pvm.FeatureImage.SaveAs(serverpath);
                }
                else
                {
                    pvm.Product_Feature_Image = null;
                }

                Product prod = new Product
                {
                    Product_Name = pvm.Product_Name.Trim(),
                    Producct_Short_Description = pvm.Producct_Short_Description.Trim(),
                    Product_Long_Description = pvm.Product_Long_Description.Trim(),
                    Product_Price = pvm.Product_Price,
                    Product_Sale_Price = pvm.Product_Sale_Price,
                    Product_Quantity = pvm.Product_Quantity,
                    Is_OnSale = pvm.Is_OnSale.Trim(),
                    Is_Active = pvm.Is_Active.Trim(),
                    Is_Featured = pvm.Is_Featured,
                    Category_ID = pvm.Category_ID,
                    Product_Feature_Image = pvm.Product_Feature_Image

                };
                db.Products.Add(prod);

                foreach (HttpPostedFileBase file in pvm.ProductImages)
                {
                    if (file != null)
                    {
                        var InputImg = Path.GetFileNameWithoutExtension(file.FileName);
                        var extention = Path.GetExtension(file.FileName);
                        InputImg = InputImg + "_" + DateTime.Now.Date.ToString("ddMMyyyy") + extention;
                        pvm.Product_image = "~/ProductImages/" + InputImg;
                        var ServerSavePath = Path.Combine(Server.MapPath("~/ProductImages/") + InputImg);
                        file.SaveAs(ServerSavePath);
                        ProductImage pimg = new ProductImage
                        {
                            Product_ID = pvm.ID,
                            Product_image = pvm.Product_image
                        };
                        db.ProductImages.Add(pimg);
                    }
                    else
                    {
                        pvm.Product_Feature_Image = null;
                    }
                }



                db.SaveChanges();
                return RedirectToAction("Index", "Product");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int? Id)
        {
            Product prod = db.Products.Where(x => x.ID == Id).FirstOrDefault();
            IEnumerable<ProductImage> pimg = db.ProductImages.Where(x => x.Product_ID == Id).ToList();
            ProductViewModel pvm = new ProductViewModel();
            pvm.Product_Name = prod.Product_Name;
            pvm.Producct_Short_Description = prod.Producct_Short_Description;
            pvm.Product_Long_Description = prod.Product_Long_Description;
            pvm.Product_Price = prod.Product_Price;
            pvm.Product_Sale_Price = prod.Product_Sale_Price;
            pvm.Product_Quantity = prod.Product_Quantity;
            pvm.Is_OnSale = prod.Is_OnSale;
            pvm.Is_Active = prod.Is_Active;
            pvm.Is_Featured = prod.Is_Featured;
            pvm.Category_ID = prod.Category_ID;
            pvm.Product_Feature_Image = prod.Product_Feature_Image;
            foreach (var proimg in pimg)
            {
                pvm.Product_image = proimg.Product_image;
            }
            return View(pvm);
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int? Id)
        //{
        //    Product prod = db.Products.Where(x => x.ID == Id).FirstOrDefault();
        //    IEnumerable<ProdcutImages> pimg = db.ProdcutImages.Where(x => x.Product_ID == Id).ToList();
        //    ProductViewModel pvm = new ProductViewModel();
        //    pvm.Product_Name = prod.Product_Name;
        //    pvm.Producct_Short_Description = prod.Producct_Short_Description;
        //    pvm.Product_Long_Description = prod.Product_Long_Description;
        //    pvm.Product_Price = prod.Product_Price;
        //    pvm.Product_Sale_Price = prod.Product_Sale_Price;
        //    pvm.Product_Quantity = prod.Product_Quantity;
        //    pvm.Is_OnSale = prod.Is_OnSale;
        //    pvm.Is_Active = prod.Is_Active;
        //    pvm.Is_Featured = prod.Is_Featured;
        //    pvm.Category_ID = prod.Category_ID;
        //    pvm.Product_Feature_Image = prod.Product_Feature_Image;
        //    foreach (var proimg in pimg)
        //    {
        //        pvm.Product_image = proimg.Product_image;
        //    }
        //    return View(pvm);
        //}

        [HttpGet]
        public ActionResult Details(int? id)
        {
            IEnumerable<ProductImage> pimg = db.ProductImages.Where(x => x.Product_ID == id).ToList();
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            else
            {
                ProductViewModel pvm = new ProductViewModel();
                pvm.Product_Name = product.Product_Name;
                pvm.Producct_Short_Description = product.Producct_Short_Description;
                pvm.Product_Long_Description = product.Product_Long_Description;
                pvm.Product_Price = product.Product_Price;
                pvm.Product_Sale_Price = product.Product_Sale_Price;
                pvm.Product_Quantity = product.Product_Quantity;
                pvm.Is_OnSale = product.Is_OnSale;
                pvm.Is_Active = product.Is_Active;
                pvm.Is_Featured = product.Is_Featured;
                pvm.Category_ID = product.Category_ID;
                pvm.Product_Feature_Image = product.Product_Feature_Image;
                foreach (var proimg in pimg)
                {
                    pvm.Product_image = proimg.Product_image;
                }
                return View(pvm);
            }

        }


        [HttpGet]
        public ActionResult Delete(int? id)
        {
            IEnumerable<ProductImage> pimg = db.ProductImages.Where(x => x.Product_ID == id).ToList();
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            else
            {
                ProductViewModel pvm = new ProductViewModel();
                pvm.Product_Name = product.Product_Name;
                pvm.Producct_Short_Description = product.Producct_Short_Description;
                pvm.Product_Long_Description = product.Product_Long_Description;
                pvm.Product_Price = product.Product_Price;
                pvm.Product_Sale_Price = product.Product_Sale_Price;
                pvm.Product_Quantity = product.Product_Quantity;
                pvm.Is_OnSale = product.Is_OnSale;
                pvm.Is_Active = product.Is_Active;
                pvm.Is_Featured = product.Is_Featured;
                pvm.Category_ID = product.Category_ID;
                pvm.Product_Feature_Image = product.Product_Feature_Image;
                foreach (var proimg in pimg)
                {
                    pvm.Product_image = proimg.Product_image;
                }
                return View(pvm);
            }

        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[ActionName ("Delete")]
        //public ActionResult DeleteConfirm(int? id)
        //{
        //    IEnumerable<ProductImages> pimg = db.ProductImages.Where(x => x.Product_ID == id).ToList();
        //    Product product = db.Products.Find(id);
        //    if (product == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    else
        //    {
        //        ProductViewModel pvm = new ProductViewModel();
        //        pvm.Product_Name = product.Product_Name;
        //        pvm.Producct_Short_Description = product.Producct_Short_Description;
        //        pvm.Product_Long_Description = product.Product_Long_Description;
        //        pvm.Product_Price = product.Product_Price;
        //        pvm.Product_Sale_Price = product.Product_Sale_Price;
        //        pvm.Product_Quantity = product.Product_Quantity;
        //        pvm.Is_OnSale = product.Is_OnSale;
        //        pvm.Is_Active = product.Is_Active;
        //        pvm.Is_Featured = product.Is_Featured;
        //        pvm.Category_ID = product.Category_ID;
        //        pvm.Product_Feature_Image = product.Product_Feature_Image;
        //        foreach (var proimg in pimg)
        //        {
        //            pvm.Product_image = proimg.Product_image;
        //        }
        //        return View(pvm);
        //    }

        //}

        //GET PRODUCTS BY CATEGORY
        public ActionResult GetProductsByCategory(string categoryName, int? page)
        {
            ViewBag.Categories = db.Categories.Select(x => x.Category_Name).ToList();
            ViewBag.TopRatedProducts = TopSoldProducts();

            ViewBag.RecentViewsProducts = RecentViewProducts();

            var prods = db.Products.Where(x => x.Category.Category_Name == categoryName).ToList();
            return View("Products", prods.ToPagedList(page ?? 1, 9));
        }


        //TOP SOLD PRODUCTS
        public List<TopSoldProductModel> TopSoldProducts()
        {
            var prodList = (from prod in db.OrderDetails
                            from order in db.Orders
                            where prod.OrderID.Equals(order.ID)
                            select new { order.ProductID, prod.Quantity } into p
                            group p by p.ProductID into g
                            select new
                            {
                                pID = g.Key,
                                sold = g.Sum(x => x.Quantity)
                            }).OrderByDescending(y => y.sold).Take(3).ToList();



            List<TopSoldProductModel> topSoldProds = new List<TopSoldProductModel>();

            for (int i = 0; i < 3; i++)
            {
                topSoldProds.Add(new TopSoldProductModel()
                {
                    product = db.Products.Find(prodList[i].pID),
                    countSold = Convert.ToInt32(prodList[i].sold)
                });
            }
            return topSoldProds;
        }

        //RECENT VIEWS PRODUCTS
        public IEnumerable<Product> RecentViewProducts()
        {
            if (TempShpData.UserID > 0)
            {
                var top3Products = (from recent in db.RecentlyViews
                                    where recent.Customer_ID == TempShpData.UserID
                                    orderby recent.ViewDate descending
                                    select recent.Product_ID).ToList().Take(3);

                var recentViewProd = db.Products.Where(x => top3Products.Contains(x.ID));
                return recentViewProd;
            }
            else
            {
                var prod = (from p in db.Products
                            select p).OrderByDescending(x => x.Product_Price).Take(3).ToList();
                return prod;
            }
        }

        //VIEW DETAILS
        public ActionResult ViewDetails(int id)
        {
            var prod = db.Products.Find(id);
            var reviews = db.Reviews.Where(x => x.Product_ID == id).ToList();
            ViewBag.Reviews = reviews;
            ViewBag.TotalReviews = reviews.Count();
            ViewBag.RelatedProducts = db.Products.Where(y => y.Category_ID == prod.Category_ID).ToList();
            AddRecentViewProduct(id);
            
            int count = reviews.Count();
            int TotalRate = reviews.Sum(x => x.Rate).GetValueOrDefault();
            ViewBag.AvgRate = TotalRate > 0 ? TotalRate / count : 0;

            this.GetDefaultData();
            return View(prod);
        }

        //ADD RECENT VIEWS PRODUCT IN DB
        public void AddRecentViewProduct(int pid)
        {
            if (TempShpData.UserID > 0)
            {
                RecentlyView Rv = new RecentlyView();
                Rv.Customer_ID = TempShpData.UserID;
                Rv.Product_ID = pid;
                Rv.ViewDate = DateTime.Now;
                db.RecentlyViews.Add(Rv);
                db.SaveChanges();
            }
        }

        //SEARCH BAR
        public ActionResult Search(string product, int? page)
        {
            ViewBag.Categories = db.Categories.Select(x => x.Category_Name).ToList();
            ViewBag.TopRatedProducts = TopSoldProducts();

            ViewBag.RecentViewsProducts = RecentViewProducts();

            List<Product> products;
            if (!string.IsNullOrEmpty(product))
            {
                products = db.Products.Where(x => x.Product_Name.StartsWith(product)).ToList();
            }
            else
            {
                products = db.Products.ToList();
            }
            return View("Products", products.ToPagedList(page ?? 1, 6));
        }

        public JsonResult GetProducts(string term)
        {
            List<string> prodNames = db.Products.Where(x => x.Product_Name.StartsWith(term)).Select(y => y.Product_Name).ToList();
            return Json(prodNames, JsonRequestBehavior.AllowGet);

        }
        public ActionResult FilterByPrice(int minPrice, int maxPrice, int? page)
        {
            ViewBag.Categories = db.Categories.Select(x => x.Category_Name).ToList();
            ViewBag.TopRatedProducts = TopSoldProducts();

            ViewBag.RecentViewsProducts = RecentViewProducts();
            ViewBag.filterByPrice = true;
            var filterProducts = db.Products.Where(x => x.Product_Price >= minPrice && x.Product_Price <= maxPrice).ToList();
            return View("Products", filterProducts.ToPagedList(page ?? 1, 9));
        }

        //public ActionResult Products(int subCatID)
        //{
        //    ViewBag.Categories = db.Categories.Select(x => x.Category_Name).ToList();
        //    var prods = db.Products.Where(y => y.SubCategoryID == subCatID).ToList();
        //    return View(prods);
        //}

        
    }
}