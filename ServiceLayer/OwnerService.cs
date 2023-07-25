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
    internal sealed class OwnerService : IOwnerService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public OwnerService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public OwnerDto CreateOwner(OwnerCreateDto owner)
        {
            var ownerEntity = _mapper.Map<Owner>(owner);

            _repository.Owner.CreateOwner(ownerEntity);
            _repository.Save();

            var ownerDto = _mapper.Map<OwnerDto>(ownerEntity);

            return ownerDto;
        }

        public void DeleteOwner(long ownerId, bool trackChanges = false) => throw new NotImplementedException();

        public IEnumerable<OwnerDto> GetAllOwners(bool trackChanges = false)
        {
            var owners = _repository.Owner.GetAllOwners(trackChanges);

            var ownersDto = _mapper.Map<IEnumerable<OwnerDto>>(owners);

            return ownersDto;
        }

        public OwnerDto GetOwnerById(long ownerId, bool trackChanges = false)
        {
            var owner = _repository.Owner.GetOwnerById(ownerId, trackChanges);

            var ownerDto = _mapper.Map<OwnerDto>(owner);

            return ownerDto;
        }

        public void UpdateOwner(long ownerId, OwnerUpdateDto owner, bool trackChanges = false)
        {
            var ownerDto = _repository.Owner.GetOwnerById(ownerId, trackChanges);

            if (ownerDto is null)
                throw new Exception("Dueño no encontrado.");

            _repository.Owner.UpdateOwner(ownerDto);
            _repository.Save();
        }
    }
}
