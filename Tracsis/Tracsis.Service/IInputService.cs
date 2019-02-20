using System.Collections.Generic;

namespace Tracsis.Service
{
    public interface IInputService
    {
        IEnumerable<string> GetInputCodes(string filePath);
    }
}