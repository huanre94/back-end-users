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
        IEnumerable<Pet> GetAllPets(bool trackChanges = false);
        Pet GetPetById(long id, bool trackChanges = false);

        IEnumerable<Pet> GetPetsByOwnerId(long ownerId, bool trackChanges = false);


    }
}
