using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class MailSubscribeController : Controller
    {
        SubscribeMailManager _mailManager = new SubscribeMailManager(new EfMailDal());

        [HttpGet]
        public PartialViewResult AddMail()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult AddMail(SubscribeMail p)
        {

            _mailManager.Add(p);
            return PartialView();
        }
    }
}
