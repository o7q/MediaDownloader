using System;
using System.Linq;

namespace MediaDownloader.Tools
{
    public static class Text
    {
        public static string omitCharacter(string input)
        {
            string[] invalidChars = { "0x7f" };
            for (int i = 0; i < invalidChars.Length; i++)
            {
                char badChar = (char)Convert.ToUInt32(invalidChars[i], 16);
                if (input.Contains(badChar))
                    input = input.Replace(badChar.ToString(), "");
            }

            return input;
        }

        public static string repeatString(string inputString, int amount)
        {
            string output = "";
            for (int i = 0; i <= amount; i++)
                output += inputString;
            return output;
        }
    }
}