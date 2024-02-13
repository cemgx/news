using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using PagedList;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class NewsController : Controller
    {
        // GET: Blog
        NewsManager _newsManager = new NewsManager(new EfNewsDal());

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult NewsList(int page = 1)
        {
            var newslist = _newsManager.GetList().ToPagedList(page, 6);
            return PartialView(newslist);
        }

        public PartialViewResult FeaturedNews()
        {
            //1. Haber
            var newstitle1 = _newsManager.GetList().OrderByDescending(z => z.NewsID).Where(x => x.CategoryID == 1).Select(y => y.NewsTitle).FirstOrDefault();
            var newsimage1 = _newsManager.GetList().OrderByDescending(z => z.NewsID).Where(x => x.CategoryID == 1).Select(y => y.NewsImage).FirstOrDefault();
            var newsdate1 = _newsManager.GetList().OrderByDescending(z => z.NewsID).Where(x => x.CategoryID == 1).Select(y => y.NewsDate).FirstOrDefault();
            var newspostid1 = _newsManager.GetList().OrderByDescending(z => z.NewsID).Where(x => x.CategoryID == 1).Select(y => y.NewsID).FirstOrDefault();

            ViewBag.newstitle1 = newstitle1;
            ViewBag.newsimage1 = newsimage1;
            ViewBag.newsdate1 = newsdate1;
            ViewBag.newspostid1 = newspostid1;

            //2. Haber
            var newstitle2 = _newsManager.GetList().OrderByDescending(z => z.NewsID).Where(x => x.CategoryID == 7).Select(y => y.NewsTitle).FirstOrDefault();
            var newsimage2 = _newsManager.GetList().OrderByDescending(z => z.NewsID).Where(x => x.CategoryID == 7).Select(y => y.NewsImage).FirstOrDefault();
            var newsdate2 = _newsManager.GetList().OrderByDescending(z => z.NewsID).Where(x => x.CategoryID == 7).Select(y => y.NewsDate).FirstOrDefault();
            var newspostid2 = _newsManager.GetList().OrderByDescending(z => z.NewsID).Where(x => x.CategoryID == 7).Select(y => y.NewsID).FirstOrDefault();


            ViewBag.newstitle2 = newstitle2;
            ViewBag.newsimage2 = newsimage2;
            ViewBag.newsdate2 = newsdate2;
            ViewBag.newspostid2 = newspostid2;

            //3. Haber
            var newstitle3 = _newsManager.GetList().OrderByDescending(z => z.NewsID).Where(x => x.CategoryID == 4).Select(y => y.NewsTitle).FirstOrDefault();
            var newsimage3 = _newsManager.GetList().OrderByDescending(z => z.NewsID).Where(x => x.CategoryID == 4).Select(y => y.NewsImage).FirstOrDefault();
            var newsdate3 = _newsManager.GetList().OrderByDescending(z => z.NewsID).Where(x => x.CategoryID == 4).Select(y => y.NewsDate).FirstOrDefault();
            var newspostid3 = _newsManager.GetList().OrderByDescending(z => z.NewsID).Where(x => x.CategoryID == 4).Select(y => y.NewsID).FirstOrDefault();


            ViewBag.newstitle3 = newstitle3;
            ViewBag.newsimage3 = newsimage3;
            ViewBag.newsdate3 = newsdate3;
            ViewBag.newspostid3 = newspostid3;



            //4. Haber
            var newstitle4 = _newsManager.GetList().OrderByDescending(z => z.NewsID).Where(x => x.CategoryID == 6).Select(y => y.NewsTitle).FirstOrDefault();
            var newsimage4 = _newsManager.GetList().OrderByDescending(z => z.NewsID).Where(x => x.CategoryID == 6).Select(y => y.NewsImage).FirstOrDefault();
            var newsdate4 = _newsManager.GetList().OrderByDescending(z => z.NewsID).Where(x => x.CategoryID == 6).Select(y => y.NewsDate).FirstOrDefault();
            var newspostid4 = _newsManager.GetList().OrderByDescending(z => z.NewsID).Where(x => x.CategoryID == 6).Select(y => y.NewsID).FirstOrDefault();

            ViewBag.newstitle4 = newstitle4;
            ViewBag.newsimage4 = newsimage4;
            ViewBag.newsdate4 = newsdate4;
            ViewBag.newspostid4 = newspostid4;


            //5. Haber
            var newstitle5 = _newsManager.GetList().OrderByDescending(z => z.NewsID).Where(x => x.CategoryID == 5).Select(y => y.NewsTitle).FirstOrDefault();
            var newsimage5 = _newsManager.GetList().OrderByDescending(z => z.NewsID).Where(x => x.CategoryID == 5).Select(y => y.NewsImage).FirstOrDefault();
            var newsdate5 = _newsManager.GetList().OrderByDescending(z => z.NewsID).Where(x => x.CategoryID == 5).Select(y => y.NewsDate).FirstOrDefault();
            var newspostid5 = _newsManager.GetList().OrderByDescending(z => z.NewsID).Where(x => x.CategoryID == 5).Select(y => y.NewsID).FirstOrDefault();

            ViewBag.newstitle5 = newstitle5;
            ViewBag.newsimage5 = newsimage5;
            ViewBag.newsdate5 = newsdate5;
            ViewBag.newspostid5 = newspostid5;

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
            var NewsDetailsList = _newsManager.GetNewsByID(id);
            return PartialView(NewsDetailsList);
        }

        public PartialViewResult NewsAllContent(int id)
        {
            var NewsDetailsList = _newsManager.GetNewsByID(id);
            return PartialView(NewsDetailsList);
        }

        public ActionResult NewsByCategory(int id)
        {
            var NewsListByCategory = _newsManager.GetNewsByCategory(id);
            var CategoryName = _newsManager.GetNewsByCategory(id).Select(x => x.Category.CategoryName).FirstOrDefault();
            ViewBag.CategoryName = CategoryName;

            var CategoryDescription = _newsManager.GetNewsByCategory(id).Select(x => x.Category.CategoryDescription).FirstOrDefault();
            ViewBag.CategoryDescription = CategoryDescription;

            return View(NewsListByCategory);
        }
    }
}