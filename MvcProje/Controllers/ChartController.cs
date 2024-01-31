using DataAccessLayer.Concrete;
using MvcProje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult VisualizeResult()
        {
            return Json(CategoryList(), JsonRequestBehavior.AllowGet);
        }

        public List<Test1> CategoryList()
        {
            List<Test1> a = new List<Test1>();
            a.Add(new Test1()
            {
                CategoryName = "Teknoloji",
                NewsCount = 12
            });

            a.Add(new Test1()
            {
                CategoryName = "Spor",
                NewsCount = 8
            });

            a.Add(new Test1()
            {
                CategoryName = "Magazin",
                NewsCount = 16
            });

            return a;
        }

        public ActionResult VisualizeResult2()
        {
            return Json(NewsList(), JsonRequestBehavior.AllowGet);
        }

        public List<Test2> NewsList()
        {
            List<Test2> test2 = new List<Test2>();
            using(var a = new Context())
            {
                test2 = a.News.Select(x => new Test2
                {
                    NewsName = x.NewsTitle,
                    NewsRating = x.NewsRating
                }).ToList();
            }
            return test2;
        }

        public ActionResult Chart1()
        {
            return View();
        }
        public ActionResult Chart2()
        {
            return View();
        }
        public ActionResult Chart3()
        {
            return View();
        }
    }
}