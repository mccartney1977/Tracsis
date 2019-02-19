using System;
using System.Collections.Generic;

namespace Tracsis.Service
{
    /// <summary>
    /// Concrete class to initialise the lookup service from a text file input.
    /// </summary>
    public class LookupFromFile : ILookupService
    {
        private Dictionary<string, string> _Data { get; set; }

        public bool IsValid { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        
        public LookupFromFile()
        {
            _Data = new Dictionary<string, string>();
        }

        /// <summary>
        /// Initialise the data from a valid text file.
        /// </summary>
        /// <param name="fileName"></param>
        public void Initialise(string fileName)
        {
            throw new NotImplementedException();
        }
    }
}