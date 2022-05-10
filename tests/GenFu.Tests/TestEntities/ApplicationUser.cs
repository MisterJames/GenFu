namespace GenFu.Tests.TestEntities;

using System;

public class ApplicationUserBase
{
    public Guid Id { get; set; }

    public int AccessFailedCount { get; set; }

    public DateTime CreatedOn { get; set; }
}

public class ApplicationUser : ApplicationUserBase
{
    public string UserName { get; set; }
}
