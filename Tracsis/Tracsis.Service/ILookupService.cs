namespace Tracsis.Service
{
    public interface ILookupService
    {
        void Initialise(string fileName);
        string Lookup(string locationCode);

        bool HasData { get; }
    }
}