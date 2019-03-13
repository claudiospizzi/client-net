using System;
using System.Net.Http;

namespace ReportPortal.Client.Api
{
    public abstract class BaseApiClient
    {
        protected HttpClient HttpClient { get; }

        protected Uri BaseUri { get; }

        protected string Project { get; }

        protected BaseApiClient(HttpClient httpClient, Uri baseUri, string project)
        {
            HttpClient = httpClient;
            BaseUri = baseUri;
            Project = project;
        }
    }
}
