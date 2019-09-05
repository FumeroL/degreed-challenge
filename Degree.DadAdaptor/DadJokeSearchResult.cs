using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Degree.DadAdaptor
{
    [DataContract]
    internal class DadJokeSearchResult
    {
        [DataMember(Name = "current_page")]
        public int CurrentPage { get; set; }

        [DataMember(Name = "limit")]
        public int Limit { get; set; }

        [DataMember(Name = "next_page")]
        public int NextPage { get; set; }

        [DataMember(Name = "previous_page")]
        public int PreviousPage { get; set; }

        [DataMember(Name = "results")]
        [XmlArrayItem(typeof(DadJoke))]
        public List<DadJoke> Jokes { get; set; }

        [DataMember(Name = "search_term")]
        public string SearchTerm { get; set; }

        [DataMember(Name = "status")]
        public int ResponseStatus { get; set; }

        [DataMember(Name = "total_jokes")]
        public int TotalJokes { get; set; }

        [DataMember(Name = "total_pages")]
        public int TotalPages { get; set; }
    }
}