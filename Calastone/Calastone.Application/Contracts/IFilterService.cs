namespace Calastone.Application.Contracts
{
    public interface IFilterService
    {
        string FilterOutWordsContainsVowelsInMiddle(string text);
        string FilterOutWordsLengthLessThanThree(string text);
        string FilterOutWordsContainsLetterT(string text);
    }
}
