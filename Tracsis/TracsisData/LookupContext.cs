using System.Collections.Generic;
using System.IO;
using TracsisData.Entity;

namespace TracsisData
{
    public class LookupContext: IDataContext
    {
        // Dictionary object to store all look key/value data.
        private Dictionary<string, string> _LookupData { get; set; }

        public LookupContext()
        {
            // Initialise a new instance of data.
            _LookupData = new Dictionary<string, string>();
        }

        /// <summary>
        /// Check the file exists and that is of the correct file type.
        /// </summary>
        private bool IsValidFile(string fileName)
        {
            bool isValid = true;

            if (File.Exists(fileName))
            {
                isValid = true;
            }

            return isValid;
        }

        /// <summary>
        /// Read the file data.
        /// </summary>
        /// <param name="fileName"></param>
        public void SetData(string fileName)
        {
            // When lookup file is valid.
            if (IsValidFile(fileName))
            {
                // Open the file steam and read each data line.
                using (var streamReader = File.OpenText(fileName))
                {
                    var dataRow = "";
                    while (!string.IsNullOrEmpty(dataRow = streamReader.ReadLine()))
                    {
                        var lookupEntity = new LookupEntity(dataRow);

                        if (lookupEntity.IsValid)
                        {
                            _LookupData.Add(lookupEntity.Index, lookupEntity.Value);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Return all the lookup data that was read from the file.
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetData()
        {
            return _LookupData;
        }

        // Derived properties.
        // Verify the service contains data.
        public bool HasData
        {
            get
            {
                return _LookupData != null && _LookupData.Count > 0;
            }
        }
    }
}