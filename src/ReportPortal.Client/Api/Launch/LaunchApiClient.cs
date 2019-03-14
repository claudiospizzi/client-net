using System;
using System.Net.Http;
using System.Threading.Tasks;
using ReportPortal.Client.Api.Launch.Model;
using ReportPortal.Client.Api.Launch.Request;
using ReportPortal.Client.Common.Model;
using ReportPortal.Client.Common.Model.Filtering;
using ReportPortal.Client.Common.Model.Paging;
using ReportPortal.Client.Extension;

namespace ReportPortal.Client.Api.Launch
{
    public class LaunchApiClient : BaseApiClient, ILaunchApiClient
    {
        public LaunchApiClient(HttpClient httpClient, Uri baseUri, string project) : base(httpClient, baseUri, project)
        {
        }

        public async Task<PagingContent<LaunchModel>> GetLaunchesAsync(QueryFilter queryFilter = null, bool debug = false)
        {
            var uri = BaseUri.Append($"{Project}/launch");
            if (debug) { uri = uri.Append("mode"); }

            if (queryFilter != null)
            {
                uri = uri.Append($"?{queryFilter.ToQueryString()}");
            }

            return await SendAsync<PagingContent<LaunchModel>, object>(HttpMethod.Get, uri, null).ConfigureAwait(false);
        }

        public async Task<LaunchModel> GetLaunchAsync(string id)
        {
            var uri = BaseUri.Append($"{Project}/launch/{id}");

            return await SendAsync<LaunchModel, object>(HttpMethod.Get, uri, null).ConfigureAwait(false);
        }

        public async Task<LaunchModel> StartLaunchAsync(StartLaunchRequest startLaunchRequest)
        {
            var uri = BaseUri.Append($"{Project}/launch");

            return await SendAsync<LaunchModel, StartLaunchRequest>(HttpMethod.Post, uri, startLaunchRequest).ConfigureAwait(false);
        }

        public async Task<Message> FinishLaunchAsync(string id, FinishLaunchRequest finishLaunchRequest, bool force = false)
        {
            var uri = BaseUri.Append($"{Project}/launch/{id}");
            uri = force ? uri.Append("/stop") : uri.Append("/finish");

            return await SendAsync<Message, FinishLaunchRequest>(HttpMethod.Put, uri, finishLaunchRequest).ConfigureAwait(false);
        }

        public async Task<Message> DeleteLaunchAsync(string id)
        {
            var uri = BaseUri.Append($"{Project}/launch/{id}");

            return await SendAsync<Message, object>(HttpMethod.Delete, uri, null).ConfigureAwait(false);
        }

        public async Task<LaunchModel> MergeLaunchesAsync(MergeLaunchesRequest mergeLaunchesRequest)
        {
            var uri = BaseUri.Append($"{Project}/launch/merge");

            return await SendAsync<LaunchModel, MergeLaunchesRequest>(HttpMethod.Post, uri, mergeLaunchesRequest).ConfigureAwait(false);
        }

        public async Task<Message> UpdateLaunchAsync(string id, UpdateLaunchRequest updateLaunchRequest)
        {
            var uri = BaseUri.Append($"{Project}/launch/{id}/update");

            return await SendAsync<Message, UpdateLaunchRequest>(HttpMethod.Put, uri, updateLaunchRequest).ConfigureAwait(false);
        }

        public async Task<Message> AnalyzeLaunchAsync(AnalyzeLaunchRequest analyzeLaunchRequest)
        {
            var uri = BaseUri.Append($"{Project}/launch/analyze");

            return await SendAsync<Message, AnalyzeLaunchRequest>(HttpMethod.Post, uri, analyzeLaunchRequest).ConfigureAwait(false);
        }
    }
}
