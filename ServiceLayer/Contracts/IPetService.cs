using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Contracts
{
    public interface IPetService
    {

        IEnumerable<Pet> GetAllPets(bool trackChanges = false);
        Pet GetPetById(bool trackChanges = false);

        IEnumerable<Pet> GetPetsByOwnerId(bool trackChanges = false);
    }
}
