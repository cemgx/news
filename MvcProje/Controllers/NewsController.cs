using BusinessLayer.Concrete;
using PagedList;
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
        public PartialViewResult NewsList(int page = 1)
        {
            var newslist = nm.GetAll().ToPagedList(page, 3);
            return PartialView(newslist);
        }
        public PartialViewResult FeaturedNews()
        {
            //1. Haber
            var newstitle1 = nm.GetAll().OrderByDescending(z => z.NewsID).Where(x => x.CategoryID == 1).Select(y => y.NewsTitle).FirstOrDefault();
            var newsimage1 = nm.GetAll().OrderByDescending(z => z.NewsID).Where(x => x.CategoryID == 1).Select(y => y.NewsImage).FirstOrDefault();
            var newsdate1 = nm.GetAll().OrderByDescending(z => z.NewsID).Where(x => x.CategoryID == 1).Select(y => y.NewsDate).FirstOrDefault();

            ViewBag.newstitle1 = newstitle1;
            ViewBag.newsimage1 = newsimage1;
            ViewBag.newsdate1 = newsdate1;

            //2. Haber
            var newstitle2 = nm.GetAll().OrderByDescending(z => z.NewsID).Where(x => x.CategoryID == 7).Select(y => y.NewsTitle).FirstOrDefault();
            var newsimage2 = nm.GetAll().OrderByDescending(z => z.NewsID).Where(x => x.CategoryID == 7).Select(y => y.NewsImage).FirstOrDefault();
            var newsdate2 = nm.GetAll().OrderByDescending(z => z.NewsID).Where(x => x.CategoryID == 7).Select(y => y.NewsDate).FirstOrDefault();

            ViewBag.newstitle2 = newstitle2;
            ViewBag.newsimage2 = newsimage2;
            ViewBag.newsdate2 = newsdate2;

            //3. Haber
            var newstitle3 = nm.GetAll().OrderByDescending(z => z.NewsID).Where(x => x.CategoryID == 4).Select(y => y.NewsTitle).FirstOrDefault();
            var newsimage3 = nm.GetAll().OrderByDescending(z => z.NewsID).Where(x => x.CategoryID == 4).Select(y => y.NewsImage).FirstOrDefault();
            var newsdate3 = nm.GetAll().OrderByDescending(z => z.NewsID).Where(x => x.CategoryID == 4).Select(y => y.NewsDate).FirstOrDefault();

            ViewBag.newstitle3 = newstitle3;
            ViewBag.newsimage3 = newsimage3;
            ViewBag.newsdate3 = newsdate3;

            //4. Haber
            var newstitle4 = nm.GetAll().OrderByDescending(z => z.NewsID).Where(x => x.CategoryID == 6).Select(y => y.NewsTitle).FirstOrDefault();
            var newsimage4 = nm.GetAll().OrderByDescending(z => z.NewsID).Where(x => x.CategoryID == 6).Select(y => y.NewsImage).FirstOrDefault();
            var newsdate4 = nm.GetAll().OrderByDescending(z => z.NewsID).Where(x => x.CategoryID == 6).Select(y => y.NewsDate).FirstOrDefault();

            ViewBag.newstitle4 = newstitle4;
            ViewBag.newsimage4 = newsimage4;
            ViewBag.newsdate4 = newsdate4;

            //5. Haber
            var newstitle5 = nm.GetAll().OrderByDescending(z => z.NewsID).Where(x => x.CategoryID == 5).Select(y => y.NewsTitle).FirstOrDefault();
            var newsimage5 = nm.GetAll().OrderByDescending(z => z.NewsID).Where(x => x.CategoryID == 5).Select(y => y.NewsImage).FirstOrDefault();
            var newsdate5 = nm.GetAll().OrderByDescending(z => z.NewsID).Where(x => x.CategoryID == 5).Select(y => y.NewsDate).FirstOrDefault();

            ViewBag.newstitle5 = newstitle5;
            ViewBag.newsimage5 = newsimage5;
            ViewBag.newsdate5 = newsdate5;

            return PartialView();
        }
        public PartialViewResult OtherFeaturedNews()
        {
            return PartialView();
        }
        public ActionResult NewsDetails()
        {
            return View();
        }
        public PartialViewResult NewsCover(int id)
        {
            var NewsDetailsList = nm.GetNewsByID(id);
            return PartialView(NewsDetailsList);
        }
        public PartialViewResult NewsAllContent(int id)
        {
            var NewsDetailsList = nm.GetNewsByID(id);
            return PartialView(NewsDetailsList);
        }
        public ActionResult NewsByCategory()
        {
            return View();
        }
    }
}