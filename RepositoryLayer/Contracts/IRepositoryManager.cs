using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Contracts
{
    public interface IRepositoryManager
    {
        IOwnerRepository Owner { get; }
        IPetRepository Pet { get; }
        void Save();
        Task SaveAsync();
    }
}
