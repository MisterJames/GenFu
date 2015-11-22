using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Collections.Generic;

namespace GenFu.Tests
{
    internal class BlogPost
    {
        public int BlogPostId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public virtual ICollection<BlogComment> Comments { get; set; }
        public DateTime CreateDate { get; set; }
    }

    internal class BlogComment
    {
        public int BlogCommentId { get; set; }
        public string Comment { get; set; }
        public string Username { get; set; }
        public DateTime CommentDate { get; set; }
    }

    internal class ColourfulBlogComment : BlogComment
    {
        public string Colour { get; set; }
    }

    internal class DirtyBlogComment : BlogComment
    {
        public int DirtFactor { get; set; }
    }

    internal class BlogCommenter
    {
        public int BlogCommenterId { get; set; }
        public string NullName { get { return null; } }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

}
