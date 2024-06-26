﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface INewsService : IRepositoryService<News>
    {
        List<News> GetNewsByID(int id);

        List<News> GetNewsByAuthor(int id);
    }
}
