using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BakeryInventoryProject.Controllers
{
    public class BrandController : Controller
    {
        // GET: Brand
        public ActionResult Brand()
        {
            ViewBag.AllBrandNames = GetAllBrandNames(); 
            return View("Brand");
        }
        public List<Brand> GetAllBrandNames() {
            var db = new BakeryInventoryEntities();
            var brands = db.Brand;
            var allBrandNames = (from b in brands select b).ToList();
            return allBrandNames; 
        }
        
    }
}