using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
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
        public ActionResult SendMessage(Contact contact)
        {
            ContactValidator contactValidator = new ContactValidator();
            ValidationResult results = contactValidator.Validate(contact);
            if (results.IsValid)
            {
                contact.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                _contactManager.Add(contact);
                return RedirectToAction("SendMessage", "Contact");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}