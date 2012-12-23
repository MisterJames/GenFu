using Angela.Core;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SampleConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Angie does whatever you tell her to.");
            sb.AppendLine("==================================================");
            sb.AppendLine("  1) Post me some blogs");
            sb.AppendLine("  2) Write some peeps out");
            sb.AppendLine();
            sb.AppendLine("  x to exit");
            sb.AppendLine();

            var instructions = sb.ToString();

            string input = string.Empty;
            while (input.ToLower() != "x")
            {
                Console.WriteLine(instructions);
                input = Console.ReadKey().Key.ToString().ToLower();
                switch (input)
                {
                    case "d1":
                        Console.WriteLine();
                        Console.WriteLine();
                        PostMeSomeBlogs();
                        Console.WriteLine();
                        break;
                    case "d2":
                        Console.WriteLine();
                        Console.WriteLine();
                        WriteSomePeepsOut();
                        Console.WriteLine();
                        break;
                    case "x":
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Aw. So close. Try again.");
                        Console.WriteLine();
                        break;
                }
            }
            


        }

        private static void PostMeSomeBlogs()
        {
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
        }

        private static void WriteSomePeepsOut()
        {
            var people = Angie
                .Configure()
                .ListCount(8)
                .MakeList<Person>();

            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
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
