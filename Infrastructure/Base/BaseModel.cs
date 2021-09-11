using System;
using FAQ.Infrastructure.Constants;

namespace FAQ.Infrastructure.Base
{
    public class BaseModel
    {
        public long Id { get; set; }
        public DateTime RecDate { get; set; } = DateTime.Now;
        public DateTime? ChangeAt { get; set; }
        public string? RecAuditLog { get; set; }
        public char RecStatus { get; set; } = Status.Active;
    }
}