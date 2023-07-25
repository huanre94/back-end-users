using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Contracts
{
    public interface IPetRepository
    {
        IEnumerable<Pet> GetPets(long ownerId, bool trackChanges = false);
        Pet GetPetById(long ownerId, long id, bool trackChanges = false);

        void CreatePet(long ownerId, Pet pet);
        void UpdatePet(long ownerId, Pet pet);
        void DeletePet(Pet pet);
    }
}
