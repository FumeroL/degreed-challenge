using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Degree.Library.Models
{
    [DataContract]
    public class SearchJokeResult
    {
        [DataMember]
        public string SearchTerm { get; set; }

        [DataMember]
        public List<DegreeJoke> Jokes { get; private set; } = new List<DegreeJoke>();

        [DataMember]
        public int PageSize { get; set; }

        [DataMember]
        public int TotalPages { get; set; }

        [DataMember]
        public int TotalJokes { get; set; }
    }
}