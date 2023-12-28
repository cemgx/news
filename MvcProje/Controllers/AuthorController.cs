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
        NewsManager nm = new NewsManager();
        public PartialViewResult AuthorAbout(int id)
        {
            var authorDetails = nm.GetNewsByID(id);
            return PartialView(authorDetails);
        }
        public PartialViewResult AuthorPopularNews(int id)
        {
            var newsAuthorID = nm.GetAll().Where(x => x.NewsID == id).Select(y => y.AuthorID).FirstOrDefault();
            var authorNews = nm.GetNewsByAuthor(newsAuthorID);
            return PartialView(authorNews);
        }
    }
}