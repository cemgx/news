using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProje.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        // GET: User
        UserProfileManager _userProfileManager = new UserProfileManager();
        NewsManager _newsManager = new NewsManager();

        public ActionResult Index()
        {
            
            return View();
        }

        public PartialViewResult Partial1(string mail)
        {
            mail = (string)Session["AuthorMail"];
            var profileValues = _userProfileManager.GetAuthorByMail(mail);
            return PartialView(profileValues);
        }

        public ActionResult UpdateUserProfile(Author author)
        {
            _userProfileManager.EditAuthor(author);
            return RedirectToAction("Index");
        }
            public ActionResult NewsList(string p)
        { 
            p = (string)Session["AuthorMail"];
            Context context = new Context();
            int id = context.Authors.Where(x => x.AuthorMail == p).Select(y => y.AuthorID).FirstOrDefault();

            var news = _userProfileManager.GetNewsByAuthor(id);
            return View(news);
        }

        [HttpGet]
        public ActionResult UpdateNews(int id)
        {
            News news = _newsManager.FindNews(id);
            Context _context = new Context();
            List<SelectListItem> values = (from x in _context.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.values = values;

            List<SelectListItem> values2 = (from x in _context.Authors.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.AuthorName,
                                                Value = x.AuthorID.ToString()
                                            }).ToList();
            ViewBag.values2 = values2;
            return View(news);
        }
        [HttpPost]
        public ActionResult UpdateNews(News news)
        {
            _newsManager.UpdateNews(news);
            return RedirectToAction("NewsList");
        }

        [HttpGet]
        public ActionResult AddNewNews()
        {
            Context _context = new Context();
            List<SelectListItem> values = (from x in _context.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.values = values;

            List<SelectListItem> values2 = (from x in _context.Authors.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.AuthorName,
                                                Value = x.AuthorID.ToString()
                                            }).ToList();
            ViewBag.values2 = values2;
            return View();
        }
        [HttpPost]
        public ActionResult AddNewNews(News news)
        {
            _newsManager.NewsAddBusinessLayer(news);
            return RedirectToAction("NewsList");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("AuthorLogin", "Login");
        }
    }
}