using Degree.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Degree.Web.Controllers
{
    public static class JokeExtensions
    {
        public static string GetEmphatizedBody(this DegreeJoke joke, string term, string formatContext)
            => joke.Body.Replace(term, string.Format(formatContext, term));

    }
}
