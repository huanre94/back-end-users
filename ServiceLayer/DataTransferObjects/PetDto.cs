using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DataTransferObjects
{
    public record PetDto(long Id, string Name, DateTime? BirthDate, long OwnerId, bool Status);

    public record PetCreateDto(string Name, DateTime? BirthDate);

    public record PetUpdateDto(string Name, DateTime? BirthDate, bool status);

}
