using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PartialViewExample_WithDynamicCardUpload.Controllers
{
    
    public class HomeController : Controller
    {
        PartialViewDbEntities Db = new PartialViewDbEntities();
        // GET: Home
        public ActionResult Index()
        {
          
            var prod = Db.Products.ToList();
            return View(prod);
        }

        public ActionResult List()
        {
            
            var prod = Db.Products.ToList();
            return View(prod);
        }
        [HttpGet]
        public ActionResult AddProduct()
        {

            return View();
        }
        [HttpPost]  
        public ActionResult AddProduct(HttpPostedFileBase uploadImg, Product prod)
        {
             var fileName = Path.GetFileName(uploadImg.FileName);
             uploadImg.SaveAs(Server.MapPath("~/images/" + fileName));
            prod.ProdImage = fileName;
            Db.Products.Add(prod);
            Db.SaveChanges();
            ModelState.Clear();
            return RedirectToAction("Index");



           
        }
    }
}