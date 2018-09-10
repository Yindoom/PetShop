using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using PetShop.Core.Domain;
using PetShop.Core.Entity;

namespace PetShop.Infrastructure.Static.Data.Repositories
{
    public class OwnerRepository: IOwnerRepository
    {
        public void AddOwner(Owner owner)
        {
            var owners = FakeDb.Owners;
            owner.Id = owners.ElementAt(owners.Count() - 1).Id+1;
            var list = owners.ToList();
            list.Add(owner);
            FakeDb.Owners = list;
        }

        public IEnumerable<Owner> ReadOwners()
        {
            return FakeDb.Owners;
        }

        public void UpdateOwner(Owner owner)
        {
            var list = FakeDb.Owners.ToArray();
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i].Id == owner.Id)
                {
                    list[i] = owner;
                }
            }

            FakeDb.Owners = list;
        }

        public void DeleteOwner(Owner deleteOwner)
        {
            var list = FakeDb.Owners.ToList();
            list.Remove(deleteOwner);
            FakeDb.Owners = list;
        }
    }
}