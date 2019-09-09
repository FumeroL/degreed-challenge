using System;
using System.Collections.Generic;

namespace Degreed.Library.Models
{
    [Serializable]
    public class SearchJokeResult
    {
        public string SearchTerm { get; set; }

        public List<DegreedJoke> Jokes { get; private set; } = new List<DegreedJoke>();

        public int PageSize { get; set; }

        public int TotalPages { get; set; }

        public int TotalJokes { get; set; }
    }
}