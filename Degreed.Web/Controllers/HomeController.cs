using Degreed.Library.Services;
using Degreed.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace Degreed.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(ICompositeViewEngine viewEngine, IJokeProvider provider)
        {
            this.provider = provider;
            this.viewEngine = viewEngine;
        }

        private readonly IJokeProvider provider;
        private readonly ICompositeViewEngine viewEngine;

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet()]
        public JsonResult GetRandonJoke()
            => Json(new JokeEngine(provider).GetNextJoke());

        [HttpGet()]
        public string SearchJokes(string term)
        {
            var jokes = new JokeEngine(provider).SearchJokes(term);
            return (jokes.TotalJokes == 0)
                ? string.Empty
                : this.RenderView(viewEngine, "_pvJokesSearchResult", jokes).Result;
        }
    }
}