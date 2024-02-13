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

        public ContactManager(IContact contactDal)
        {
            _contactDal = contactDal;
        }

        public void Add(Contact p)
        {
            _contactDal.Insert(p);
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
