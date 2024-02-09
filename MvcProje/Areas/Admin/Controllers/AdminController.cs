using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using MvcProje.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProje.Areas.Admin.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        // GET: Admin/Admin
        AboutManager _aboutManager = new AboutManager();
        AuthorManager _authorManager = new AuthorManager(new EfAuthorDal());
        CategoryManager _categoryManager = new CategoryManager(new EfCategoryDal());
        CommentManager _commentManager = new CommentManager(new EfCommentDal());
        ContactManager _contactManager = new ContactManager();
        NewsManager _newsManager = new NewsManager(new EfNewsDal());

        public ActionResult AdminNewsList()
        {
            var newslist = _newsManager.GetList();
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
            var authorList = _authorManager.GetList();
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
            AuthorValidator authorValidator = new AuthorValidator();
            ValidationResult results = authorValidator.Validate(author);
            if (results.IsValid)
            {
                _authorManager.Add(author);
                return RedirectToAction("AuthorList");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult AuthorEdit(int id)
        {
            Author author = _authorManager.GetByID(id);
            return View(author);
        }
        [HttpPost]
        public ActionResult AuthorEdit(Author author)
        {
            AuthorValidator authorValidator = new AuthorValidator();
            ValidationResult results = authorValidator.Validate(author);
            if (results.IsValid)
            {
                _authorManager.Update(author);
                return RedirectToAction("AuthorList");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult AdminCategoryList()
        {
            var categoryList = _categoryManager.GetAll(); // Kategori listesini al

            // Kategori ve ilişkili haber verilerini ViewModel'e doldur
            List<CategoryNewsViewModel> categoryNewsList = new List<CategoryNewsViewModel>();
            foreach (var category in categoryList)
            {
                var newsList = _newsManager.GetNewsByCategory(category.CategoryID); // Kategoriye ait haber listesini al

                CategoryNewsViewModel categoryNewsViewModel = new CategoryNewsViewModel
                {
                    Category = category,
                    NewsList = newsList
                };

                categoryNewsList.Add(categoryNewsViewModel);
            }

            return View(categoryNewsList); // ViewModel listesini View'e gönder
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
            _newsManager.Add(news);
            return RedirectToAction("AdminNewsList");
        }

        public ActionResult AdminNewsList2()
        {
            var newslist = _newsManager.GetList();
            return View(newslist);
        }

        public ActionResult DeleteNews(int id)
        {
            News news = _newsManager.GetByID(id);
            _newsManager.Delete(news);
            return RedirectToAction("AdminNewsList2");
        }

        [HttpGet]
        public ActionResult UpdateNews(int id)
        {
            News news = _newsManager.GetByID(id);
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
            _newsManager.Update(news);
            return RedirectToAction("AdminNewsList2");
        }

        public ActionResult GetCommentByNews(int id)
        {
            var commentList = _commentManager.CommentByNews(id);
            return View(commentList);
        }

        [HttpPost]
        public ActionResult DeleteComment(int id)
        {
            int newsId = _commentManager.GetNewsIdByCommentId(id);

            _commentManager.DeleteCommentBusinessLayer(id);
            return RedirectToAction("GetCommentByNews", "Admin", new { id = newsId });
        }

        public ActionResult AuthorNewsList(int id)
        {
            var news = _newsManager.GetNewsByAuthor(id);

            return View(news);
        }

        [HttpGet]
        public ActionResult AdminCategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminCategoryAdd(Category category)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(category);
            if (results.IsValid)
            {
                _categoryManager.Add(category);
                return RedirectToAction("AdminCategoryList");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult CategoryEdit(int id)
        {
            Category category = _categoryManager.GetByID(id);
            return View(category);
        }
        [HttpPost]
        public ActionResult CategoryEdit(Category category)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(category);
            if (results.IsValid)
            {
                _categoryManager.Update(category);
                return RedirectToAction("AdminCategoryList");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult CategoryDelete(int id)
        {
            _categoryManager.CategoryStatusFalseBusinessLayer(id);
            return RedirectToAction("AdminCategoryList");
        }

        public ActionResult CategoryStatusTrue(int id)
        {
            _categoryManager.CategoryStatusTrueBusinessLayer(id);
            return RedirectToAction("AdminCategoryList");
        }

        //public PartialViewResult LastNewsWriter()
        //{
        //    var allNews = _newsManager.GetList();
        //    for (var a = 1; a <= allNews.FirstOrDefault().Author.AuthorName.Count(); a++)
        //    {
        //        var lastAuthorImage1 = allNews.OrderByDescending(z => z.NewsID).Where(x => x.CategoryID == a).Select(y => y.Author.AuthorImage).FirstOrDefault();
        //        var lastAuthorNewsName = _newsManager.GetList().OrderByDescending(z => z.NewsID).Where(x => x.CategoryID == a).Select(y => y.NewsTitle).FirstOrDefault();

        //        ViewBag.lastAuthorImage1 = lastAuthorImage1;
        //        ViewBag.lastAuthorNewsName = lastAuthorNewsName;
        //    }
        //    return PartialView();
        //}

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("AdminLogin", "Login");
        }
    }
}