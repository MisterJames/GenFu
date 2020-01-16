using System;

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
    }
}
