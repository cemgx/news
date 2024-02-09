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
    public class ContactManager : IContactService
    {
        IContact _contactDal;

        Repository<Contact> repoContact = new Repository<Contact>();

        public ContactManager(IContact contactDal)
        {
            _contactDal = contactDal;
        }

        public void BLContactAdd(Contact c)
        {
            //if(c.Mail == "" || c.Message == "" || c.Name == "" || c.Subject == "" || c.Surname == "" || c.Mail.Length <= 8 || c.Subject.Length <= 2) 
            //{
            //    return -1;
            //}
            repoContact.Insert(c);
        }

        public void Add(Contact p)
        {
            throw new NotImplementedException();
        }

        public void Delete(Contact p)
        {
            throw new NotImplementedException();
        }

        public Contact GetByID(int id)
        {
            return _contactDal.Find(x => x.ContactID == id);
        }

        public List<Contact> GetList()
        {
            return _contactDal.List();
        }

        public void Update(Contact p)
        {
            throw new NotImplementedException();
        }
    }
}
