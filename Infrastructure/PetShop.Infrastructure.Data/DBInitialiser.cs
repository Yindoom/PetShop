using System;
using System.Collections.Generic;
using System.Linq;
using PetShop.Core.Entity;

namespace PetShop.Infrastructure.Data
{
    public class DBInitialiser
    {
        public static void SeedDB(PetShopContext ctx)
        {
            ctx.Database.EnsureCreated();
            if (!ctx.Users.Any())
            {
                string password = "1234";
                byte[] passwordHashJoe, passwordSaltJoe, passwordHashAnn, passwordSaltAnn;
                CreatePasswordHash(password, out passwordHashJoe, out passwordSaltJoe);
                CreatePasswordHash(password, out passwordHashAnn, out passwordSaltAnn);
                List<User> users = new List<User>
                {
                    new User
                    {
                        Username = "UserJoe",
                        PasswordHash = passwordHashJoe,
                        PasswordSalt = passwordSaltJoe,
                        IsAdmin = false
                    },
                    new User
                    {
                        Username = "AdminAnn",
                        PasswordHash = passwordHashAnn,
                        PasswordSalt = passwordSaltAnn,
                        IsAdmin = true
                    }
                };
                ctx.Users.AddRange(users);
            }

            
            if (!ctx.Pets.Any() && !ctx.Owners.Any())
            {
                var own = ctx.Owners.Add(new Owner()
                {
                    Birthdate = DateTime.Now,
                    Email = "yindoom@hotmail.com",
                    FirstName = "Bastian",
                    LastName = "Bønkel"
                }).Entity;

                var own2 = ctx.Owners.Add(new Owner()
                {
                    Birthdate = DateTime.Now,
                    Email = "yindoom@hotmail.com",
                    FirstName = "Naitsab",
                    LastName = "Bønkel",
                }).Entity;

                ctx.Pets.Add(new Pet()
                {
                    Birthdate = DateTime.Now,
                    Colour = "red",
                    Name = "Piggy",
                    Type = "Pig",
                    Price = 5000,
                    PreviousOwner = own2,
                    SellDate = DateTime.Now
                });
                ctx.Pets.Add(new Pet()
                {
                    Birthdate = DateTime.Now,
                    Colour = "Cream",
                    Name = "Miaw",
                    Type = "Cat",
                    Price = 5000,
                    PreviousOwner = own,
                    SellDate = DateTime.Now
                });
                ctx.Pets.Add(new Pet()
                {
                    Birthdate = DateTime.Now,
                    Colour = "Brown",
                    Name = "Woof",
                    Type = "Dog",
                    Price = 5000,
                    PreviousOwner = own,
                    SellDate = DateTime.Now
                });
                ctx.SaveChanges();
            }
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}