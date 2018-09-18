using System.Collections.Generic;
using System.Linq;
using PetShop.Core.Domain;
using PetShop.Core.Entity;

namespace PetShop.Infrastructure.Data.SQLRepositories
{
    public class OwnerRepository : IOwnerRepository
    {

        private readonly PetShopContext _ctx;

        public OwnerRepository(PetShopContext ctx)
        {
            _ctx = ctx;
        }

        public Owner AddOwner(Owner owner)
        {
            _ctx.Owners.Add(owner);
            _ctx.SaveChanges();
            return owner;
        }

        public IEnumerable<Owner> ReadOwners()
        {
            return _ctx.Owners;
        }

        public Owner ReadById(int id)
        {
            return _ctx.Owners.FirstOrDefault(o => o.Id == id);
        }

        public Owner UpdateOwner(Owner owner)
        {
            _ctx.Owners.Update(owner);
            _ctx.SaveChanges();
            return owner;
        }

        public Owner DeleteOwner(Owner owner)
        {
            _ctx.Remove(owner);
            return owner;
        }
    }
}