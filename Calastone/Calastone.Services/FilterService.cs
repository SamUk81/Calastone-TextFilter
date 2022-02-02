using Calastone.Application.Contracts;
using Calastone.Application.Enums;
using System;

namespace Calastone.Services
{
    public class FilterService : IFilterService
    {
        private readonly IFilterFactory _filterFactory;

        public FilterService(IFilterFactory filterFactory)
        {
            _filterFactory = filterFactory;
        }        

        /// <summary>
        /// Filter 1 - Filter out words that contains a vowel in the middle of the word
        /// </summary>
        /// <param name="text"></param>
        /// <returns>Returns all words that don't have any vowels in the middle</returns>
        public string FilterOutWordsContainsVowelsInMiddle(string text)
        {
            var filteredOutputText = string.Empty;

            if (!string.IsNullOrWhiteSpace(text))
            {                
                var filter = _filterFactory.Create(Enum.GetNames(typeof(EnumFilters))[0]);

                if (filter != null)
                {
                    filteredOutputText = filter.FilterOutWords(text);
                }
            }

            return filteredOutputText;
        }

        /// <summary>
        /// Filter 2 - Filter out words that have length less than 3
        /// </summary>
        /// <param name="text"></param>
        /// <returns>Returns all words that greater than 3 character long</returns>
        public string FilterOutWordsLengthLessThanThree(string text)
        {
            var filteredOutputText = string.Empty;

            if (!string.IsNullOrWhiteSpace(text))
            {
                var filter = _filterFactory.Create(Enum.GetNames(typeof(EnumFilters))[1]);

                if (filter != null)
                {
                    filteredOutputText = filter.FilterOutWords(text);
                }
            }

            return filteredOutputText;
        }

        /// <summary>
        /// Filter 3 - Filter out words that contains the letter ‘t’
        /// </summary>
        /// <param name="text"></param>
        /// <returns>Returns list of words that don't have any vowels in the middle</returns>
        public string FilterOutWordsContainsLetterT(string text)
        {
            var filteredOutputText = string.Empty;

            if (!string.IsNullOrWhiteSpace(text))
            {
                var filter = _filterFactory.Create(Enum.GetNames(typeof(EnumFilters))[2]);

                if (filter != null)
                {
                    filteredOutputText = filter.FilterOutWords(text);
                }
            }

            return filteredOutputText;
        }
    }
}
