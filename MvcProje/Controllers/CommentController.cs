using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class CommentController : Controller
    {
        // GET: Comment
        CommentManager _commentmanager = new CommentManager();

        public PartialViewResult CommentList(int id)
        {         
            var commentList = _commentmanager.CommentByNews(id);
            return PartialView(commentList);
        }

        [HttpGet]
        public PartialViewResult LeaveComment(int id)
        {
            ViewBag.id = id;
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult LeaveComment(Comment comment)
        {
            _commentmanager.CommentAdd(comment);
            return PartialView();
        }
    }
}