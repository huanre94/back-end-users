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
    internal sealed class OwnerService : IOwnerService
    {
        private readonly IRepositoryManager _repository;

        public OwnerService(IRepositoryManager repository)
        {
            _repository = repository;
        }

        public IEnumerable<Owner> GetAllOwners(bool trackChanges = false)
        {
            var owners = _repository.Owner.GetAllOwners(trackChanges);
            return owners;
        }

        public Owner GetOwnerById(long ownerId, bool trackChanges = false)
        {
            var owner = _repository.Owner.GetOwnerById(ownerId, trackChanges);
            return owner;
        }
    }
}
