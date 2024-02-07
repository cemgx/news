using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class CommentController : Controller
    {
        // GET: Comment
        CommentManager _commentManager = new CommentManager();

        public PartialViewResult CommentList(int id)
        {
            var commentList = _commentManager.CommentByNews(id);
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
            comment.CommentStatus = true;
            _commentManager.CommentAdd(comment);
            
            return PartialView();
        }

        [HttpPost]
        public ActionResult DeleteComment(int id)
        {
            //tryCatch??
            int newsId = _commentManager.GetNewsIdByCommentId(id);

            _commentManager.DeleteCommentBusinessLayer(id);
            return RedirectToAction("GetCommentByNews", "News", new { id = newsId });
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
    }
}