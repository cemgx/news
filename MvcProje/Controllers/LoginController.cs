using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProje.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult AuthorLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AuthorLogin(Author author)
        {
            Context context = new Context();
            var userData = context.Authors.FirstOrDefault(x => x.AuthorMail == author.AuthorMail && x.AuthorPassword == author.AuthorPassword);
            if(userData != null)
            {
                FormsAuthentication.SetAuthCookie(userData.AuthorMail, false);
                Session["AuthorMail"] = userData.AuthorMail.ToString();
                return RedirectToAction("Index", "User");
            }
            else
            {
                ModelState.AddModelError("", "Kullanıcı adı boş olamaz.");
                return View();
            }
        }
    }
}