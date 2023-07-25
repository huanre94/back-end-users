using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DataTransferObjects
{
    public record OwnerDto(long Id, string Name, string Telephone, string Email, bool Status);

    public record OwnerCreateDto(string Name, string Telephone, string Email, bool Status,
        IEnumerable<PetCreateDto> Pets);

    public record OwnerUpdateDto(string Name, string Telephone, string Email, bool Status);
}
