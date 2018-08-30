using Microsoft.Extensions.DependencyInjection;
using PetShop.Core.Domain;
using PetShop.Core.Service;
using PetShop.Core.Service.Implimentation;
using PetShop.Infrastructure.Static.Data;
using PetShop.Infrastructure.Static.Data.Repositories;
using System;

namespace PetShop.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            FakeDb.InitDate();
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IPetRepository, PetRepository>();
            serviceCollection.AddScoped<IPrinter, Printer>();
            serviceCollection.AddScoped<IPetService, PetService>();
            serviceCollection.BuildServiceProvider();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var petService = serviceProvider.GetRequiredService<IPetService>();

            new Printer(petService);


        }
    }
}
