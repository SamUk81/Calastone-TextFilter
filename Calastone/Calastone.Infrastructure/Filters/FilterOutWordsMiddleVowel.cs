using Calastone.Application.Contracts;
using Calastone.Application.Enums;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Calastone.Infrastructure.Filters
{
    public class FilterOutWordsMiddleVowel : IFilter
    {
        public string FilterOutWords(string text)
        {
            var outputText = text;

            // Ensure no empty strings otherwise it can mess up the count!
            var words = Regex.Split(text, @"\W").Where(str => !string.IsNullOrEmpty(str)); 

            foreach (string word in words)
            {
                var vowels = "AaEeIiOoUu";

                int middleCharIndex = word.Length / 2;                

                // Check if any of the middle characters is a vowel
                var foundVowelChar = vowels.Contains(word[middleCharIndex]);

                // Check if word contains even number of characters
                if (word.Length % 2 == 0)
                {
                    // Then get the middle 2 characters 
                    int middleTwoCharIndex = middleCharIndex - 1;
                    // Check if middle two characters contains any vowels 
                    foundVowelChar |= vowels.Contains(word[middleTwoCharIndex]);
                }

                // If we have vowel in middle of a word then delete it 
                if (foundVowelChar)
                {
                    // \b - word boundary, so it matches "in" in " in;" but not "in" in "beginning"
                    var regex = "\\b" + word + "\\b";
                    outputText = Regex.Replace(outputText, regex, "");
                }
            }

            return outputText;
        }

        public bool WhichFilterToHandle(string filterName)
        {
            return filterName.Contains(Enum.GetNames(typeof(EnumFilters))[0], StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
