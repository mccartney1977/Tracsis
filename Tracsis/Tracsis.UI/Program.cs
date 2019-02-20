using System;
using Tracsis.Service;
using Tracsis.Utility;

namespace Tracsis.UI
{
    internal class Program
    {
        private static ILookupService _LookupService { get; set; }
        private static string _LookupFile = "";
        private static string _InputFile = "";
        private static string _OutputFile = "";

        private static void Main(string[] args)
        {
            // When arguments are pass correctly read and assignment them respectively.
            if (args != null && args.Length == 3)
            {
                _LookupFile = args[1];
                _InputFile = args[2];
                _OutputFile = args[3];
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
            if(HasValidArguments())
            {
                // Initialise dependencies.
                _LookupService = new LookupFromFile();

                // Initialise the lookup service.
                _LookupService.Initialise(_LookupFile);
                if (_LookupService.HasData)
                {
                    //var locationName = _LookupService.Lookup(locationCode);
                }
                else
                {
                    Console.WriteLine("Lookup service is empty.");
                }
            }

            // Close application.
            Console.WriteLine("Press any key to exit.");
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