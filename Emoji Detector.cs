using System;
using System.Text.RegularExpressions;

namespace _14._Emoji_Detector
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string digit = @"\d";

            MatchCollection digits = Regex.Matches(text, digit);

            long coolThreshold = 1;

            foreach (Match match in digits)
            {
                coolThreshold *= long.Parse(match.Value);
            }

            string pattern = @"(::|\*\*)(?<emoji>[A-Z][a-z]{2,})\1";

            MatchCollection emojis = Regex.Matches(text, pattern);

            Console.WriteLine($"Cool threshold: {coolThreshold}");
            Console.WriteLine($"{emojis.Count} emojis found in the text. The cool ones are:");

            int asciiSumOfLetters = 0;

            foreach (Match emoji in emojis)
            {
                asciiSumOfLetters = 0;

                for (int i = 0; i < emoji.Groups["emoji"].Value.Length; i++)
                {
                    asciiSumOfLetters += (int)emoji.Groups["emoji"].Value[i];
                }
                
                if (asciiSumOfLetters > coolThreshold)
                {
                    Console.WriteLine(emoji);
                }
            }   
        }
    }
}
