using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Author
    {
        [Key]
        public int AuthorID { get; set; }

        [StringLength(50)]
        public string AuthorName { get; set; }

        [StringLength(100)]
        public string AuthorImage { get; set; }

        [StringLength(300)]
        public string AuthorAbout { get; set; }

        [StringLength(100)]
        public string AuthorInstagram { get; set; }

        [StringLength(100)]
        public string AuthorX { get; set; }

        public ICollection<News> News { get; set; }
    }
}
