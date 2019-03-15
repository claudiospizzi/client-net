using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ReportPortal.Client.Api.DataContract;
using ReportPortal.Client.Api.TestItem.DataContract;
using ReportPortal.Client.Extension;

namespace ReportPortal.Client.Api.TestItem
{
    public class TestItemApiClient : BaseApiClient, ITestItemApiClient
    {
        public TestItemApiClient(HttpClient httpClient, Uri baseUri, string project) : base(httpClient, baseUri, project)
        {
        }

        public async Task<PagingContent<TestItemModel>> GetTestItemsAsync(QueryFilter queryFilter = null)
        {
            var uri = BaseUri.Append($"{Project}/item");
            if (queryFilter != null)
            {
                uri = uri.Append($"?{queryFilter.ToQueryString()}");
            }

            return await GetAsync<PagingContent<TestItemModel>>(uri).ConfigureAwait(false);
        }

        public async Task<TestItemModel> GetTestItemAsync(string id)
        {
            var uri = BaseUri.Append($"{Project}/item/{id}");

            return await GetAsync<TestItemModel>(uri).ConfigureAwait(false);
        }

        public async Task<List<string>> GetUniqueTagsAsync(string launchId, string tagContains)
        {
            var uri = BaseUri.Append($"{Project}/item/tags?launch={launchId}&filter.cnt.tags={tagContains}");

            return await GetAsync<List<string>>(uri).ConfigureAwait(false);
        }

        public async Task<TestItemModel> StartTestItemAsync(StartTestItemRequest model)
        {
            var uri = BaseUri.Append($"{Project}/item");

            return await SendAsync<TestItemModel, StartTestItemRequest>(HttpMethod.Post, uri, model).ConfigureAwait(false);
        }

        public async Task<TestItemModel> StartTestItemAsync(string id, StartTestItemRequest model)
        {
            var uri = BaseUri.Append($"{Project}/item/{id}");

            return await SendAsync<TestItemModel, StartTestItemRequest>(HttpMethod.Post, uri, model).ConfigureAwait(false);
        }

        public async Task<Message> FinishTestItemAsync(string id, FinishTestItemRequest model)
        {
            var uri = BaseUri.Append($"{Project}/item/{id}");

            return await SendAsync<Message, FinishTestItemRequest>(HttpMethod.Put, uri, model).ConfigureAwait(false);
        }

        public async Task<Message> UpdateTestItemAsync(string id, UpdateTestItemRequest model)
        {
            var uri = BaseUri.Append($"{Project}/item/{id}/update");

            return await SendAsync<Message, UpdateTestItemRequest>(HttpMethod.Put, uri, model).ConfigureAwait(false);
        }

        public async Task<Message> DeleteTestItemAsync(string id)
        {
            var uri = BaseUri.Append($"{Project}/item/{id}");

            return await DeleteAsync<Message>(uri).ConfigureAwait(false);
        }

        public async Task<List<Issue>> AssignTestItemIssuesAsync(AssignTestItemIssuesRequest model)
        {
            var uri = BaseUri.Append($"{Project}/item");

            return await SendAsync<List<Issue>, AssignTestItemIssuesRequest>(HttpMethod.Put, uri, model).ConfigureAwait(false);
        }

        public async Task<List<TestItemHistoryModel>> GetTestItemHistoryAsync(string testItemId, int depth, bool full)
        {
            var uri = BaseUri.Append($"{Project}/item/history?ids={testItemId}&history_depth={depth}&is_full={full}");

            return await GetAsync<List<TestItemHistoryModel>>(uri).ConfigureAwait(false);
        }
    }
}
