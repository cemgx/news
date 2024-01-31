using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using System.Linq;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        UserProfileManager _userProfileManager = new UserProfileManager();

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

        public ActionResult NewsList(string p)
        { 
            p = (string)Session["AuthorMail"];
            Context context = new Context();
            int id = context.Authors.Where(x => x.AuthorMail == p).Select(y => y.AuthorID).FirstOrDefault();

            var news = _userProfileManager.GetNewsByAuthor(id);
            return View(news);
        }
    }
}