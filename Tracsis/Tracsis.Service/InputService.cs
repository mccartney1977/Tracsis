using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tracsis.Service
{
    /// <summary>
    /// Service to read input codes from a text file.
    /// </summary>
    public class InputService : IInputService
    {
        private List<string> _InputCodes { get; set; }

        public InputService()
        {
            _InputCodes = new List<string>();
        }

        /// <summary>
        /// Read the inout file and place all codes into a list.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public IEnumerable<string> GetInputCodes(string filePath)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// If the list contains any data return true.
        /// </summary>
        public bool HasCodes
        {
            get
            {
                return _InputCodes.Count() > 0;
            }
        }
    }
}
