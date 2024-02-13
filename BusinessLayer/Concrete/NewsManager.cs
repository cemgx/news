using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class NewsManager : INewsService
    {
        INewsDal _newsDal;

        public NewsManager(INewsDal newsDal)
        {
            _newsDal = newsDal;
        }

        public List<News> GetNewsByID(int id) 
        { 
            return _newsDal.List(x => x.NewsID == id);
        }

        public List<News> GetNewsByAuthor(int id)
        {
            return _newsDal.List(x => x.AuthorID == id);
        }

        public List<News> GetNewsByCategory(int id)
        {
            return _newsDal.List(x => x.CategoryID == id);
        }

        public List<News> GetList()
        {
            return _newsDal.List();
        }

        public void Add(News p)
        {
            _newsDal.Insert(p);
        }

        public void Delete(News p)
        {
            _newsDal.Delete(p);
        }

        public void Update(News p)
        {
            _newsDal.Update(p);
        }

        public News GetByID(int id)
        {
            return _newsDal.GetById(id);
        }
    }
}