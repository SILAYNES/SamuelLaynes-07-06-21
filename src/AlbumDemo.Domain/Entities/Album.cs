using System.Collections.Generic;
using DOManagement.Domain.Common;

namespace DOManagement.Domain.Entities
{
    public class Album : AuditableEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<Photo> Photos { get; set; } = new List<Photo>();
    }
}