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

        public Pet GetPetById(bool trackChanges = false)
        {
            return FindByCondition(p => p.Id.Equals(p.Id), trackChanges)
                .SingleOrDefault();
        }

        public IEnumerable<Pet> GetPetsByOwnerId(bool trackChanges = false)
        {
            return FindByCondition(p => p.OwnerId.Equals(p.OwnerId), trackChanges)
                .ToList();
        }
    }
}
