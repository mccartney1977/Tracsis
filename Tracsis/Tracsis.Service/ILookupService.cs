using System;

namespace Tracsis.Service
{
    public interface ILookupService
    {
        bool IsValid { get; set; }
        void Initialise(string fileName);
    }
}
