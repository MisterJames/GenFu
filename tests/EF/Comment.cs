using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angela.Tests.EF
{
    public class Comment
    {
        public int Id { get; set; }
        public virtual User User { get; set; }
        public DateTime PostedOn { get; set; }
        public string CommentValue { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
