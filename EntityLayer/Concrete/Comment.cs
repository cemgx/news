using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string Mail { get; set; }

        [StringLength(1000)]
        public string CommentText { get; set; }

        public DateTime CommentDate { get; set; }

        public int NewsID { get; set; }
        public virtual News News { get; set; } 
    }
}
