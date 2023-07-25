using DomainLayer.Models;
using ServiceLayer.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Contracts
{
    public interface IOwnerService
    {
        IEnumerable<OwnerDto> GetAllOwners(bool trackChanges = false);
        OwnerDto GetOwnerById(long ownerId, bool trackChanges = false);

        OwnerDto CreateOwner(OwnerCreateDto owner);

        void UpdateOwner(long ownerId, OwnerUpdateDto owner, bool trackChanges = false);
        void DeleteOwner(long ownerId, bool trackChanges = false);
    }
}
