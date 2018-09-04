using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.Entity;

namespace LazyShit.PetShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<List<Pet>> Get()
        {
            return new List<Pet>()
            {
                new Pet()
                {
                    Birthdate = DateTime.Parse("27/07/1995"),
                    Colour = "Red",
                    Id = 1,
                    Name = "Dingus",
                    Price = 500,
                    Type = "Doggo",
                    PreviousOwner = "Dongo",
                    SellDate = DateTime.Now
                }
                
            };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            List<Pet> pets = new List<Pet>();
                 Pet pet1 = new Pet()
            {
                Id = 0,
                Name = "Boy",
                Birthdate = DateTime.Parse("1/1/1998"),
                Colour = "Red",
                PreviousOwner = "Mary Poppins",
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
                PreviousOwner = "Ebenezer Screwge",
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
                PreviousOwner = "Lucy Lue",
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
                PreviousOwner = "Me",
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
                PreviousOwner = "Johnny",
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
                PreviousOwner = "Tomek",
                Birthdate = DateTime.Parse("19/6/2005"),
                Price = 0,
                SellDate = DateTime.Parse("20/6/2005")
            };
            pets = new List<Pet> { pet1, pet2, pet3, pet4, pet5, pet6 };
            foreach (var pet in pets)
            {
                if (id == pet.Id)
                {
                    return pet;
                }
            }

            return null;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}