﻿using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using MvcProje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Areas.Admin.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        // GET: Admin/Admin
        AboutManager _aboutManager = new AboutManager();
        AuthorManager _authorManager = new AuthorManager();
        CategoryManager _categoryManager = new CategoryManager();
        CommentManager _commentManager = new CommentManager();
        ContactManager _contactManager = new ContactManager();
        NewsManager _newsManager = new NewsManager();

        public ActionResult AdminNewsList()
        {
            var newslist = _newsManager.GetAll();
            return View(newslist);
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

        public ActionResult AuthorList()
        {
            var authorList = _authorManager.GetAll();
            return View(authorList);
        }

        [HttpGet]
        public ActionResult AddAuthor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAuthor(Author author)
        {
            _authorManager.AddAuthorBusinessLayer(author);
            return RedirectToAction("AuthorList");
        }

        [HttpGet]
        public ActionResult AuthorEdit(int id)
        {
            Author author = _authorManager.FindAuthor(id);
            return View(author);
        }
        [HttpPost]
        public ActionResult AuthorEdit(Author author)
        {
            _authorManager.EditAuthor(author);
            return RedirectToAction("AuthorList");
        }

        public ActionResult AdminCategoryList()
        {
            var categoryList = _categoryManager.GetAll();
            return View(categoryList);
        }

        public ActionResult Chart()
        {
            return View();
        }

        public ActionResult VisualizeResult()
        {
            return Json(CategoryList(), JsonRequestBehavior.AllowGet);
        }

        public List<Test1> CategoryList()
        {
            List<Test1> a = new List<Test1>();
            a.Add(new Test1()
            {
                CategoryName = "Teknoloji",
                NewsCount = 12
            });

            a.Add(new Test1()
            {
                CategoryName = "Spor",
                NewsCount = 8
            });

            a.Add(new Test1()
            {
                CategoryName = "Magazin",
                NewsCount = 16
            });

            return a;
        }

        public ActionResult VisualizeResult2()
        {
            return Json(NewsList(), JsonRequestBehavior.AllowGet);
        }

        public List<Test2> NewsList()
        {
            List<Test2> test2 = new List<Test2>();
            using (var a = new Context())
            {
                test2 = a.News.Select(x => new Test2
                {
                    NewsName = x.NewsTitle,
                    NewsRating = x.NewsRating
                }).ToList();
            }
            return test2;
        }

        public ActionResult Chart1()
        {
            return View();
        }
        public ActionResult Chart2()
        {
            return View();
        }
        public ActionResult Chart3()
        {
            return View();
        }

        public ActionResult AdminCommentListTrue()
        {
            var commentList = _commentManager.CommentByStatusTrue();
            return View(commentList);
        }

        public ActionResult AdminCommentListFalse()
        {
            var commentList = _commentManager.CommentByStatusFalse();
            return View(commentList);
        }

        public ActionResult ChangeCommentStatusToFalse(int id)
        {
            _commentManager.ChangeCommentStatusToFalse(id);
            return RedirectToAction("AdminCommentListTrue");
        }

        public ActionResult ChangeCommentStatusToTrue(int id)
        {
            _commentManager.ChangeCommentStatusToTrue(id);
            return RedirectToAction("AdminCommentListFalse");
        }

        public ActionResult SendBox()
        {
            var messageList = _contactManager.GetAll();
            return View(messageList);
        }

        public ActionResult MessageDetails(int id)
        {
            Contact contact = _contactManager.GetContactDetails(id);
            return View(contact);
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
            return RedirectToAction("AdminNewsList");
        }

        public ActionResult AdminNewsList2()
        {
            var newslist = _newsManager.GetAll();
            return View(newslist);
        }

        public ActionResult NewsDetails()
        {
            return RedirectToAction("NewsDetails", "News");
        }

        public ActionResult DeleteNews(int id)
        {
            _newsManager.DeleteNewsBusinessLayer(id);
            return RedirectToAction("AdminNewsList");
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
            return RedirectToAction("AdminNewsList");
        }

        public ActionResult GetCommentByNews(int id)
        {
            CommentManager commentManager = new CommentManager();
            var commentList = commentManager.CommentByNews(id);
            return View(commentList);
        }

        [HttpPost]
        public ActionResult DeleteComment(int id)
        {
            int newsId = _commentManager.GetNewsIdByCommentId(id);

            _commentManager.DeleteCommentBusinessLayer(id);
            return RedirectToAction("GetCommentByNews", "Admin", new { id = newsId });
        }
    }
}