using System;
using Tracsis.Service;
using Tracsis.Service.Input;
using Tracsis.Service.Lookup;
using Tracsis.Service.Output;
using Tracsis.Utility;

namespace Tracsis.UI
{
    internal class Program
    {
        private static ILookupService _LookupService { get; set; }
        private static IInputService _InputService { get; set; }
        private static IOutputService _OutputService { get; set; }

        private static string _LookupFile = "";
        private static string _InputFile = "";
        private static string _OutputFile = "";

        private static void Main(string[] args)
        {
            // Initialise dependency services.
            _InputService = new InputService();
            _LookupService = new LookupFromFile();
            _OutputService = new OutputToFile();

            // When arguments are passed correctly read and assignment them respectively.
            GetRequiredFiles(args);

            // Validate files are of correct type and exist where relevent.
            if (HasValidArguments())
            {
                // Initialise the lookup service.
                _LookupService.Initialise(_LookupFile);

                // When the lookup service contains data.
                if (_LookupService.HasData)
                {
                    // Process the input file, store location codes in generic enumerable list.
                    _InputService.SetLocationCodes(_InputFile);

                    // When the input service contains valid data.
                    if (_InputService.HasCodes)
                    {
                        // Get location codes then write to output file.
                        var locationCodes = _InputService.GetLocationCodes();
                        _OutputService.WriteFile(locationCodes, _LookupService, _OutputFile);

                        // When complete display message.
                        if (_OutputService.IsSuccess)
                        {
                            if (_OutputService.HasWarning)
                            {
                                Console.WriteLine("Output file created, with warnings.");
                                Console.WriteLine(_OutputService.Warning);
                            }
                            else
                            {
                                Console.WriteLine("Output file successfully created.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Can not create output file.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Input file was empty or invalid.");
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

        /// <summary>
        /// Set the file names for the three required files. (1. Lookup, 2. Input location codes, 3. Output location names).
        /// </summary>
        /// <param name="args"></param>
        private static void GetRequiredFiles(string[] args)
        {
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