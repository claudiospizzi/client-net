using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ReportPortal.Client.Api.Log.Model;
using ReportPortal.Client.Api.Log.Request;
using ReportPortal.Client.Common.Model;
using ReportPortal.Client.Common.Model.Filtering;
using ReportPortal.Client.Common.Model.Paging;
using ReportPortal.Client.Converter;
using ReportPortal.Client.Extension;

namespace ReportPortal.Client.Api.Log
{
    public class LogApiClient : BaseApiClient, ILogApiClient
    {
        public LogApiClient(HttpClient httpClient, Uri baseUri, string project) : base(httpClient, baseUri, project)
        {
        }

        /// <summary>
        /// Returns a list of log items for specified test item.
        /// </summary>
        /// <param name="queryFilter">Specified criteria for retrieving log items.</param>
        /// <returns>A list of log items.</returns>
        public async Task<PagingContent<LogItem>> GetLogItemsAsync(QueryFilter queryFilter = null)
        {
            var uri = BaseUri.Append($"{Project}/log");

            if (queryFilter != null)
            {
                uri = uri.Append($"?{queryFilter.ToQueryString()}");
            }

            var response = await HttpClient.GetAsync(uri).ConfigureAwait(false);
            response.VerifySuccessStatusCode();
            return ModelSerializer.Deserialize<PagingContent<LogItem>>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        /// <summary>
        /// Returns specified log item by ID.
        /// </summary>
        /// <param name="id">ID of the log item to retrieve.</param>
        /// <returns>A representation of log item/</returns>
        public async Task<LogItem> GetLogItemAsync(string id)
        {
            var uri = BaseUri.Append($"{Project}/log/{id}");
            var response = await HttpClient.GetAsync(uri).ConfigureAwait(false);
            response.VerifySuccessStatusCode();
            return ModelSerializer.Deserialize<LogItem>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        /// <summary>
        /// Returns binary data of attached file to log message.
        /// </summary>
        /// <param name="id">ID of data.</param>
        /// <returns>Array of bytes.</returns>
        public async Task<byte[]> GetBinaryDataAsync(string id)
        {
            var uri = BaseUri.Append($"{Project}/data/{id}");
            var response = await HttpClient.GetAsync(uri).ConfigureAwait(false);
            response.VerifySuccessStatusCode();
            return await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Creates a new log item.
        /// </summary>
        /// <param name="model">Information about representation of log item.</param>
        /// <returns>Representation of just created log item.</returns>
        public async Task<LogItem> AddLogItemAsync(AddLogItemRequest model)
        {
            var uri = BaseUri.Append($"{Project}/log");

            if (model.Attach == null)
            {
                var body = ModelSerializer.Serialize<AddLogItemRequest>(model);
                var response = await HttpClient.PostAsync(uri, new StringContent(body, Encoding.UTF8, "application/json")).ConfigureAwait(false);
                response.VerifySuccessStatusCode();
                return ModelSerializer.Deserialize<LogItem>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            }
            else
            {
                var body = ModelSerializer.Serialize<List<AddLogItemRequest>>(new List<AddLogItemRequest> { model });
                var multipartContent = new MultipartFormDataContent();

                var jsonContent = new StringContent(body, Encoding.UTF8, "application/json");
                multipartContent.Add(jsonContent, "json_request_part");

                var byteArrayContent = new ByteArrayContent(model.Attach.Data.ToArray(), 0, model.Attach.Data.Count);
                byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue(model.Attach.MimeType);
                multipartContent.Add(byteArrayContent, "file", model.Attach.Name);

                var response = await HttpClient.PostAsync(uri, multipartContent).ConfigureAwait(false);
                response.VerifySuccessStatusCode();
                var c = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                return ModelSerializer.Deserialize<Responses>(c).LogItems[0];
            }
        }

        /// <summary>
        /// Deletes specified log item.
        /// </summary>
        /// <param name="id">ID of the log item to delete.</param>
        /// <returns>A message from service.</returns>
        public async Task<Message> DeleteLogItemAsync(string id)
        {
            var uri = BaseUri.Append($"{Project}/log/{id}");
            var response = await HttpClient.DeleteAsync(uri).ConfigureAwait(false);
            response.VerifySuccessStatusCode();
            return ModelSerializer.Deserialize<Message>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }
    }
}
