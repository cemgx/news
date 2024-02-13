using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AuthorManager : IAuthorService
    {
        IAuthorDal _authordal;

        public AuthorManager(IAuthorDal authordal)
        {
            _authordal = authordal;
        }

        public List<Author> GetList()
        {
            return _authordal.List();
        }

        public void Add(Author p)
        {
            _authordal.Insert(p);
        }

        public void Delete(Author p)
        {
            throw new NotImplementedException();
        }

        public void Update(Author p)
        {
            _authordal.Update(p);
        }

        public Author GetByID(int id)
        {
            return _authordal.GetById(id);
        }
    }
}
