using System;
using System.IO;
using System.IO.Compression;
using System.Text;

using MediaDownloader.Forms.CustomMessageBox;

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

        public static byte[] CompressString(string inputString)
        {
            try
            {
                byte[] sourceFileBytes = Encoding.UTF8.GetBytes(inputString);

                using (MemoryStream compressedMemoryStream = new MemoryStream())
                {
                    using (GZipStream compressionStream = new GZipStream(compressedMemoryStream, CompressionMode.Compress))
                    {
                        compressionStream.Write(sourceFileBytes, 0, sourceFileBytes.Length);
                    }

                    byte[] compressedData = compressedMemoryStream.ToArray();

                    return compressedData;
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox customMessageBox = new CustomMessageBox("Unable to compress string!\n\nFull Error:\n" + ex, "OK", true);
                customMessageBox.ShowDialog();
                return Encoding.UTF8.GetBytes("");
            }
        }

        public static string DecompressString(byte[] compressedString)
        {
            try
            {
                using (MemoryStream compressedMemoryStream = new MemoryStream(compressedString))
                {
                    using (MemoryStream decompressedMemoryStream = new MemoryStream())
                    {
                        using (GZipStream decompressionStream = new GZipStream(compressedMemoryStream, CompressionMode.Decompress))
                        {
                            decompressionStream.CopyTo(decompressedMemoryStream);
                        }

                        byte[] decompressedBytes = decompressedMemoryStream.ToArray();
                        return Encoding.UTF8.GetString(decompressedBytes);
                    }
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox customMessageBox = new CustomMessageBox("Unable read decompressed string!\n\nFull Error:\n" + ex, "OK", true);
                customMessageBox.ShowDialog();
                return "";
            }
        }
    }
}