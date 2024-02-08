using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
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
        NewsManager _newsManager = new NewsManager();

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult NewsList(int page = 1)
        {
            var newslist = _newsManager.GetAll().ToPagedList(page, 3);
            return PartialView(newslist);
        }

        public PartialViewResult FeaturedNews()
        {
            //1. Haber
            var newstitle1 = _newsManager.GetAll().OrderByDescending(z => z.NewsID).Where(x => x.CategoryID == 1).Select(y => y.NewsTitle).FirstOrDefault();
            var newsimage1 = _newsManager.GetAll().OrderByDescending(z => z.NewsID).Where(x => x.CategoryID == 1).Select(y => y.NewsImage).FirstOrDefault();
            var newsdate1 = _newsManager.GetAll().OrderByDescending(z => z.NewsID).Where(x => x.CategoryID == 1).Select(y => y.NewsDate).FirstOrDefault();
            var newspostid1 = _newsManager.GetAll().OrderByDescending(z => z.NewsID).Where(x => x.CategoryID == 1).Select(y => y.NewsID).FirstOrDefault();

            ViewBag.newstitle1 = newstitle1;
            ViewBag.newsimage1 = newsimage1;
            ViewBag.newsdate1 = newsdate1;
            ViewBag.newspostid1 = newspostid1;

            //2. Haber
            var newstitle2 = _newsManager.GetAll().OrderByDescending(z => z.NewsID).Where(x => x.CategoryID == 7).Select(y => y.NewsTitle).FirstOrDefault();
            var newsimage2 = _newsManager.GetAll().OrderByDescending(z => z.NewsID).Where(x => x.CategoryID == 7).Select(y => y.NewsImage).FirstOrDefault();
            var newsdate2 = _newsManager.GetAll().OrderByDescending(z => z.NewsID).Where(x => x.CategoryID == 7).Select(y => y.NewsDate).FirstOrDefault();
            var newspostid2 = _newsManager.GetAll().OrderByDescending(z => z.NewsID).Where(x => x.CategoryID == 7).Select(y => y.NewsID).FirstOrDefault();


            ViewBag.newstitle2 = newstitle2;
            ViewBag.newsimage2 = newsimage2;
            ViewBag.newsdate2 = newsdate2;
            ViewBag.newspostid2 = newspostid2;

            //3. Haber
            var newstitle3 = _newsManager.GetAll().OrderByDescending(z => z.NewsID).Where(x => x.CategoryID == 4).Select(y => y.NewsTitle).FirstOrDefault();
            var newsimage3 = _newsManager.GetAll().OrderByDescending(z => z.NewsID).Where(x => x.CategoryID == 4).Select(y => y.NewsImage).FirstOrDefault();
            var newsdate3 = _newsManager.GetAll().OrderByDescending(z => z.NewsID).Where(x => x.CategoryID == 4).Select(y => y.NewsDate).FirstOrDefault();
            var newspostid3 = _newsManager.GetAll().OrderByDescending(z => z.NewsID).Where(x => x.CategoryID == 4).Select(y => y.NewsID).FirstOrDefault();


            ViewBag.newstitle3 = newstitle3;
            ViewBag.newsimage3 = newsimage3;
            ViewBag.newsdate3 = newsdate3;
            ViewBag.newspostid3 = newspostid3;



            //4. Haber
            var newstitle4 = _newsManager.GetAll().OrderByDescending(z => z.NewsID).Where(x => x.CategoryID == 6).Select(y => y.NewsTitle).FirstOrDefault();
            var newsimage4 = _newsManager.GetAll().OrderByDescending(z => z.NewsID).Where(x => x.CategoryID == 6).Select(y => y.NewsImage).FirstOrDefault();
            var newsdate4 = _newsManager.GetAll().OrderByDescending(z => z.NewsID).Where(x => x.CategoryID == 6).Select(y => y.NewsDate).FirstOrDefault();
            var newspostid4 = _newsManager.GetAll().OrderByDescending(z => z.NewsID).Where(x => x.CategoryID == 6).Select(y => y.NewsID).FirstOrDefault();

            ViewBag.newstitle4 = newstitle4;
            ViewBag.newsimage4 = newsimage4;
            ViewBag.newsdate4 = newsdate4;
            ViewBag.newspostid4 = newspostid4;


            //5. Haber
            var newstitle5 = _newsManager.GetAll().OrderByDescending(z => z.NewsID).Where(x => x.CategoryID == 5).Select(y => y.NewsTitle).FirstOrDefault();
            var newsimage5 = _newsManager.GetAll().OrderByDescending(z => z.NewsID).Where(x => x.CategoryID == 5).Select(y => y.NewsImage).FirstOrDefault();
            var newsdate5 = _newsManager.GetAll().OrderByDescending(z => z.NewsID).Where(x => x.CategoryID == 5).Select(y => y.NewsDate).FirstOrDefault();
            var newspostid5 = _newsManager.GetAll().OrderByDescending(z => z.NewsID).Where(x => x.CategoryID == 5).Select(y => y.NewsID).FirstOrDefault();

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

        //public ActionResult AdminNewsList()
        //{
        //    var newslist = _newsManager.GetAll();
        //    return View(newslist);
        //}

        //public ActionResult AdminNewsList2()
        //{
        //    var newslist = _newsManager.GetAll();
        //    return View(newslist);
        //}

        //[HttpGet]
        //public ActionResult AddNewNews()
        //{
        //    Context _context = new Context();
        //    List<SelectListItem> values = (from x in _context.Categories.ToList()
        //                                   select new SelectListItem
        //                                   {
        //                                       Text = x.CategoryName,
        //                                       Value = x.CategoryID.ToString()
        //                                   }).ToList();
        //    ViewBag.values = values;

        //    List<SelectListItem> values2 = (from x in _context.Authors.ToList()
        //                                    select new SelectListItem
        //                                    {
        //                                        Text = x.AuthorName,
        //                                        Value = x.AuthorID.ToString()
        //                                    }).ToList();
        //    ViewBag.values2 = values2;
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult AddNewNews(News news)
        //{
        //    _newsManager.NewsAddBusinessLayer(news);
        //    return RedirectToAction("AdminNewsList");
        //}

        //public ActionResult DeleteNews(int id)
        //{
        //    _newsManager.DeleteNewsBusinessLayer(id);
        //    return RedirectToAction("AdminNewsList");
        //}

        //[HttpGet]
        //public ActionResult UpdateNews(int id)
        //{
        //    News news = _newsManager.FindNews(id);
        //    Context _context = new Context();
        //    List<SelectListItem> values = (from x in _context.Categories.ToList()
        //                                   select new SelectListItem
        //                                   {
        //                                       Text = x.CategoryName,
        //                                       Value = x.CategoryID.ToString()
        //                                   }).ToList();
        //    ViewBag.values = values;

        //    List<SelectListItem> values2 = (from x in _context.Authors.ToList()
        //                                    select new SelectListItem
        //                                    {
        //                                        Text = x.AuthorName,
        //                                        Value = x.AuthorID.ToString()
        //                                    }).ToList();
        //    ViewBag.values2 = values2;
        //    return View(news);
        //}
        //[HttpPost]
        //public ActionResult UpdateNews(News news)
        //{
        //    _newsManager.UpdateNews(news);
        //    return RedirectToAction("AdminNewsList");
        //}

        //public ActionResult GetCommentByNews(int id)
        //{
        //    CommentManager commentManager = new CommentManager();
        //    var commentList = commentManager.CommentByNews(id);
        //    return View(commentList);
        //}
    }
}