﻿using AutoMapper;
using RepositoryLayer.Contracts;
using ServiceLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IOwnerService> _ownerService;
        private readonly Lazy<IPetService> _petService;

        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _ownerService = new Lazy<IOwnerService>(() => new OwnerService(repositoryManager, mapper));
            _petService = new Lazy<IPetService>(() => new PetService(repositoryManager, mapper));
        }

        public IOwnerService OwnerService => _ownerService.Value;

        public IPetService PetService => _petService.Value;
    }
}
