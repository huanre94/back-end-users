using RepositoryLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Contracts
{
    public interface IServiceManager
    {
        IOwnerService OwnerService { get; }
        IPetService PetService { get; }
    }
}
