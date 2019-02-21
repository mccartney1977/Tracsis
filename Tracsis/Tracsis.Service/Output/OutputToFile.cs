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
        public bool CannotWriteFile { get; set; }
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
                    CannotWriteFile = WriteToOutputFile(outputFilePath);
                    HasError = true;
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
        private bool WriteToOutputFile(string outputFilePath)
        {
            bool cannotWriteFile = false;

            // When can not write to the specified path.
            // Catch the protential error and provide message for user.
            try
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
            catch (System.IO.DirectoryNotFoundException ex)
            {
                cannotWriteFile = true;
            }

            return cannotWriteFile;
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