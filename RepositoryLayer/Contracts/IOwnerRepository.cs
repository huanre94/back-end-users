using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Contracts
{
    public interface IOwnerRepository
    {
        Task<IEnumerable<Owner>> GetAllOwners(bool trackChanges = false);
        Task<Owner> GetOwnerById(long ownerId, bool trackChanges = false);

        void CreateOwner(Owner owner);
        Task UpdateOwner(Owner owner);
        void DeleteOwner(Owner owner);
    }
}
