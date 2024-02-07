﻿using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContactManager
    {
        Repository<Contact> repoContact = new Repository<Contact>();

        public void BLContactAdd(Contact c)
        {
            //if(c.Mail == "" || c.Message == "" || c.Name == "" || c.Subject == "" || c.Surname == "" || c.Mail.Length <= 8 || c.Subject.Length <= 2) 
            //{
            //    return -1;
            //}
            repoContact.Insert(c);
        }

        public List<Contact> GetAll()
        {
            return repoContact.List();
        }

        public Contact GetContactDetails(int id)
        {
            return repoContact.Find(x => x.ContactID == id);
        }
    }
}
