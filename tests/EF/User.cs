using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angela.Tests.EF
{
    public class User
    {
        public User()
        {
            Groups = new HashSet<Group>();
            Recipes = new HashSet<Recipe>();
            Comments = new HashSet<Comment>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}