using Degree.Library.Models;
using System;
using System.Runtime.Serialization;

namespace Degree.DadAdaptor
{
    [DataContract]
    internal class DadJoke
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string Joke { get; set; }

        public static explicit operator DegreeJoke(DadJoke d)
            => new DegreeJoke { Body = d.Joke, Id = d.Id, TypeBySize = JokeSize.Short };
    }
}