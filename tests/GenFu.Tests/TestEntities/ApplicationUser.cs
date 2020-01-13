using System;
using System.Collections.Generic;
using System.Text;

namespace GenFu.Tests.TestEntities
{
    public class ApplicationUserBase 
    {
        public Guid Id { get; set; }

        public int AccessFailedCount { get; set; }
    }

    public class ApplicationUser : ApplicationUserBase
    {
        public string UserName { get; set; }

        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public DateTime CreatedAt { get; set; }
        public Gender Gender { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
    }
}
