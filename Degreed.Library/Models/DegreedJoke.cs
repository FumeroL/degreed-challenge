using System;

namespace Degreed.Library.Models
{
    public enum JokeSize
    {
        Short,
        Medium,
        Long
    }

    [Serializable]
    public class DegreedJoke
    {
        /// <summary>
        /// Represents an empty Joke
        /// </summary>
        public readonly static DegreedJoke Empty = new DegreedJoke { Id = string.Empty, Body = string.Empty };

        public string Id { get; set; }

        public string Body { get; set; }

        public JokeSize TypeBySize { get; set; } = JokeSize.Short;

        /// <summary>
        /// Indicates if current instance refers to <see cref="DegreedJoke.Empty"/>
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty
        {
            get => Equals(this, Empty) || string.IsNullOrWhiteSpace(Id);
        }
    }
}