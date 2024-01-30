using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class CommentManager
    {
        Repository<Comment> repocomment = new Repository<Comment>();

        public List<Comment> CommentList()
        {
            return repocomment.List();
        }

        public List<Comment> CommentByNews(int id)
        {
            return repocomment.List(x => x.NewsID == id);
        }

        public List<Comment> CommentByStatusTrue() 
        {
            return repocomment.List(x => x.CommentStatus == true);
        }

        public List<Comment> CommentByStatusFalse()
        {
            return repocomment.List(x => x.CommentStatus == false);
        }

        public int CommentAdd(Comment c)
        {
            if (c.CommentText.Length <= 4 || c.CommentText.Length >= 1001 || c.UserName == "" || c.Mail == "" || c.UserName.Length <= 3)
            {
                return -1;
            }
            return repocomment.Insert(c);
        }

        public int ChangeCommentStatusToFalse(int id)
        {
            Comment _comment = repocomment.Find(x => x.CommentID == id);
            _comment.CommentStatus = false;
            return repocomment.Update(_comment);
        }

        public int ChangeCommentStatusToTrue(int id)
        {
            Comment _comment = repocomment.Find(x => x.CommentID == id);
            _comment.CommentStatus = true;
            return repocomment.Update(_comment);
        }

        public int GetNewsIdByCommentId(int commentId)
        {
            var comment = repocomment.Find(c => c.CommentID == commentId);
            if (comment != null)
            {
                return comment.NewsID;
            }
            else
            {
                return 0;
            }
        }

        public int DeleteCommentBusinessLayer(int p)
        {
            Comment comment = repocomment.Find(x => x.CommentID == p);
            return repocomment.Delete(comment);
        }
    }
}
