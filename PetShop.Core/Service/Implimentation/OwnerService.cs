using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PetShop.Core.Domain;
using PetShop.Core.Entity;

namespace PetShop.Core.Service.Implimentation
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;

        public OwnerService(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }
        public List<Owner> GetAllOwners()
        {
            return _ownerRepository.ReadOwners().ToList();
        }

        public void CreateOwner(Owner owner)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateOwner(Owner owner)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteOwner(Owner owner)
        {
            throw new System.NotImplementedException();
        }
    }
}