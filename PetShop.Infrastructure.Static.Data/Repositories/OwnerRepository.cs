using System.Collections.Generic;
using PetShop.Core.Domain;
using PetShop.Core.Entity;

namespace PetShop.Infrastructure.Static.Data.Repositories
{
    public class OwnerRepository: IOwnerRepository
    {
        public void AddOwner(Owner owner)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Owner> ReadOwners()
        {
            return FakeDb.Owners;
        }

        public void UpdatePet(Owner owner)
        {
            throw new System.NotImplementedException();
        }

        public void DeletePet(Owner deleteOwner)
        {
            throw new System.NotImplementedException();
        }
    }
}