﻿using DomainLayer.Models;
using RepositoryLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    internal sealed class OwnerRepository : RepositoryBase<Owner>, IOwnerRepository
    {
        public OwnerRepository(PetStoreContext petStoreContext) : base(petStoreContext)
        {
        }

        public void CreateOwner(Owner owner) => Create(owner);

        public void UpdateOwner(Owner owner) => Update(owner);

        public void DeleteOwner(Owner owner) => Delete(owner);

        public IEnumerable<Owner> GetAllOwners(bool trackChanges = false)
        {
            return FindAll(trackChanges)
                .OrderBy(o => o.Id)
                .ToList();
        }

        public Owner GetOwnerById(long ownerId, bool trackChanges = false)
        {
            return FindByCondition(o => o.Id.Equals(ownerId), trackChanges)
                .SingleOrDefault();
        }

    }
}
