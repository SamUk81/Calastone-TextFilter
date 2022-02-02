using Calastone.Application.Contracts;
using Calastone.Application.Enums;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Calastone.Infrastructure.Filters
{
    public class FilterOutWordsWithLetterT : IFilter
    {
        public string FilterOutWords(string text)
        {
            var outputText = text;

            // Split the words based on whitespace. Ensure no empty strings otherwise it will mess up the count
            var words = Regex.Split(text, @"\W").Where(str => !string.IsNullOrEmpty(str)); 

            foreach (string word in words)
            {
                if (word.Contains("t"))
                {
                    // \b - word boundary, so it matches "in" in " in;" but not "in" in "beginning"
                    var regex = "\\b" + word + "\\b";
                    outputText = Regex.Replace(outputText, regex, string.Empty);
                }
            }

            return outputText;
        }

        public bool WhichFilterToHandle(string filterName)
        {
            return filterName.Contains(Enum.GetNames(typeof(EnumFilters))[2], StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
