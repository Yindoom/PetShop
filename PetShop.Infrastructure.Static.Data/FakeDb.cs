﻿using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Infrastructure.Static.Data
{
    public class FakeDb
    {
        public static IEnumerable<Pet> Pets;
        public static IEnumerable<Owner> Owners;
        public static void InitDate()
        {
            Owners = new List<Owner>()
            {
                new Owner()
                {
                    Birthdate = DateTime.Parse("27/07/1995"),
                    Id = 0,
                    Email = "yindoom@hotmail.com",
                    FirstName = "Bastian",
                    LastName = "Bønkel"
                },
                new Owner()
                {
                    Id = 1,
                    FirstName = "Fabio",
                    LastName = "Moniz",
                    Email = "fabiomoniz@portugal.dk",
                    Birthdate = DateTime.Parse("07/07/1997")
                }
            };
            Pet pet1 = new Pet()
            {
                Id = 0,
                Name = "Boy",
                Birthdate = DateTime.Parse("1/1/1998"),
                Colour = "Red",
                PreviousOwner = new Owner() {Id = 0},
                Price = 5000,
                SellDate = DateTime.Parse("24/12/2018"),
                Type = "Cat"
            };
            Pet pet2 = new Pet()
            {
                Id = 1,
                Name = "Piggy",
                Birthdate = DateTime.Parse("6/9/1778"),
                Colour = "Pink",
                PreviousOwner = new Owner() { Id = 1},
                Price = 5,
                SellDate = DateTime.Parse("8/1/1995"),
                Type = "Pig"
            };
            Pet pet3 = new Pet()
            {
                Id = 2,
                Name = "Boris",
                Type = "Camel",
                Colour = "Brown",
                PreviousOwner = new Owner() {Id = 0},
                Birthdate = DateTime.Parse("19/6/2005"),
                Price = 500,
                SellDate = DateTime.Parse("20/6/2005")
            };
            Pet pet4 = new Pet()
            {
                Id = 3,
                Name = "Willow",
                Type = "Popcorn",
                Colour = "White",
                PreviousOwner = new Owner() {Id = 0},
                Birthdate = DateTime.Parse("30/08/2018"),
                Price = 20_000,
                SellDate = DateTime.Parse("31/08/2018")
            };
            Pet pet5 = new Pet()
            {
                Id = 4,
                Name = "Dingo",
                Type = "Dingo",
                Colour = "Grey",
                PreviousOwner = new Owner(){Id = 1},
                Birthdate = DateTime.Parse("19/12/2005"),
                Price = 200,
                SellDate = DateTime.Parse("20/7/2012")
            };
            Pet pet6 = new Pet()
            {
                Id = 5,
                Name = "Marin",
                Type = "Human",
                Colour = "White-ish",
                PreviousOwner = new Owner(){Id = 1},
                Birthdate = DateTime.Parse("19/6/2005"),
                Price = 0,
                SellDate = DateTime.Parse("20/6/2005")
            };
            Pets = new List<Pet> { pet1, pet2, pet3, pet4, pet5, pet6 };
        }
    }
}
