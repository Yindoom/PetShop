using System;
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

        public Owner GetOwnerById(int id)
        {
            var list = GetAllOwners().ToList();
            foreach (var owner in list)
            {
                if (owner.Id == id)
                {
                    return owner;
                }
            }

            return null;
        }

        public void CreateOwner(Owner owner)
        {
            _ownerRepository.AddOwner(owner);
        }

        public void UpdateOwner(Owner owner, int id)
        {
            _ownerRepository.UpdateOwner(owner);
        }

        public void DeleteOwner(int id)
        {
            var deleteOwner = GetOwnerById(id);
            _ownerRepository.DeleteOwner(deleteOwner);
        }

    }
}