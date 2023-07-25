using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Models
{
    public abstract class AuditableEntity
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        [Column("Status")]
        public bool IsActive { get; set; }
    }
}