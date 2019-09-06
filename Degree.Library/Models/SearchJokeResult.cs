using System;
using System.Collections.Generic;

namespace Degree.Library.Models
{
    [Serializable]
    public class SearchJokeResult
    {
        public string SearchTerm { get; set; }

        public List<DegreeJoke> Jokes { get; private set; } = new List<DegreeJoke>();

        public int PageSize { get; set; }

        public int TotalPages { get; set; }

        public int TotalJokes { get; set; }
    }
}