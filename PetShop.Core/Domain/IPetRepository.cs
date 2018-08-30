using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.Domain
{
    public interface IPetRepository
    {
        void AddPet(Pet pet);

        IEnumerable<Pet> ReadPets();

        void UpdatePet(Pet pet);

        void DeletePet(Pet deletePet);
    }
}
