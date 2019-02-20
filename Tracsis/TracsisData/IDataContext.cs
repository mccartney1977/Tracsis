using System.Collections.Generic;

namespace TracsisData
{
    // Data context interface to feed into the service layer.
    public interface IDataContext
    {
        void SetData(string fileName);
        Dictionary<string, string> GetData();
        bool HasData { get; }
    }
}