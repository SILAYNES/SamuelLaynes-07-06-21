using DOManagement.Domain.Common;

namespace DOManagement.Domain.Entities
{
    public class Comment : AuditableEntity
    {
        public long Id { get; set; }
        public string Content { get; set; }
        public Photo Photo { get; set; }
    }
}