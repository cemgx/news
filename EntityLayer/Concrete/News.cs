using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class News
    {
        [Key]
        public int NewsID { get; set; }

        [StringLength(100)]
        public string NewsTitle { get; set; }

        [StringLength(100)]
        public string NewsImage { get; set;}

        public DateTime NewsDate { get; set;}

        public string NewsContent { get; set; }

        public int NewsRating { get; set; }

        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }

        public int AuthorID { get; set; }
        public virtual Author Author { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
