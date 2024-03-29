﻿using Degreed.Library.Models;
using System.Runtime.Serialization;

namespace Degreed.DadAdaptor
{
    [DataContract]
    internal class DadJoke
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string Joke { get; set; }

        public static explicit operator DegreedJoke(DadJoke d)
            => new DegreedJoke { Body = d.Joke, Id = d.Id, TypeBySize = JokeSize.Short };
    }
}