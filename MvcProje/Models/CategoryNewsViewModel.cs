using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProje.Models
{
    public class CategoryNewsViewModel
    {
        public Category Category { get; set; }
        public IEnumerable<News> NewsList { get; set; }
    }

}