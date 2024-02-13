using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
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
        NewsManager _newsManager = new NewsManager(new EfNewsDal());

        public PartialViewResult AuthorAbout(int id)
        {
            var authorDetails = _newsManager.GetNewsByID(id);
            return PartialView(authorDetails);
        }

        public PartialViewResult AuthorPopularNews(int id)
        {
            var newsAuthorID = _newsManager.GetList().Where(x => x.NewsID == id).Select(y => y.AuthorID).FirstOrDefault();
            var authorNews = _newsManager.GetNewsByAuthor(newsAuthorID);
            return PartialView(authorNews);
        }
    }
}