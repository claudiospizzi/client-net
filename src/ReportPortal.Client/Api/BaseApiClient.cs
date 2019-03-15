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

        protected async Task<TResponseContract> SendAsync<TResponseContract, TRequestContract>(HttpMethod httpMethod, Uri requestUri, TRequestContract requestContract)
        {
            var httpRequestMessage = new HttpRequestMessage(httpMethod, requestUri);

            if (requestContract != null)
            {
                var serializedRequestContent = ModelSerializer.Serialize<TRequestContract>(requestContract);

                httpRequestMessage.Content = new StringContent(serializedRequestContent, Encoding.UTF8, "application/json");
            }

            var httpResponseMessage = await HttpClient.SendAsync(httpRequestMessage).ConfigureAwait(false);
            httpResponseMessage.VerifySuccessStatusCode();

            var responseBody = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

            return ModelSerializer.Deserialize<TResponseContract>(responseBody);
        }

        protected async Task<TResponseContract> GetAsync<TResponseContract>(Uri requestUri)
        {
            return await SendAsync<TResponseContract, object>(HttpMethod.Get, requestUri, null).ConfigureAwait(false);
        }

        protected async Task<TResponseContract> DeleteAsync<TResponseContract>(Uri requestUri)
        {
            return await SendAsync<TResponseContract, object>(HttpMethod.Delete, requestUri, null).ConfigureAwait(false);
        }
    }
}
