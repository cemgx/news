using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AuthorManager
    {
        Repository<Author> repoAuthor = new Repository<Author>();

        //Get all Authors
        public List<Author> GetAll()
        {
            return repoAuthor.List();
        }

        //Adding new Author
        public int AddAuthorBusinessLayer(Author author)
        {
            //Checking the validity of the values sent from the parameter
            if (author.AuthorName == "" || author.AuthorImage == "" || author.AuthorAbout == "" || author.AuthorTitle == "" || author.AuthorShortAbout == "" || author.AuthorMail == "")
            {
                return -1;
            }
            return repoAuthor.Insert(author);
        }

        //Move the author to the edit page according to the id value
        public Author FindAuthor(int id)
        {
            return repoAuthor.Find(x => x.AuthorID == id);
        }

        public int EditAuthor(Author author)
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
            return repoAuthor.Update(_author);
        }
    }
}
