using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tracsis.Service
{
    /// <summary>
    /// Service to read input codes from a text file.
    /// </summary>
    public class InputService : IInputService
    {
        private List<string> _LocationCodes { get; set; }

        public InputService()
        {
            _LocationCodes = new List<string>();
        }

        /// <summary>
        /// Read the input file and place all codes into a list, then enumerate.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public void SetLocationCodes(string filePath)
        {
            // When input file is exists.
            if (File.Exists(filePath))
            {
                // Open the file steam and read each data line.
                var lines = File.ReadAllLines(filePath);
                if (lines != null)
                {
                    foreach (var line in lines)
                    {
                        // When line contains a valid string, trim then upper.
                        if (!string.IsNullOrEmpty(line))
                        {
                            // Add code to the list.
                            _LocationCodes.Add(line.Trim().ToUpper());
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Get enumerated list of input codes.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetLocationCodes()
        {
            return _LocationCodes;
        }

        /// <summary>
        /// If the list contains any data return true.
        /// </summary>
        public bool HasCodes
        {
            get
            {
                return _LocationCodes.Count() > 0;
            }
        }
    }
}