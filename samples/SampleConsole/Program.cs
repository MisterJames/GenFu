using Angela.Core;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace SampleConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = Angie
                .Configure()
                .ListCount(8)
                .MakeList<Person>();

            foreach (var person in people)
            {
                Console.WriteLine(person);
            }

            var blogposts = Angie
                .Configure()
                .ListCount(3)
                .FillBy("CreateDate", delegate() { return Susan.FillDate(DateRules.PastDate); })
                .FillBy("Comments", delegate()
            {
                return Angie
                    .Set()
                    .ListCount(5)
                    .FillBy("CommentDate", delegate() { return Susan.FillDate(DateRules.PastDate); })
                    .MakeList<BlogComment>();
            })
                .MakeList<BlogPost>();
            
            foreach (var post in blogposts)
            {
                Console.WriteLine(post.Title);
            }

            Console.ReadLine();
        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public override string ToString()
        {
            return string.Format("You can reach {0} {1} at \n\te:{2}\n\tp:{3}\n", FirstName, LastName, Email, PhoneNumber);
        }
        
    }

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
}
