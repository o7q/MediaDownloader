using System;
using System.Text;

namespace MediaDownloader.Tools
{
    public static class Strings
    {
        public static string EncodeString(string plainText)
        {
            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainBytes);
        }

        public static string DecodeString(string encryptedText)
        {
            byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
            return Encoding.UTF8.GetString(encryptedBytes);
        }
    }
}