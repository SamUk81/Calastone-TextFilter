namespace Calastone.Application.Contracts
{
    public interface IFilter
    {
        /// <summary>
        /// Filter out words
        /// </summary>
        /// <param name="word"></param>
        /// <returns>Return list of words that don't have vowels in middle</returns>
        string FilterOutWords(string text);
        
        /// <summary>
        /// Checks if the factory filter can handle the input
        /// </summary>
        /// <param name="filterName"></param>
        /// <returns></returns>
        bool WhichFilterToHandle(string filterName);
    }
}
