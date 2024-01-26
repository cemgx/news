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
        public int NewsAddBusinessLayer(News businessLayer)
        {
            if(businessLayer.NewsTitle == "" || businessLayer.NewsImage == "" || businessLayer.NewsTitle.Length <= 5 || businessLayer.NewsContent.Length <= 200)
            {
                return -1;
            }
            return reponews.Insert(businessLayer);
        }
        public int DeleteNewsBusinessLayer(int p)
        {
            News news = reponews.Find(x => x.NewsID == p);
            return reponews.Delete(news);
        }
        public News FindNews(int id)
        {
            return reponews.Find(x => x.NewsID == id);
        }
    }
}
