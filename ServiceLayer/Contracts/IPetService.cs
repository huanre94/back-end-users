using DomainLayer.Models;
using ServiceLayer.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Contracts
{
    public interface IPetService
    {

        IEnumerable<PetDto> GetPets(long ownerId, bool trackChanges = false);
        PetDto GetPetById(long ownerId, long id, bool trackChanges = false);

        PetDto CreatePet(long ownerId, PetCreateDto pet, bool trackChanges = false);

        void UpdatePet(long id, PetUpdateDto pet, bool trackChanges = false);
        void DeletePet(long id, bool trackChanges = false);
    }
}
