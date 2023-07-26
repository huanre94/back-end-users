using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    internal sealed class OwnerRepository : RepositoryBase<Owner>, IOwnerRepository
    {
        public OwnerRepository(PetStoreContext petStoreContext) : base(petStoreContext)
        {
        }

        public void CreateOwner(Owner owner) => Create(owner);

        public async Task UpdateOwner(Owner owner) => Update(owner);

        public void DeleteOwner(Owner owner) => Delete(owner);

        public async Task<IEnumerable<Owner>> GetAllOwners(bool trackChanges = false)
        {
            return await FindAll(trackChanges)
                .OrderBy(o => o.Id)
                .ToListAsync();
        }

        public async Task<Owner> GetOwnerById(long ownerId, bool trackChanges = false)
        {
            return await FindByCondition(o => o.Id.Equals(ownerId), trackChanges)
                .SingleOrDefaultAsync();
        }

    }
}
