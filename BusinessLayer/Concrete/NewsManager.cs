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

        public void NewsAddBusinessLayer(News news)
        {
            //if(news.NewsTitle == "" || news.NewsImage == "" || news.NewsTitle.Length <= 5 || news.NewsContent.Length <= 200)
            //{
            //    return -1;
            //}
            reponews.Insert(news);
        }

        public void DeleteNewsBusinessLayer(int p)
        {
            News news = reponews.Find(x => x.NewsID == p);
            reponews.Delete(news);
        }

        public News FindNews(int id)
        {
            return reponews.Find(x => x.NewsID == id);
        }

        public void UpdateNews(News news)
        {
            News n = reponews.Find(x => x.NewsID == news.NewsID);
            n.NewsTitle = news.NewsTitle;
            n.NewsContent = news.NewsContent;
            n.NewsDate = news.NewsDate;
            n.NewsImage = news.NewsImage;
            n.CategoryID = news.CategoryID;
            n.AuthorID = news.AuthorID;
            reponews.Update(n);
        }
    }
}
