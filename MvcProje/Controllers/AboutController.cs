using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        AboutManager _aboutManager = new AboutManager(new EfAboutDal());
        AuthorManager _authorManager = new AuthorManager(new EfAuthorDal());

        public ActionResult Index()
        {
            var aboutContent = _aboutManager.GetList();
            return View(aboutContent);
        }
        public PartialViewResult Footer()
        {
            var aboutcontentlist = _aboutManager.GetList();
            return PartialView(aboutcontentlist);
        }

        public PartialViewResult MeetTeam()
        {
            var authorList = _authorManager.GetList();
            return PartialView(authorList);
        }
    }
}