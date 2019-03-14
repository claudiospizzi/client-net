using ReportPortal.Client.Converter;
using ReportPortal.Client.Extension;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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

        protected async Task<TResponseBody> SendAsync<TResponseBody, TRequestBody>(HttpMethod httpMethod, Uri requestUri, TRequestBody requestBody)
        {
            var requestMessage = new HttpRequestMessage(httpMethod, requestUri);

            if (requestBody != null)
            {
                var requestContent = ModelSerializer.Serialize<TRequestBody>(requestBody);

                requestMessage.Content = new StringContent(requestContent, Encoding.UTF8, "application/json");
            }

            var response = await HttpClient.SendAsync(requestMessage).ConfigureAwait(false);
            response.VerifySuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return ModelSerializer.Deserialize<TResponseBody>(responseBody);
        }
    }
}
