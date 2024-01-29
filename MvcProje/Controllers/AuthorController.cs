using BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        NewsManager _newsManager = new NewsManager();
        AuthorManager _authorManager = new AuthorManager();

        public PartialViewResult AuthorAbout(int id)
        {
            var authorDetails = _newsManager.GetNewsByID(id);
            return PartialView(authorDetails);
        }

        public PartialViewResult AuthorPopularNews(int id)
        {
            var newsAuthorID = _newsManager.GetAll().Where(x => x.NewsID == id).Select(y => y.AuthorID).FirstOrDefault();
            var authorNews = _newsManager.GetNewsByAuthor(newsAuthorID);
            return PartialView(authorNews);
        }

        public ActionResult AuthorList()
        {
            var authorList = _authorManager.GetAll();
            return View(authorList);
        }
    }
}