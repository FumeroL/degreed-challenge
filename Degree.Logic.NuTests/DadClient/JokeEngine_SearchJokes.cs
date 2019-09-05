using Degree.DadAdaptor;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Degree.Logic.NuTests
{
    class JokeEngine_SearchJokes
    {
        [SetUp]
        public void Setup()
        {
            engine = new JokeEngine(new DadClient());
        }

        private JokeEngine engine;

        [Test]
        public void SearchJokes()
        {
            var result = engine.SearchJokes("dad");
            Assert.IsNotNull(result);
            Assert.True(result?.SearchTerm == "dad", "Search Term is wrong");
            Assert.Greater(result.Jokes.Count, 0, "No jokes were found");
            Assert.Greater(result.TotalJokes, 0, "No jokes were found (from count)");
            Console.WriteLine(result);
        }

        [Test]
        public void SearchJokesPaginated()
        {
            var result = engine.SearchJokes("dad", 1, 5);
            Assert.IsNotNull(result);
            Assert.True(result?.SearchTerm == "dad", "Search Term is wrong");
            Assert.Greater(result.Jokes.Count, 0, "No jokes were found");
            Assert.Greater(result.TotalJokes, 0, "No jokes were found (from count)");
            Console.WriteLine(result);
        }
    }
}
