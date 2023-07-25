using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Owner : AuditableEntity
    {
        [Required(ErrorMessage = "Campo Nombre es requerido.")]
        [MaxLength(200)]
        public string Name { get; set; }
        [Phone]
        public string Telephone { get; set; }
        [EmailAddress]
        public string Email { get; set; }

        public ICollection<Pet>? Pets { get; set; }

        public Owner()
        {
            IsActive = true;
            CreatedAt = DateTime.Now;
        }
    }
}
