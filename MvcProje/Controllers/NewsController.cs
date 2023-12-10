using BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class NewsController : Controller
    {
        // GET: Blog
        NewsManager nm = new NewsManager();

        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult NewsList()
        {
            var newslist = nm.GetAll();
            return PartialView(newslist);
        }
        public PartialViewResult FeaturedNews()
        {
            return PartialView();
        }
        public PartialViewResult OtherFeaturedNews()
        {
            return PartialView();
        }
        public PartialViewResult MailSubs()
        {
            return PartialView();
        }
        public ActionResult NewsDetails()
        {
            return View();
        }
        public PartialViewResult NewsCover()
        {
            return PartialView();
        }
        public PartialViewResult NewsAllContent()
        {
            return PartialView();
        }
        public ActionResult NewsByCategory()
        {
            return View();
        }
    }
}