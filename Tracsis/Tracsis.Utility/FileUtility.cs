using System.IO;

namespace Tracsis.Utility
{
    public static class FileUtility
    {
        /// <summary>
        /// Check the file exists and is of the correct type.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool IsValidFile(string filePath)
        {
            var isValid = true;

            // When the file does not exist.
            if (!File.Exists(filePath))
            {
                isValid = false;
            }
            else if (!filePath.EndsWith(".txt"))
            {
                // Assume the file must be a txt file.
                // If not, then is not valid.
                isValid = false;
            }

            return isValid;
        }

        /// <summary>
        /// If the file is not of type txt, then return false.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool IsValidFileType(string fileName)
        {
            var isValid = true;

            if (!fileName.EndsWith(".txt"))
            {
                isValid = false;
            }

            return isValid;
        }
    }
}