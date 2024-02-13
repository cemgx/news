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
    public class SubscribeMailManager : IMailService
    {
        IMailDal _mailDal;

        public SubscribeMailManager(IMailDal mailDal)
        {
            _mailDal = mailDal;
        }

        public void Add(SubscribeMail p)
        {
            _mailDal.Insert(p);
        }

        public void Delete(SubscribeMail p)
        {
            throw new NotImplementedException();
        }

        public SubscribeMail GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<SubscribeMail> GetList()
        {
            throw new NotImplementedException();
        }

        public void Update(SubscribeMail p)
        {
            throw new NotImplementedException();
        }
    }
}
