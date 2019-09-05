using Degree.DadAdaptor;
using Degree.Library.Models;
using Degree.Logic;
using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Tests
{
    public class JokeEngine_RandomJoke
    {
        [SetUp]
        public void Setup()
        {
            engine = new JokeEngine(new DadClient());
        }

        private JokeEngine engine;

        [Test]
        public void GetRandomJoke()
        {
            var joke = engine.GetNextJoke();
            if (joke.IsEmpty)
                Assert.Fail("a valid Joke was not returned. Empty one was returned instead");
            else
                Assert.Pass($"Joke {joke.Id} was returned");
        }

        [Test]
        public void GetRandomJokes()
        {
            var jokes = new List<DegreeJoke>();
            for (int i = 0; i < 100; i++)
            {
                var joke = engine.GetNextJoke();
                Console.WriteLine($"Got joke '{joke.Id}': '{joke.Body}'");
                jokes.Add(joke);
            }
            if (jokes.Any(j => j.IsEmpty))
                Assert.Fail("Some empty jokes were returned");
            else
                Assert.Pass("OK");
        }
    }
}