using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager _contactManager = new ContactManager(new EfContactDal());
        
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SendMessage() 
        { 
            return View();
        }

        [HttpPost]
        public ActionResult SendMessage(Contact p)
        {
            _contactManager.BLContactAdd(p);
            return View();
        }

        //public ActionResult SendBox()
        //{
        //    var messageList = _contactManager.GetAll();
        //    return View(messageList);
        //}

        //public ActionResult MessageDetails(int id)
        //{
        //    Contact contact = _contactManager.GetContactDetails(id);
        //    return View(contact);
        //}
    }
}