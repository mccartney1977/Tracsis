namespace TracsisData.Entity
{
    /// <summary>
    /// Entity to store key/value pair for a lookup dictionary item.
    /// </summary>
    public class LookupEntity
    {
        public string Index { get; set; }
        public string Value { get; set; }

        public LookupEntity(string dataRow)
        {
            // Verify string is not empty.
            // And contains the tab separator.
            if (!string.IsNullOrEmpty(dataRow) && dataRow.Contains('\t'))
            {
                var pair = dataRow.Split('\t');
                Index = pair[0];
                Value = pair[1];
            }
        }

        // Derived properties.
        // Both Index and Value must contain a valid string.
        public bool IsValid
        {
            get
            {
                return !(string.IsNullOrEmpty(Index)) && !(string.IsNullOrEmpty(Value));
            }
        }
    }
}