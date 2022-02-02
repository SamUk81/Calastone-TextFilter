namespace Calastone.Application.Contracts
{
    public interface IFilterFactory
    {
        /// <summary>
        /// Creates at run time the right filter to be injected to the service
        /// </summary>
        /// <param name="filterName"></param>
        /// <returns></returns>
        IFilter Create(string filterName);
    }
}
