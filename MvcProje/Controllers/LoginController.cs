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
    [AllowAnonymous]
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
                return RedirectToAction("AuthorLogin", "Login");
            }
        }

        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin admin)
        {
            Context context = new Context();
            var adminData = context.Admins.FirstOrDefault(x => x.UserName == admin.UserName && x.Password == admin.Password);
            if (adminData != null)
            {
                FormsAuthentication.SetAuthCookie(adminData.UserName, false);
                Session["UserName"] = adminData.UserName.ToString();
                return RedirectToAction("AdminNewsList", "News");
            }
            else
            {
                return RedirectToAction("AdminLogin", "Login");
            }
        }
    }
}