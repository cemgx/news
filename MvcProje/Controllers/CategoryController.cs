using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
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
        CategoryManager _categoryManager = new CategoryManager(new EfCategoryDal());

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