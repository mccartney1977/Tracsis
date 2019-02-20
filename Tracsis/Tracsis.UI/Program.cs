using System;
using Tracsis.Service;
using Tracsis.Utility;

namespace Tracsis.UI
{
    internal class Program
    {
        private static ILookupService _LookupService { get; set; }
        private static IInputService _InputService { get; set; }

        private static string _LookupFile = "";
        private static string _InputFile = "";
        private static string _OutputFile = "";

        private static void Main(string[] args)
        {
            // Initialise dependency services.
            _InputService = new InputService();
            _LookupService = new LookupFromFile();

            // When arguments are pass correctly read and assignment them respectively.
            if (args != null && args.Length == 3)
            {
                _LookupFile = args[0];
                _InputFile = args[1];
                _OutputFile = args[2];
            }
            else
            {
                // When arguments are not passed, prompt user to enter them.
                Console.WriteLine("Enter the lookup file path: ");
                _LookupFile = Console.ReadLine();
                Console.WriteLine("Enter the input file path: ");
                _InputFile = Console.ReadLine();
                Console.WriteLine("Enter the output file path: ");
                _OutputFile = Console.ReadLine();
            }

            // Validate files are of correct type and exist where relevent.
            if (HasValidArguments())
            {
                // Initialise the lookup service.
                _LookupService.Initialise(_LookupFile);
                if (_LookupService.HasData)
                {
                    _InputService.SetLocationCodes(_InputFile);

                    if (_InputService.HasCodes)
                    {
                        var locationCodes = _InputService.GetLocationCodes();
                        foreach (var locationCode in locationCodes)
                        {
                            var location = _LookupService.Lookup(locationCode);
                            Console.WriteLine($"{locationCode} = {location}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Lookup service is empty.");
                }
            }

            // Close application.
            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }

        // Validate all files are of type txt.
        // Validate the input and lookup files exist.
        private static bool HasValidArguments()
        {
            if (!FileUtility.IsValidFile(_LookupFile))
            {
                Console.WriteLine("The lookup file is not valid.");
                return false;
            }
            else if (!FileUtility.IsValidFile(_InputFile))
            {
                Console.WriteLine("The input file is not valid.");
                return false;
            }
            else if (!FileUtility.IsValidFileType(_OutputFile))
            {
                Console.WriteLine("The input file is not a txt file.");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}