using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Degreed.DadAdaptor
{
    internal class DadAdaptorSettings
    {
        public string BaseUrl { get; set; }

        public TimeSpan Timeout { get; set; }

        public string UserAgent { get; set; }

        public const string HEADER_ACCEPT_VALUE = "application/json";
        public const string HEADER_ACCEPT = "Accept";
        public const string HEADER_USER_AGENT = "User-Agent";
        public const string PATH_SEARCH_JOKES = "search";
        public const string SEARCH_JOKES_PARAM_PAGE = "page";
        public const string SEARCH_JOKES_PARAM_LIMIT = "limit";
        public const string SEARCH_JOKES_PARAM_TERM = "term";
    }

    internal static class SettingsReader
    {
        public static DadAdaptorSettings Current
        {
            get
            {
                if (settings == null)
                    lock (syncObject)
                    {
                        if (settings == null)
                            settings = ReadSettings();
                    }
                return settings;
            }
        }

        private const string SETTING_BASE_URL = "AppSettings:DadBaseUrl";
        private const string SETTING_TIMEOUT = "AppSettings:SecondsTimeOut";
        private const string SETTING_USER_AGENT = "AppSettings:UserAgent";

        private static DadAdaptorSettings settings;
        private static readonly object syncObject = new object();

        private static DadAdaptorSettings ReadSettings()
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));

            var root = builder.Build();

            var baseUrl = root.GetValue(SETTING_BASE_URL, string.Empty);
            if (string.IsNullOrWhiteSpace(baseUrl))
                throw new SystemException($"{SETTING_BASE_URL} was not indicated in configuration file");

            return new DadAdaptorSettings
            {
                BaseUrl = baseUrl,
                Timeout = new TimeSpan(0, 0, root.GetValue(SETTING_TIMEOUT, 5)),
                UserAgent = root.GetValue(SETTING_USER_AGENT, string.Empty)
            };
        }
    }
}