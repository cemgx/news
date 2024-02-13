using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public List<Comment> CommentList()
        {
            return _commentDal.List();
        }

        public List<Comment> CommentByNews(int id)
        {
            return _commentDal.List(x => x.NewsID == id);
        }

        public List<Comment> CommentByStatusTrue() 
        {
            return _commentDal.List(x => x.CommentStatus == true);
        }

        public List<Comment> CommentByStatusFalse()
        {
            return _commentDal.List(x => x.CommentStatus == false);
        }

        public void ChangeCommentStatusToFalse(int id)
        {
            Comment _comment = _commentDal.Find(x => x.CommentID == id);
            _comment.CommentStatus = false;
            _commentDal.Update(_comment);
        }

        public void ChangeCommentStatusToTrue(int id)
        {
            Comment _comment = _commentDal.Find(x => x.CommentID == id);
            _comment.CommentStatus = true;
            _commentDal.Update(_comment);
        }

        public int GetNewsIdByCommentId(int commentId)
        {
            var comment = _commentDal.Find(c => c.CommentID == commentId);
            if (comment != null)
            {
                return comment.NewsID;
            }
            else
            {
                return 0;
            }
        }

        public void DeleteCommentBusinessLayer(int p)
        {
            Comment comment = _commentDal.Find(x => x.CommentID == p);
            _commentDal.Delete(comment);
        }

        public List<Comment> GetList()
        {
            throw new System.NotImplementedException();
        }

        public void Add(Comment p)
        {
            _commentDal.Insert(p);
        }

        public void Delete(Comment p)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Comment p)
        {
            throw new System.NotImplementedException();
        }

        public Comment GetByID(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
