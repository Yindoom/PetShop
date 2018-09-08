using System.Collections.Generic;
using PetShop.Core.Entity;

namespace PetShop.Core.Service
{
    public interface IOwnerService
    {
        List<Owner> GetAllOwners();
        void CreateOwner(Owner owner);
        void UpdateOwner(Owner owner);
        void DeleteOwner(Owner owner);
    }
}