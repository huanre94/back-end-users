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

        public void CreatePet(long ownerId, Pet pet)
        {
            pet.OwnerId = ownerId;
            Create(pet);
        }

        public void DeletePet(Pet pet) => Delete(pet);

        public void UpdatePet(long ownerId, Pet pet)
        {
            pet.OwnerId = ownerId;
            Update(pet);
        }

        public IEnumerable<Pet> GetPets(long ownerId, bool trackChanges = false)
        {
            return FindByCondition(p => p.OwnerId == ownerId, trackChanges)
                 .OrderBy(p => p.Id)
                 .ToList();
        }

        public Pet GetPetById(long ownerId, long id, bool trackChanges = false)
        {
            return FindByCondition(p => p.OwnerId.Equals(ownerId) && p.Id.Equals(id), trackChanges)
                .SingleOrDefault();
        }


    }
}
