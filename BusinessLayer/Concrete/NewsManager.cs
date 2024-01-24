using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class NewsManager
    {
        Repository<News> reponews = new Repository<News>();

        public List<News> GetAll()
        {
            return reponews.List();
        }

        public List<News> GetNewsByID(int id) 
        { 
            return reponews.List(x => x.NewsID == id);
        }

        public List<News> GetNewsByAuthor(int id)
        {
            return reponews.List(x => x.AuthorID == id);
        }

        public List<News> GetNewsByCategory(int id)
        {
            return reponews.List(x => x.CategoryID == id);
        }
    }
}
