using System.Collections.Generic;

namespace Tracsis.Service
{
    /// <summary>
    /// Service to handle code inputs from a text file.
    /// </summary>
    public interface IInputService
    {
        IEnumerable<string> GetInputCodes(string filePath);
        bool HasCodes { get; }
    }
}