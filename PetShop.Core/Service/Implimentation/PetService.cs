using PetShop.Core.Domain;
using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShop.Core.Service.Implimentation
{
    public class PetService : IPetService
    {
        readonly IPetRepository _petRepository;

        public PetService(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public void CreatePet(Pet pet)
        {
            SavePet(pet);
        }
        public void CreatePet(string name, string type, string colour, int previousOwnerId, double price, DateTime birthdate)
        {

            Pet pet = new Pet()
            {
                Name = name,
                Type = type,
                PreviousOwner = new Owner(){Id = previousOwnerId},
                Colour = colour,
                Birthdate = birthdate,
                Price = price,
                SellDate = DateTime.Now
            };
            SavePet(pet);
        }

        public void DeletePet(int id)
        {
            Pet deletePet = GetPetById(id);
            _petRepository.DeletePet(deletePet);
        }

        public List<Pet> GetAllPets()
        {
            return _petRepository.ReadPets().ToList();
        }

        public List<Pet> GetCheapest()
        {
            var list = _petRepository.ReadPets();
            var query = list.OrderBy(pet => pet.Price);
            return query.Take(5).ToList();
        }

        public void UpdatePet(int id, Pet pet)
        {
            pet.Id = id;
            _petRepository.UpdatePet(pet);
        }

        public Pet GetPetById(int id)
        {
            foreach (var pet in _petRepository.ReadPets().ToList())
            {
                if(pet.Id == id)
                {
                    return pet;
                }
            }
            return null;
        }

        public List<Pet> GetPetsByPrice()
        {
            var list = _petRepository.ReadPets();
            var query = list.OrderBy(pet => pet.Price);
            return query.ToList();
        }

        public List<Pet> GetPetsByType(string type)
        {
            var list = _petRepository.ReadPets();
            var query = list.Where(pet => pet.Type.ToLower() == type.ToLower());
            if(query.ToList().Count > 0)
            {
                return query.ToList();
            }
            return null;
        }

        void SavePet(Pet pet)
        {
            _petRepository.AddPet(pet);
        }
        
    }
}
