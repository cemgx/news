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

        public int EditAuthor(Author author)
        {
            Author _author = repoUser.Find(x => x.AuthorID == author.AuthorID);
            _author.AuthorName = author.AuthorName;
            _author.AuthorImage = author.AuthorImage;
            _author.AuthorAbout = author.AuthorAbout;
            _author.AuthorInstagram = author.AuthorInstagram;
            _author.AuthorX = author.AuthorX;
            _author.AuthorTitle = author.AuthorTitle;
            _author.AuthorShortAbout = author.AuthorShortAbout;
            _author.AuthorMail = author.AuthorMail;
            _author.AuthorPassword = author.AuthorPassword;
            _author.AuthorPhoneNumber = author.AuthorPhoneNumber;
            return repoUser.Update(_author);
        }
    }
}
