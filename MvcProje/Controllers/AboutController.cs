﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
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
        AboutManager _aboutManager = new AboutManager(new EfAboutDal());

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
            AuthorManager _authorManager = new AuthorManager(new EfAuthorDal());
            var authorList = _authorManager.GetList();
            return PartialView(authorList);
        }

        //[HttpGet]
        //public ActionResult UpdateAboutList()
        //{   
        //    var aboutList = _aboutManager.GetAll();
        //    return View(aboutList);
        //}
        //[HttpPost]
        //public ActionResult UpdateAbout(About about)
        //{
        //    _aboutManager.UpdateAboutBusinessLayer(about);
        //    return RedirectToAction("UpdateAboutList");
        //}
    }
}