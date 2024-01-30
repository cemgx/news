using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        AboutManager _aboutManager = new AboutManager();

        public ActionResult Index()
        {
            var aboutContent = _aboutManager.GetAll();
            return View(aboutContent);
        }
        public PartialViewResult Footer()
        {
            var aboutcontentlist = _aboutManager.GetAll();
            return PartialView(aboutcontentlist);
        }
        public PartialViewResult MeetTeam()
        {
            AuthorManager _authorManager = new AuthorManager();
            var authorList = _authorManager.GetAll();
            return PartialView(authorList);
        }

        [HttpGet]
        public ActionResult UpdateAboutList()
        {   
            var aboutList = _aboutManager.GetAll();
            return View(aboutList);
        }
        [HttpPost]
        public ActionResult UpdateAbout(About about)
        {
            _aboutManager.UpdateAboutBusinessLayer(about);
            return RedirectToAction("UpdateAboutList");
        }
    }
}