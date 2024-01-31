using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserProfileManager
    {
        Repository<Author> repoUser = new Repository<Author>();
        Repository<News> repoUserNews = new Repository<News>();

        public List<Author> GetAuthorByMail(string p)
        {
            return repoUser.List(x => x.AuthorMail == p);
        }

        public List<News> GetNewsByAuthor(int id)
        {
            return repoUserNews.List(x => x.AuthorID == id);
        }
    }
}
