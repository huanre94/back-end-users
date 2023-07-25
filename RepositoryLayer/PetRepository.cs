using DomainLayer.Models;
using RepositoryLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public class PetRepository : RepositoryBase<Pet>, IPetRepository
    {
        public PetRepository(PetStoreContext petStoreContext) : base(petStoreContext)
        {
        }

        public IEnumerable<Pet> GetAllPets(bool trackChanges = false)
        {
            return FindAll(trackChanges)
                 .OrderBy(p => p.Id)
                 .ToList();
        }

        public Pet GetPetById(long id, bool trackChanges = false)
        {
            return FindByCondition(p => p.Id.Equals(id), trackChanges)
                .SingleOrDefault();
        }

        public IEnumerable<Pet> GetPetsByOwnerId(long ownerId, bool trackChanges = false)
        {
            return FindByCondition(p => p.OwnerId.Equals(ownerId), trackChanges)
                .ToList();
        }
    }
}
