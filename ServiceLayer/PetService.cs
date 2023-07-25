using DomainLayer.Models;
using RepositoryLayer.Contracts;
using ServiceLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    internal sealed class PetService : IPetService
    {
        private readonly IRepositoryManager _repository;

        public PetService(IRepositoryManager repository)
        {
            _repository = repository;
        }

        public IEnumerable<Pet> GetAllPets(bool trackChanges = false)
        {
            var pets = _repository.Pet.GetAllPets(trackChanges);
            return pets;
        }

        public Pet GetPetById(long id, bool trackChanges = false)
        {
            var pet = _repository.Pet.GetPetById(id, trackChanges);
            return pet;
        }

        public IEnumerable<Pet> GetPetsByOwnerId(long ownerId, bool trackChanges = false)
        {
            var pets = _repository.Pet.GetPetsByOwnerId(ownerId, trackChanges);
            return pets;
        }
    }
}
