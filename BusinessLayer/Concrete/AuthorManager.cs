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

        Repository<Author> repoAuthor = new Repository<Author>();

        public AuthorManager(IAuthorDal authordal)
        {
            _authordal = authordal;
        }

        //Adding new Author
        public void AddAuthorBusinessLayer(Author author)
        {
            //Checking the validity of the values sent from the parameter
            //if (author.AuthorName == "" || author.AuthorImage == "" || author.AuthorAbout == "" || author.AuthorTitle == "" || author.AuthorShortAbout == "" || author.AuthorMail == "")
            //{
            //    return -1;
            //}
            repoAuthor.Insert(author);
        }

        //Move the author to the edit page according to the id value
        public Author FindAuthor(int id)
        {
            return repoAuthor.Find(x => x.AuthorID == id);
        }

        public void EditAuthor(Author author)
        {
            Author _author = repoAuthor.Find(x => x.AuthorID == author.AuthorID);
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
            repoAuthor.Update(_author);
        }

        public List<Author> GetList()
        {
            return _authordal.List();
        }

        public void Add(Author p)
        {
            throw new NotImplementedException();
        }

        public void Delete(Author p)
        {
            throw new NotImplementedException();
        }

        public void Update(Author p)
        {
            throw new NotImplementedException();
        }

        public Author GetByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
