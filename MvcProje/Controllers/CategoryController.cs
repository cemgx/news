using BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager _categoryManager = new CategoryManager();

        public ActionResult Index()
        {
            var categoryvalues = _categoryManager.GetAll();
            return View(categoryvalues);
        }

        public PartialViewResult NewsDetailsCategoryList() 
        {
            var categoryvalues = _categoryManager.GetAll();
            return PartialView(categoryvalues);
        }

        public ActionResult AdminCategoryList() 
        { 
            var categoryList = _categoryManager.GetAll();
            return View(categoryList);
        }
    }
}