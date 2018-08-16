using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Tao.DevIl;
using Tao.OpenGl;

namespace HelloTriangle
{
    public class FontParser
    {
        static int HeaderSize = 4;

        //Gets the value after an equal sign and converts it
        //from string to integer
        private static int GetValue(string s)
        {
            string value = s.Substring(s.IndexOf("=") + 1);
            return int.Parse(value);
        }

        public static Dictionary<char, CharacterData> Parse(string filePath)
        {
            Dictionary<char, CharacterData> charDictionary =
                new Dictionary<char,CharacterData>();
            string[] lines = File.ReadAllLines(filePath);
            for (int i = HeaderSize; i < lines.Length; i+=1)
            {
                string firstLine = lines[i];
                string[] typesAndValues = firstLine.Split(" ".ToCharArray(), 
                    StringSplitOptions.RemoveEmptyEntries);
                
                //Data comes back in specific order to shorten parser
                CharacterData charData = new CharacterData
                {
                    Id = GetValue(typesAndValues[1]),
                    X = GetValue(typesAndValues[2]),
                    Y = GetValue(typesAndValues[3]),
                    Width = GetValue(typesAndValues[4]),
                    Height = GetValue(typesAndValues[5]),
                    XOffset = GetValue(typesAndValues[6]),
                    YOffset = GetValue(typesAndValues[7]),
                    XAdvance = GetValue(typesAndValues[8])
                };
                charDictionary.Add((char)charData.Id, charData);
            }
            return charDictionary;
 
        }
    }
}
