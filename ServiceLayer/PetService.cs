using AutoMapper;
using DomainLayer.Models;
using RepositoryLayer.Contracts;
using ServiceLayer.Contracts;
using ServiceLayer.DataTransferObjects;
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
        private readonly IMapper _mapper;

        public PetService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PetDto> CreatePet(long ownerId, PetCreateDto petCreate, bool trackChanges = false)
        {
            var owner = _repository.Owner.GetOwnerById(ownerId, trackChanges);

            if (owner is null)
                throw new Exception("Owner not found");

            var petEntity = _mapper.Map<Pet>(petCreate);

            _repository.Pet.CreatePet(ownerId, petEntity);
            await _repository.SaveAsync();

            var petResponseDto = _mapper.Map<PetDto>(petEntity);

            return petResponseDto;
        }

        public void DeletePet(long ownerId, long id, bool trackChanges = false) => throw new NotImplementedException();

        public async Task<IEnumerable<PetDto>> GetPets(long ownerId, bool trackChanges = false)
        {
            var owner = await _repository.Owner.GetOwnerById(ownerId, trackChanges);

            if (owner is null)
                throw new Exception("Owner not found");

            var petsFromOwner = await _repository.Pet.GetPets(ownerId, trackChanges);

            var petsDto = _mapper.Map<IEnumerable<PetDto>>(petsFromOwner);

            return petsDto;
        }

        public async Task<PetDto> GetPetById(long ownerId, long id, bool trackChanges = false)
        {
            var pet = await _repository.Pet.GetPetById(ownerId, id, trackChanges);

            var petDto = _mapper.Map<PetDto>(pet);

            return petDto;
        }

        public async Task UpdatePet(long ownerId, long id, PetUpdateDto petUpdate, bool ownerTrackChanges = false, bool petTrackChanges = false)
        {
            var owner = await _repository.Owner.GetOwnerById(ownerId, ownerTrackChanges);

            if (owner is null)
                throw new Exception("Owner not found");


            var petEntity = await _repository.Pet.GetPetById(ownerId, id, petTrackChanges);

            if (petEntity is null)
                throw new Exception("Pet not found");

            _mapper.Map(petUpdate, petEntity);
            _repository.SaveAsync();
        }
    }
}
