using System;
using System.Text;

namespace HeroesONE_R.Utilities
{
    public static unsafe class StringUtilities
    {
        /// <summary>
        /// Converts a fixed array of null terminated chars into a string instance.
        /// </summary>
        /// <param name="fileName">Pointer to the filename to be deciphered and returned.</param>
        /// <returns></returns>
        public static string CharPointerToString(byte* fileName)
        {
            // Calculate length before first null terminator.
            int fileNameLength = 0;
            while (true)
            {
                if (fileName[fileNameLength] == 0) { break; }
                fileNameLength += 1;
            }

            // Assign name.
            return Encoding.ASCII.GetString(fileName, fileNameLength);
        }

        /// <summary>
        /// Writes a string to a specified char pointer in ASCII format.
        /// </summary>
        /// <param name="text">The text to write to the pointer.</param>
        /// <param name="pointer">The pointer to write to.</param>
        /// <param name="bufferLength">Size in bytes of the buffer behind the pointer (and null terminator).</param>
        /// <exception cref="ArgumentException">The text does not fit in the buffer.</exception>
        public static void StringToCharPointer(string text, byte* pointer, int bufferLength)
        {
            // Get the name as ASCII bytes.
            byte[] asciiText = Encoding.ASCII.GetBytes(text);

            if (asciiText.Length >= bufferLength) {
                throw new ArgumentException($"\"{text}\" too long. Max size is {bufferLength - 1} characters.");
            }

            // Copy them over to structure.
            for (int x = 0; x < asciiText.Length; x++)
            {
                pointer[x] = asciiText[x];
            }
        }
    }
}
