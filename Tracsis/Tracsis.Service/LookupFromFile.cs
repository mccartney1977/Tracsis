using System.Collections.Generic;
using TracsisData;

namespace Tracsis.Service
{
    /// <summary>
    /// Concrete class to initialise the lookup service from a text file input.
    /// </summary>
    public class LookupFromFile : ILookupService
    {
        private IDataContext _DataContext { get; set; }
        private Dictionary<string, string> _LookupData { get; set; }

        /// <summary>
        /// Initialise the data service from
        /// </summary>
        /// <param name="fileName"></param>
        public LookupFromFile()
        {
            _DataContext = new LookupContext();
            _LookupData = new Dictionary<string, string>();
        }

        /// <summary>
        /// Populate the lookup dictionary from the requested file.
        /// </summary>
        /// <param name="fileName"></param>
        public void Initialise(string fileName)
        {
            if (!_DataContext.HasData)
            {
                _DataContext.SetData(fileName);
                _LookupData = _DataContext.GetData();
            }
        }

        /// <summary>
        /// Find the location given the dictionary index.
        /// </summary>
        /// <param name="locationCode"></param>
        /// <returns></returns>
        public string Lookup(string locationCode)
        {
            string location = "";

            if (!string.IsNullOrEmpty(locationCode))
            {
                // Get the location from the dictionary object.
                _LookupData.TryGetValue(locationCode, out location);
            }

            return location;
        }

        /// <summary>
        /// Determine if the service contains any data.
        /// </summary>
        public bool HasData
        {
            get
            {
                return _DataContext.HasData;
            }
        }
    }
}