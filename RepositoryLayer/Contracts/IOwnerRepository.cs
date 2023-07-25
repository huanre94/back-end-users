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
        IEnumerable<Owner> GetAllOwners(bool trackChanges = false);
        Owner GetOwnerById(long ownerId, bool trackChanges = false);

        void CreateOwner(Owner owner);
        void UpdateOwner(Owner owner);
        void DeleteOwner(Owner owner);
    }
}
