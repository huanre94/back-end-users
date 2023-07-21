using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Pet : AuditableEntity
    {
        [Column("PetId")]
        public long Id { get; set; }

        public string Name { get; set; } 
        public DateTime? BirthDate { get; set; }
        [Column("Status")]
        public bool IsActive { get; set; } 

        [ForeignKey(nameof(Owner))]
        public long OwnerId { get; set; }
        public Owner? Owner { get; set; }
    }
}
