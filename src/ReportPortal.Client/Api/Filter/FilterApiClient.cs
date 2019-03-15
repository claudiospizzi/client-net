using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ReportPortal.Client.Api.DataContract;
using ReportPortal.Client.Api.Filter.DataContract;
using ReportPortal.Client.Extension;

namespace ReportPortal.Client.Api.Filter
{
    public class FilterApiClient : BaseApiClient, IFilterApiClient
    {
        public FilterApiClient(HttpClient httpClient, Uri baseUri, string project) : base(httpClient, baseUri, project)
        {
        }

        public async Task<List<FilterModel>> AddUserFilterAsync(AddUserFilterRequest addUserFilterRequest)
        {
            var uri = BaseUri.Append($"{Project}/filter");

            return await SendAsync<List<FilterModel>, AddUserFilterRequest>(HttpMethod.Post, uri, addUserFilterRequest).ConfigureAwait(false);
        }

        public async Task<PagingContent<FilterModel>> GetUserFiltersAsync(QueryFilter queryFilter = null)
        {
            var uri = BaseUri.Append($"{Project}/filter/");
            if (queryFilter != null)
            {
                uri = uri.Append($"?{queryFilter.ToQueryString()}");
            }

            return await GetAsync<PagingContent<FilterModel>>(uri).ConfigureAwait(false);
        }

        public async Task<Message> DeleteUserFilterAsync(string filterId)
        {
            var uri = BaseUri.Append($"{Project}/filter/{filterId}");

            return await DeleteAsync<Message>(uri).ConfigureAwait(false);
        }
    }
}
