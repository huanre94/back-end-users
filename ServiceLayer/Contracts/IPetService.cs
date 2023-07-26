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

        Task<IEnumerable<PetDto>> GetPets(long ownerId, bool trackChanges = false);
        Task<PetDto> GetPetById(long ownerId, long id, bool trackChanges = false);

        Task<PetDto> CreatePet(long ownerId, PetCreateDto pet, bool trackChanges = false);

        Task UpdatePet(long ownerId, long id, PetUpdateDto petUpdate, bool ownerTrackChanges = false, bool petTrackChanges = false);
        void DeletePet(long ownerId, long id, bool trackChanges = false);
    }
}
