using System.Net.Http;

namespace ReportPortal.Client.Api
{
    public abstract class BaseApiClient : IApiClient
    {
        protected HttpClient HttpClient { get; }
        protected string Project { get; }

        protected BaseApiClient(HttpClient httpClient, string project)
        {
            HttpClient = httpClient;
            Project = project;
        }
    }
}
