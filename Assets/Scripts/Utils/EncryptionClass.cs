using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    class EncryptionClass
    {
        public static string Encode(string inputText)
        {
            byte[] bytesToEncode = Encoding.UTF8.GetBytes(inputText);

            return Convert.ToBase64String(bytesToEncode);
        }

        public static string Decode(string encodedText)
        {
            byte[] decodedBytes = Convert.FromBase64String(encodedText);
            string decodedText = Encoding.UTF8.GetString(decodedBytes);

            return decodedText;
        }
    }
}
