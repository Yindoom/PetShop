using System.Collections.Generic;
using PetShop.Core.Entity;

namespace PetShop.Core.Domain
{
    public interface IOwnerRepository
    {
        void AddOwner(Owner owner);

        IEnumerable<Owner> ReadOwners();

        void UpdateOwner(Owner owner);

        void DeleteOwner(Owner deleteOwner);
    }
}