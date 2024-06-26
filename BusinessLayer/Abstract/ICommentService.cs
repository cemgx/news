﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICommentService : IRepositoryService<Comment>
    {
        List<Comment> CommentByNews(int id);
        List<Comment> CommentByStatusTrue();
        List<Comment> CommentByStatusFalse();
    }
}
