using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using PetShop.Core.Domain;
using PetShop.Core.Entity;
using PetShop.Infrastructure.Data;

namespace PetShop.Infrastructure.Data.SQLRepositories
{
    public class PetRepository : IPetRepository
    {
        private readonly PetShopContext _ctx;

        public PetRepository(PetShopContext ctx)
        {
            _ctx = ctx;
        }
        public Pet AddPet(Pet pet)
        {
            _ctx.Pets.Add(pet);
            _ctx.SaveChanges();
            return pet;
        }

        public IEnumerable<Pet> ReadPets()
        {
            return _ctx.Pets;
        }

        public Pet ReadById(int id)
        {
            return _ctx.Pets.FirstOrDefault(p => p.Id == id);
        }

        public Pet UpdatePet(Pet pet)
        {
            _ctx.Pets.Update(pet);
            _ctx.SaveChanges();
            return pet;
        }

        public Pet DeletePet(Pet deletePet)
        {
            _ctx.Remove(deletePet);
            return deletePet;
        }
    }
}