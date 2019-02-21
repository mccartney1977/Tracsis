using System.Collections.Generic;

namespace Tracsis.Service
{
    public interface IOutputService
    {
        void WriteFile(IEnumerable<string> locationCodes, ILookupService lookupService, string outputFilePath);
        bool IsSuccess { get; }
        bool HasWarning { get; set; }
        bool CannotWriteFile { get; set; }
        string Warning { get; set; }
    }
}