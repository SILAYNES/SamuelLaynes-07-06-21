using System.Collections.Generic;
using DOManagement.Domain.Common;

namespace DOManagement.Domain.Entities
{
    public class Photo : AuditableEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Album Album { get; set; }
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}