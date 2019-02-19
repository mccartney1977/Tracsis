﻿using System.Collections.Generic;
using System.IO;
using TracsisData.Entity;

namespace TracsisData
{
    public class DataContext
    {
        // Dictionary object to store all look key/value data.
        private Dictionary<string, string> _LookupData { get; set; }
        private string _FileName { get; set; }

        public DataContext(string fileName)
        {
            // Initialise a new instance of data.
            _LookupData = new Dictionary<string, string>();
            _FileName = fileName;
        }

        /// <summary>
        /// Check the file exists and that is of the correct file type.
        /// </summary>
        private bool IsValidFile
        {
            get
            {
                bool isValid = true;

                if (File.Exists(_FileName))
                {
                    isValid = true;
                }

                return isValid;
            }
        }

        /// <summary>
        /// Read the file data.
        /// </summary>
        /// <param name="fileName"></param>
        public void SetData(string fileName)
        {
            // When lookup file is valid.
            if (IsValidFile)
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
    }
}