using System.Collections.Generic;
using PetShop.Core.Entity;

namespace PetShop.Core.Service
{
    public interface IOwnerService
    {
        List<Owner> GetAllOwners();
        Owner GetOwnerById(int id);
        void CreateOwner(Owner owner);
        void UpdateOwner(Owner owner, int id);
        void DeleteOwner(int id);
    }
}