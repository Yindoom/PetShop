using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.Service
{
    public interface IPetService
    {
        void CreatePet(string name, string type, string colour, int previousOwnerId, double price, DateTime birthdate);
        void CreatePet(Pet pet);

        List<Pet> GetAllPets();
        Pet GetPetById(int id);
        List<Pet> GetPetsByType(string type);

        void DeletePet(int id);
        List<Pet> GetPetsByPrice();
        List<Pet> GetCheapest();
        void UpdatePet(int id, Pet name);
    }
}
