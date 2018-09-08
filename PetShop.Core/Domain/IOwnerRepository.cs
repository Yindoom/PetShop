using System.Collections.Generic;
using PetShop.Core.Entity;

namespace PetShop.Core.Domain
{
    public interface IOwnerRepository
    {
        void AddOwner(Owner owner);

        IEnumerable<Owner> ReadOwners();

        void UpdatePet(Owner owner);

        void DeletePet(Owner deleteOwner);
    }
}