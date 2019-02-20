using System.Collections.Generic;

namespace Tracsis.Service
{
    /// <summary>
    /// Service to handle code inputs from a text file.
    /// </summary>
    public interface IInputService
    {
        void SetLocationCodes(string filePath);

        IEnumerable<string> GetLocationCodes();

        bool HasCodes { get; }
    }
}