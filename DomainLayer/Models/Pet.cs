using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Pet : AuditableEntity
    {
        [Required(ErrorMessage = "Campo Nombre es requerido.")]
        public string Name { get; set; }
        public DateTime? BirthDate { get; set; }

        [ForeignKey(nameof(Owner))]
        public long OwnerId { get; set; }
        public Owner? Owner { get; set; }

        public Pet()
        {
            IsActive = true;
            CreatedAt = DateTime.Now;
        }
    }
}
