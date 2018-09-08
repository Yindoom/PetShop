using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.CompilerServices;
using PetShop.Core.Entity;
using PetShop.Core.Service;

namespace LazyShit.PetShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetsController(IPetService petService)
        {
            _petService = petService;
        }

    // GET api/values
        [HttpGet]
        public ActionResult<List<Pet>> Get()
        {
            return _petService.GetAllPets();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
           return _petService.GetPetById(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Pet pet)
        {
            _petService.CreatePet(pet);
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