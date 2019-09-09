using Degreed.Library.Models;
using System;

namespace Degreed.Web.Controllers
{
    public static class JokeExtensions
    {
        public static string GetEmphatizedBody(this DegreedJoke joke, string term, string formatContext)
            => joke.Body.Replace(term, string.Format(formatContext, term), StringComparison.InvariantCultureIgnoreCase);

    }
}
