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

        protected async Task<TResponseModel> SendAsync<TResponseModel, TRequestModel>(HttpMethod httpMethod, Uri requestUri, TRequestModel requestModel)
        {
            var httpRequestMessage = new HttpRequestMessage(httpMethod, requestUri);

            if (requestModel != null)
            {
                var requestContent = ModelSerializer.Serialize<TRequestModel>(requestModel);

                httpRequestMessage.Content = new StringContent(requestContent, Encoding.UTF8, "application/json");
            }

            var response = await HttpClient.SendAsync(httpRequestMessage).ConfigureAwait(false);
            response.VerifySuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return ModelSerializer.Deserialize<TResponseModel>(responseBody);
        }

        protected async Task<TResponseModel> GetAsync<TResponseModel>(Uri requestUri)
        {
            return await SendAsync<TResponseModel, object>(HttpMethod.Get, requestUri, null).ConfigureAwait(false);
        }

        protected async Task<TResponseModel> DeleteAsync<TResponseModel>(Uri requestUri)
        {
            return await SendAsync<TResponseModel, object>(HttpMethod.Delete, requestUri, null).ConfigureAwait(false);
        }
    }
}
