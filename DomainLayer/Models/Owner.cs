using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Owner : AuditableEntity
    {
        [Column("OwnerId")]
        public long Id { get; set; }

        public string Name { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        [Column("Status")]
        public bool IsActive { get; set; }

        public ICollection<Pet>? Pets { get; set; }

        //public Owner()
        //        {
        //            Pets = new List<Pet>();
        //        }
    }
}
