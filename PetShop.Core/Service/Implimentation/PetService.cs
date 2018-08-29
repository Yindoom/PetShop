using PetShop.Core.Domain;
using System;
using System.Collections.Generic;
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
    }
}
