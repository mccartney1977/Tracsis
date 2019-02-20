using System;
using Tracsis.Service;

namespace Tracsis.UI
{
    internal class Program
    {
        public static ILookupService _LookupService { get; set; }

        private static void Main(string[] args)
        {
            // Initialise dependencies.
            _LookupService = new LookupFromFile();
            string lookupFileName = "";

            Console.WriteLine("Please enter the lookup filename: ");
            lookupFileName = Console.ReadLine();

            // Initialise the lookup service.
            _LookupService.Initialise(lookupFileName);
            if (_LookupService.HasData)
            {
                Console.WriteLine("Enter the location code:");
                var locationCode = Console.ReadLine();
                var locationName = _LookupService.Lookup(locationCode);
                Console.WriteLine($"The location name is: {locationName}");
            }
            else
            {
                Console.WriteLine("Lookup service is empty.");
            }

            Console.ReadLine();
        }
    }
}