using Microsoft.Extensions.DependencyInjection;
using PetShop.Console;
using PetShop.Core.Domain;
using PetShop.Core.Service;
using PetShop.Core.Service.Implimentation;
using PetShop.Infrastructure.Static.Data.Repositories;
using System;

namespace PetShop
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IPetRepository, PetRepository>();
            serviceCollection.AddScoped<IPrinter, Printer>();
            serviceCollection.AddScoped<IPetService, PetService>();
            serviceCollection.BuildServiceProvider();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var printer = serviceProvider.GetRequiredService<IPrinter>();
            printer.StartUI();
        }
    }
}
