using PetShop.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Console
{
    class Printer : IPrinter
    {
        readonly IPetService _petService;
        Printer(IPetService petService)
        {
            _petService = petService;
        }
        public void StartUI()
        {
            
        }
    }
}
