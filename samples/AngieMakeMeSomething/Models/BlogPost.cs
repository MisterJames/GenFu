using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngieMakeMeSomething.Models
{
    public class BlogPost
    {
        public int BlogPostId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public virtual ICollection<BlogComment> Comments { get; set; }
        public DateTime CreateDate { get; set; }
    }

    public class BlogComment
    {
        public int BlogCommentId { get; set; }
        public string Comment { get; set; }
        public string Username { get; set; }
        public DateTime CommentDate { get; set; }
    }

}
