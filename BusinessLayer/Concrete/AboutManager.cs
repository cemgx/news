using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AboutManager
    {
        Repository<About> repoAbout = new Repository<About>();

        public List<About> GetAll()
        {
            return repoAbout.List();
        }

        public void UpdateAboutBusinessLayer(About about)
        {
            About _about = repoAbout.Find(x => x.AboutID == about.AboutID);
            _about.AboutContent1 = about.AboutContent1;
            _about.AboutContent2 = about.AboutContent2;
            _about.AboutImage1 = about.AboutImage1;
            _about.AboutImage2 = about.AboutImage2;
            _about.AboutID = about.AboutID;
            repoAbout.Update(_about);
        }
    }
}
