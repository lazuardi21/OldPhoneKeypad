using System;
using System.Collections.Generic;
using System.Text;

namespace IronSoftware.Challenge
{
    public static class OldPhoneKeypad
    {
        private static readonly Dictionary<char, string> KeypadMapping = new Dictionary<char, string>
        {
            {'0', " "},
            {'1', "&'("},
            {'2', "ABC"},
            {'3', "DEF"},
            {'4', "GHI"},
            {'5', "JKL"},
            {'6', "MNO"},
            {'7', "PQRS"},
            {'8', "TUV"},
            {'9', "WXYZ"}
        };

        public static string OldPhonePad(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            if (!input.EndsWith("#"))
            {
                Console.WriteLine("Input must end with '#'.");
                return null;
            }

            var output = new StringBuilder();
            var groups = new List<(char key, int count)>();
            char lastKey = '\0';
            int count = 0;
            int i = 0;

            while (i < input.Length)
            {
                char currentChar = input[i];

                if (currentChar == '#')
                {
                    if (count > 0)
                        groups.Add((lastKey, count));
                    break;
                }
                else if (currentChar == '*')
                {
                    if (count > 0)
                    {
                        count = 0;
                        lastKey = '\0';
                    }
                    else if (groups.Count > 0)
                    {
                        groups.RemoveAt(groups.Count - 1);
                    }
                }
                else if (currentChar == ' ')
                {
                    if (count > 0)
                    {
                        groups.Add((lastKey, count));
                        count = 0;
                        lastKey = '\0';
                    }
                }
                else if (KeypadMapping.ContainsKey(currentChar))
                {
                    if (lastKey == currentChar)
                    {
                        count++;
                    }
                    else
                    {
                        if (count > 0)
                        {
                            groups.Add((lastKey, count));
                        }
                        lastKey = currentChar;
                        count = 1;
                    }
                }

                i++;
            }

            foreach (var (key, cnt) in groups)
            {
                if (KeypadMapping.ContainsKey(key))
                {
                    var chars = KeypadMapping[key];
                    int idx = (cnt - 1) % chars.Length;
                    output.Append(chars[idx]);
                }
            }

            return output.ToString();
        }
    }
}
