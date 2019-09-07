using Degreed.Library.Models;
using System.Threading.Tasks;

namespace Degreed.Library.Services
{
    public interface IJokeProvider
    {
        /// <summary>
        /// Returns single random joke
        /// </summary>
        /// <returns>joke</returns>
        Task<DegreeJoke> GetRandomJoke();

        /// <summary>
        /// Searchs for jokes matching a given text specifying page and page size to use
        /// </summary>
        /// <param name="term">search text to use</param>
        /// <param name="page">desired page</param>
        /// <param name="pageSize">amount of jokes per page</param>
        /// <returns>found pages</returns>
        Task<SearchJokeResult> SearchJokes(string term, int page = 1, int pageSize = 10);
    }
}