using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SpletnaDrazba.Models;

namespace SpletnaDrazba.Controllers
{
    public class CategoryController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Category
        public ActionResult AllCategories()
        {
            return View();
        }

        public ActionResult SubCategories(int id)
        {
            List<String> listSubCategory = new List<string>();
            switch (id)
            {
                case 1:
                    
                    listSubCategory.Add("Tv Sprejemniki");
                    listSubCategory.Add("Akustika");
                    ViewData["Categories"] = listSubCategory;
                    break;
                case 2:
                    listSubCategory.Add("Prenosniki");
                    listSubCategory.Add("Tablični računalniki");
                    listSubCategory.Add("Komponente");
                    ViewData["Categories"] = listSubCategory;
                    break;
                case 3:
                    listSubCategory.Add("Stacionarna telefonija");
                    listSubCategory.Add("Mobilna telefonija");
                    ViewData["Categories"] = listSubCategory;
                    break;
            }
            return View();
        }

        public ActionResult CategoryItems(string category)
        {
            List<Drazba> drazbe = db.Drazbas.Where(d => d.Kategorija.Equals(category)).ToList();

            ViewData["Drazbe"] = drazbe;

            return View();
        }
    }
}