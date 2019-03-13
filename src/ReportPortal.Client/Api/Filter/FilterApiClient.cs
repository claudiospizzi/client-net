using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ReportPortal.Client.Api.Filter.Model;
using ReportPortal.Client.Api.Filter.Request;
using ReportPortal.Client.Common.Model;
using ReportPortal.Client.Common.Model.Filtering;
using ReportPortal.Client.Common.Model.Paging;
using ReportPortal.Client.Converter;
using ReportPortal.Client.Extension;

namespace ReportPortal.Client.Api.Filter
{
    public class FilterApiClient: BaseApiClient, IFilterApiClient
    {
        public FilterApiClient(HttpClient httpClient, string project) : base(httpClient, project)
        {
        }

        public async Task<List<EntryCreated>> AddUserFilterAsync(AddUserFilterRequest model)
        {
            var uri = HttpClient.BaseAddress.Append($"{Project}/filter");

            var body = ModelSerializer.Serialize<AddUserFilterRequest>(model);
            var response = await HttpClient.PostAsync(uri, new StringContent(body, Encoding.UTF8, "application/json")).ConfigureAwait(false);
            response.VerifySuccessStatusCode();
            return ModelSerializer.Deserialize<List<EntryCreated>>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        public async Task<PagingContent<FilterModel>> GetUserFiltersAsync(QueryFilter queryFilter = null)
        {
            var uri = HttpClient.BaseAddress.Append($"{Project}/filter/");
            if (queryFilter != null)
            {
                uri = uri.Append($"?{queryFilter.ToQueryString()}");
            }
            var response = await HttpClient.GetAsync(uri).ConfigureAwait(false);
            response.VerifySuccessStatusCode();
            return ModelSerializer.Deserialize<PagingContent<FilterModel>>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        public async Task<Message> DeleteUserFilterAsync(string filterId)
        {
            var uri = HttpClient.BaseAddress.Append($"{Project}/filter/{filterId}");

            var response = await HttpClient.DeleteAsync(uri).ConfigureAwait(false);
            response.VerifySuccessStatusCode();
            return ModelSerializer.Deserialize<Message>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }
    }
}
