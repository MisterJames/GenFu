using System;

namespace GenFu.Tests.TestEntities
{
    public class AuditEntry
    {
        public Guid AuditId { get; set; }
        public DateTime AuditDate { get; set; }
        public string UserName { get; set; }
    }
}
