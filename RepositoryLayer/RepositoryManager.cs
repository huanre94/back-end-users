using RepositoryLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly PetStoreContext _petStoreContext;
        private readonly Lazy<IOwnerRepository> _ownerRepository;
        private readonly Lazy<IPetRepository> _petRepository;

        public RepositoryManager(PetStoreContext petStoreContext)
        {
            _petStoreContext = petStoreContext;
            _ownerRepository = new Lazy<IOwnerRepository>(() => new OwnerRepository(_petStoreContext));
            _petRepository = new Lazy<IPetRepository>(() => new PetRepository(_petStoreContext));
        }

        public IOwnerRepository Owner => _ownerRepository.Value;

        public IPetRepository Pet => _petRepository.Value;

        public void Save() => _petStoreContext.SaveChanges();

        public async Task SaveAsync() => await _petStoreContext.SaveChangesAsync();
    }
}
