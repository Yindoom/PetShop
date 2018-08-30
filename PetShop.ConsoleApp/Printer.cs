using PetShop.Core.Entity;
using PetShop.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.ConsoleApp
{
    public class Printer : IPrinter
    {

        IPetService _petService;
        public Printer(IPetService petService)
        {
            _petService = petService;
            StartUI();
        }
        public void StartUI()
        {
            Console.WriteLine("Welcome to the PetShop");
            ShowMenu();
        }

        private void ShowMenu()
        {
            Console.WriteLine("\nWhat would you like to do?");
            Console.WriteLine("1. Show all pets");
            Console.WriteLine("2. Show all pets by price");
            Console.WriteLine("3. Show 5 cheapest pets");
            Console.WriteLine("4. Search pets by type");
            Console.WriteLine("5. Show info for specific pet by id");
            Console.WriteLine("6. Add new pet");
            Console.WriteLine("7. Update existing pet");
            Console.WriteLine("8. Delete pet");
            Console.WriteLine("9. Exit");
            int choice;
            int repetition = 0;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice > 9 || choice < 1)
            {
                Console.WriteLine("Please make your selection using a number between 1 and 9");
                repetition++;
                if (repetition > 5)
                {
                    ShowMenu();
                }
            }
            int id;
            switch (choice)
            {
                
                case 1:
                    ShowPets(_petService.GetAllPets());
                    break;
                case 2:
                    ShowPets(_petService.GetPetsByPrice());
                    break;
                case 3:
                    ShowPets(_petService.GetCheapest());
                    break;
                case 4:
                    Console.WriteLine("What kind of animal do you want?");
                    try
                    {
                        ShowPets(_petService.GetPetsByType(Console.ReadLine()));
                    }
                    catch(Exception)
                    {
                        Console.WriteLine("We don't have any of those. Sorry.");
                        ShowMenu();
                    }
                    break;
                case 5:
                    Console.WriteLine("Choose animal by id");
                    while (!int.TryParse(Console.ReadLine(), out id))
                    {
                        Console.WriteLine("Id must be a number");
                    }
                    ShowInfo(id);
                    Console.ReadLine();
                    ShowMenu();
                    break;
                case 6:
                    AddPet();
                    break;
                case 7:
                    Console.WriteLine("Choose animal by id");
                    while (!int.TryParse(Console.ReadLine(), out id))
                    {
                        Console.WriteLine("Id must be a number");
                    }
                    UpdatePet(id);
                    break;
                case 8:
                    Console.WriteLine("Choose animal by id");
                    while (!int.TryParse(Console.ReadLine(), out id))
                    {
                        Console.WriteLine("Id must be a number");
                    }
                    DeletePet(id);
                    break;
                case 9:
                    break;
            }


        }

        private void DeletePet(int id)
        {
            ShowInfo(id);
            Console.WriteLine("Do you want to delete this pet? y/n");
            switch (Console.ReadLine())
            {
                case "y":
                    _petService.DeletePet(id);
                    Console.Clear();
                    Console.WriteLine("Pet deleted");
                    ShowMenu();
                    break;
                case "n":
                    ShowMenu();
                    break;
                default:
                    Console.WriteLine("\n Please answer y or n");
                    DeletePet(id);
                    break;
            }
        }

        private void UpdatePet(int id)
        {
            Console.WriteLine();
            ShowInfo(id);
            Console.WriteLine("Do you want to update this pet? y/n");
            switch (Console.ReadLine().ToLower())
            {
                case "y":
                    Console.Write("Enter updated name of Pet: ");
                    var Name = Console.ReadLine();
                    Console.Write("Enter updated type of Pet: ");
                    var Type = Console.ReadLine();
                    Console.Write("Enter updated colour of pet: ");
                    var Colour = Console.ReadLine();
                    Console.Write("Enter updated previous owner of Pet: ");
                    var PreviousOwner = Console.ReadLine();
                    Console.Write("Enter updated price of Pet: ");
                    double Price;
                    while (!double.TryParse(Console.ReadLine(), out Price))
                    {
                        Console.WriteLine("Price must be a number value.");
                    }
                    Console.Write("Enter updated birthdate of pet: ");
                    DateTime Birthdate;
                    while (!DateTime.TryParse(Console.ReadLine(), out Birthdate))
                    {
                        Console.WriteLine("This is not a valid date. Try again using the format of dd/MM/yyyy");
                    }
                    _petService.UpdatePet(id, Name, Type, Colour, PreviousOwner, Price, Birthdate);
                    Console.Clear();
                    Console.WriteLine($"{Name} has been updated.\n ");
                    ShowMenu();
                    break;
                case "n":
                    ShowMenu();
                    break;
                default:
                    Console.WriteLine("\nPlease answer yes or no as y or n\n");
                    UpdatePet(id);
                    break;
            }
        }

        private void AddPet()
        {
            Console.Write("Enter name of Pet: ");
            var Name = Console.ReadLine();
            Console.Write("Enter type of Pet: ");
            var Type = Console.ReadLine();
            Console.Write("Enter colour of pet: ");
            var Colour = Console.ReadLine();
            Console.Write("Enter previous owner of Pet: ");
            var PreviousOwner = Console.ReadLine();
            Console.Write("Enter price of Pet: ");
            double Price;
            while(!double.TryParse(Console.ReadLine(), out Price))
            {
                Console.WriteLine("Price must be a number value.");
            }
            Console.Write("Enter birthdate of pet: ");
            DateTime Birthdate;
            while(!DateTime.TryParse(Console.ReadLine(), out Birthdate))
            {
                Console.WriteLine("This is not a valid date. Try again using the format of dd/MM/yyyy");
            }
            _petService.CreatePet(Name, Type, Colour, PreviousOwner, Price, Birthdate);
            Console.Clear();
            Console.WriteLine($"{Name} has been added");
            ShowMenu();
        }

        private void ShowInfo(int id)
        {
            try
            {
                Pet pet = _petService.GetPetById(id);
                Console.WriteLine($"Here is the information on the pet with the Id {pet.Id}: ");
                Console.WriteLine($"Id: {pet.Id}");
                Console.WriteLine($"Name: {pet.Name}");
                Console.WriteLine($"Type: {pet.Type}");
                Console.WriteLine($"Colour: {pet.Colour}");
                Console.WriteLine($"Price: {pet.Price}");
                Console.WriteLine($"Birthdate: {pet.Birthdate.ToString("dd/MM/yyyy")}");
                Console.WriteLine($"Previous Owner: {pet.PreviousOwner}");
                Console.WriteLine($"Sold on: {pet.SellDate.ToString("dd/MM/yyyy")}");
            }
            catch(Exception)
            {
                Console.WriteLine("No pet associated with this Id. Sorry.");
            }
        }

        private void ShowPets(List<Pet> pets)
        {
            Console.Clear();
            foreach (var pet in pets)
            {
                Console.WriteLine($"Id: {pet.Id}");
                Console.WriteLine($"Name: {pet.Name}");
                Console.WriteLine($"Type: {pet.Type}");
                Console.WriteLine($"Colour: {pet.Colour}");
                Console.WriteLine($"Price: {pet.Price}");
                Console.WriteLine();
            }
            Console.WriteLine("\nDo you want further information on a pet? y/n");
            switch(Console.ReadLine())
            {
                case "y":
                    Console.WriteLine("Type Id of the pet you want more info on: ");
                    int id;
                    while(!int.TryParse(Console.ReadLine(), out id))
                    {
                        Console.WriteLine("Id must be a number");
                    }
                    ShowInfo(id);
                    Console.WriteLine("Press enter to return");
                    Console.ReadLine();
                    Console.Clear();
                    ShowMenu();
                    break;
                case "n":
                    Console.Clear();
                    ShowMenu();
                    break;
                default:
                    Console.WriteLine("Not a command. Press enter to try again");
                    Console.ReadLine();
                    ShowPets(pets);
                    break;
            }
        }
    }
}
