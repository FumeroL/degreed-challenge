using Degree.Library.Models;
using Degree.Library.Services;
using System;

namespace Degree.Logic
{
    public class JokeEngine
    {
        private static readonly char[] delimiters = new char[] { ' ', '\r', '\n' };

        public JokeEngine(IJokeProvider provider) => this.provider = provider;

        private readonly IJokeProvider provider;

        /// <summary>
        /// Returns single random joke
        /// </summary>
        /// <returns>joke</returns>
        public DegreeJoke GetNextJoke()
            => provider.GetRandomJoke().Result;

        /// <summary>
        /// Searchs for jokes matching a given text
        /// </summary>
        /// <param name="term">search text to use</param>
        /// <returns>found pages</returns>
        public SearchJokeResult SearchJokes(string term)
            => SearchJokes(term, 1, 20);

        /// <summary>
        /// Searchs for jokes matching a given text specifying page and page size to use
        /// </summary>
        /// <param name="term">search text to use</param>
        /// <param name="page">desired page</param>
        /// <param name="pageSize">amount of jokes per page</param>
        /// <returns>found pages</returns>
        public SearchJokeResult SearchJokes(string term, int page = 1, int pageSize = 10)
        {
            var result = provider.SearchJokes(term, page, pageSize).Result;
            result.SearchTerm = term; // not relying in future adaptor implementations
            if (result.Jokes?.Count > 0)
                result.Jokes.ForEach(j => CalculateJokeSize(j));
            return result;
        }

        private void CalculateJokeSize(DegreeJoke joke)
        {
            joke.TypeBySize = JokeSize.Short; // by default
            if (!string.IsNullOrWhiteSpace(joke.Body))
            {
                var words = joke.Body.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Length;
                joke.TypeBySize = (words < 11)
                    ? JokeSize.Short
                    : (words > 10 && words < 20)
                        ? JokeSize.Medium
                        : JokeSize.Long;
            }
        }
    }
}