namespace GenFu.Tests.TestEntities;

using System;

public class AuditEntry
{
    public Guid AuditId { get; set; }
    public DateTime AuditDate { get; set; }
    public string UserName { get; set; }
}
