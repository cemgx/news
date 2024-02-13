using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class MailSubscribeController : Controller
    {
        private readonly SubscribeMailManager _mailManager = new SubscribeMailManager(new EfMailDal());

        [HttpGet]
        public PartialViewResult AddMail()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<PartialViewResult> AddMail(SubscribeMail p, string token)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return PartialView(p);
                }

                var secretKey = ConfigurationManager.AppSettings["recaptcha:6Lf7AnApAAAAAMzjwc_zaCdVLCXq74FL3AqbT0zQ"];
                var apiUrl = "https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}";
                var client = new HttpClient();
                client.Timeout = TimeSpan.FromSeconds(90000);
                var response = await client.GetAsync(string.Format(apiUrl, secretKey, token));
                var jsonString = await response.Content.ReadAsStringAsync();
                var captchaResponse = JsonConvert.DeserializeObject<CaptchaResponse>(jsonString);

                if (!captchaResponse.Success)
                {
                    ModelState.AddModelError("", "reCAPTCHA doğrulaması başarısız oldu.");
                    return PartialView(p);
                }

                _mailManager.Add(p);
                return PartialView("Success");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Beklenmeyen bir hata oluştu.");
                return PartialView(ex);
            }
        }

        public class CaptchaResponse
        {
            public bool Success { get; set; }
            public string ChallengeTs { get; set; }
            public string Hostname { get; set; }
            public List<string> ErrorCodes { get; set; }
        }
    }
}
