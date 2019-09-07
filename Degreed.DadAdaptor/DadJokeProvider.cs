using Degreed.Library.Models;
using Degreed.Library.Services;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Degreed.DadAdaptor
{
    public class DadJokeProvider : IJokeProvider
    {
        public DadJokeProvider()
        {
        }

        public async Task<DegreeJoke> GetRandomJoke()
        {
            var response = await GetClient().GetAsync(string.Empty);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            if (!string.IsNullOrWhiteSpace(data))
            {
                var joke = JsonConvert.DeserializeObject<DadJoke>(data);
                if (joke != null)
                    return (DegreeJoke)joke;
            }
            return DegreeJoke.Empty;
        }

        public async Task<SearchJokeResult> SearchJokes(string term, int page = 1, int pageSize = 10)
        {
            pageSize = Math.Max(1, Math.Min(pageSize, 30));
            page = Math.Max(1, page);

            var response = await GetClient().GetAsync(GetRequestUri(term, page, pageSize));
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            if (!string.IsNullOrWhiteSpace(data))
            {
                var clientResult = JsonConvert.DeserializeObject<DadJokeSearchResult>(data);
                if (clientResult != null)
                {
                    var result = new SearchJokeResult { PageSize = clientResult.Limit, SearchTerm = term, TotalJokes = clientResult.TotalJokes, TotalPages = clientResult.TotalPages };
                    if (clientResult.Jokes?.Count > 0)
                        clientResult.Jokes.ForEach(j => result.Jokes.Add((DegreeJoke)j));
                    return result;
                }
            }
            return new SearchJokeResult { SearchTerm = term, PageSize = pageSize };
        }

        private Uri GetRequestUri(string term, int page = 1, int pageSize = 10)
        {
            var parameters = HttpUtility.ParseQueryString(string.Empty);
            parameters[DadAdaptorSettings.SEARCH_JOKES_PARAM_LIMIT] = pageSize.ToString();
            parameters[DadAdaptorSettings.SEARCH_JOKES_PARAM_PAGE] = page.ToString();
            parameters[DadAdaptorSettings.SEARCH_JOKES_PARAM_TERM] = HttpUtility.UrlEncode(term);

            var builder = new UriBuilder(SettingsReader.Current.BaseUrl);
            builder.Path = DadAdaptorSettings.PATH_SEARCH_JOKES;
            builder.Query = parameters.ToString();
            return builder.Uri;
        }

        private HttpClient GetClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(SettingsReader.Current.BaseUrl);
            client.Timeout = SettingsReader.Current.Timeout;
            client.DefaultRequestHeaders.Add(DadAdaptorSettings.HEADER_ACCEPT, DadAdaptorSettings.HEADER_ACCEPT_VALUE);
            client.DefaultRequestHeaders.Add(DadAdaptorSettings.HEADER_USER_AGENT, SettingsReader.Current.UserAgent);
            return client;
        }
    }
}