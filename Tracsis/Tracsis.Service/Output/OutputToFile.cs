using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tracsis.Service.Output
{
    public class OutputToFile : IOutputService
    {
        private bool HasError { get; set; }
        private List<string> _Locations { get; set; }

        public bool HasWarning { get; set; }
        public string Warning { get; set; }

        public OutputToFile()
        {
            _Locations = new List<string>();
        }

        /// <summary>
        /// Iterate through all codes, and find location.
        /// </summary>
        /// <param name="locationCodes"></param>
        public void WriteFile(IEnumerable<string> locationCodes, ILookupService lookupService, string outputFilePath)
        {
            // When location codes are empty can not write anything.
            if (locationCodes == null)
            {
                HasError = true;
            }
            else
            {
                // loop through all input codes.
                foreach (var locationCode in locationCodes)
                {
                    var location = lookupService.Lookup(locationCode);
                    if (!string.IsNullOrEmpty(location))
                    {
                        _Locations.Add(location);
                    }
                    else
                    {
                        Warning += $"{locationCode} was invalid.";
                    }
                }

                // When at least one location has been matched.
                if (_Locations.Any())
                {
                    WriteToOutputFile(outputFilePath);
                }
                else
                {
                    HasError = true;
                }
            }
        }

        /// <summary>
        /// Write all locations to an output file.
        /// </summary>
        /// <param name="outputFile"></param>
        private void WriteToOutputFile(string outputFilePath)
        {
            // Write to specified output file.
            using (StreamWriter outputFile = new StreamWriter(outputFilePath))
            {
                foreach (var line in _Locations)
                {
                    outputFile.Write($"{line}\n");
                }
            }
        }

        /// <summary>
        /// When the locations have been successfully saved to the output file return success.
        /// </summary>
        public bool IsSuccess
        {
            get
            {
                return !HasError;
            }
        }
    }
}