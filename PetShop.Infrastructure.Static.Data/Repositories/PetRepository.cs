using PetShop.Core.Domain;
using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShop.Infrastructure.Static.Data.Repositories
{
    public class PetRepository : IPetRepository
    {         
        public void AddPet(Pet pet)
        {
            var list = FakeDb.Pets ;
            pet.Id = list.ElementAt(list.Count()-1).Id+1;
            var petList = list.ToList();
            petList.Add(pet);

            FakeDb.Pets = petList;
        }

        public void DeletePet(Pet deletePet)
        {
            var list = FakeDb.Pets.ToList();
            list.Remove(deletePet);
            FakeDb.Pets = list;
        }

        public IEnumerable<Pet> ReadPets()
        {
            return FakeDb.Pets;
        }

        public void UpdatePet(Pet updatePet)
        {
            var list = FakeDb.Pets.ToArray(); ;
            for (int i = 0; i < list.Length; i++)
            {
                if(list[i].Id == updatePet.Id)
                {
                    list[i] = updatePet;
                }
            }
            FakeDb.Pets = list;
        }
    }
}
