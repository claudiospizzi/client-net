using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ReportPortal.Client.Api.Launch.Model;
using ReportPortal.Client.Api.Launch.Request;
using ReportPortal.Client.Common.Model;
using ReportPortal.Client.Common.Model.Filtering;
using ReportPortal.Client.Common.Model.Paging;
using ReportPortal.Client.Converter;
using ReportPortal.Client.Extension;

namespace ReportPortal.Client.Api.Launch
{
    public class LaunchApiClient : BaseApiClient, ILaunchApiClient
    {
        public LaunchApiClient(HttpClient httpClient, string project) : base(httpClient, project)
        {
        }

        public async Task<PagingContent<LaunchModel>> GetLaunchesAsync(QueryFilter queryFilter = null, bool debug = false)
        {
            var uri = HttpClient.BaseAddress.Append($"{Project}/launch");
            if (debug) { uri = uri.Append("mode"); }

            if (queryFilter != null)
            {
                uri = uri.Append($"?{queryFilter.ToQueryString()}");
            }

            var response = await HttpClient.GetAsync(uri).ConfigureAwait(false);
            response.VerifySuccessStatusCode();
            return ModelSerializer.Deserialize<PagingContent<LaunchModel>>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        public async Task<LaunchModel> GetLaunchAsync(string id)
        {
            var uri = HttpClient.BaseAddress.Append($"{Project}/launch/{id}");
            var response = await HttpClient.GetAsync(uri).ConfigureAwait(false);
            response.VerifySuccessStatusCode();
            return ModelSerializer.Deserialize<LaunchModel>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        public async Task<LaunchModel> StartLaunchAsync(StartLaunchRequest startLaunchRequest)
        {
            var uri = HttpClient.BaseAddress.Append($"{Project}/launch");
            var body = ModelSerializer.Serialize<StartLaunchRequest>(startLaunchRequest);
            var response = await HttpClient.PostAsync(uri, new StringContent(body, Encoding.UTF8, "application/json")).ConfigureAwait(false);
            response.VerifySuccessStatusCode();
            return ModelSerializer.Deserialize<LaunchModel>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        public async Task<Message> FinishLaunchAsync(string id, FinishLaunchRequest finishLaunchRequest, bool force = false)
        {
            var uri = HttpClient.BaseAddress.Append($"{Project}/launch/{id}");
            uri = force == true ? uri.Append("/stop") : uri.Append("/finish");
            var body = ModelSerializer.Serialize<FinishLaunchRequest>(finishLaunchRequest);
            var response = await HttpClient.PutAsync(uri, new StringContent(body, Encoding.UTF8, "application/json")).ConfigureAwait(false);
            response.VerifySuccessStatusCode();
            return ModelSerializer.Deserialize<Message>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        public async Task<Message> DeleteLaunchAsync(string id)
        {
            var uri = HttpClient.BaseAddress.Append($"{Project}/launch/{id}");
            var response = await HttpClient.DeleteAsync(uri).ConfigureAwait(false);
            response.VerifySuccessStatusCode();
            return ModelSerializer.Deserialize<Message>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        public async Task<LaunchModel> MergeLaunchesAsync(MergeLaunchesRequest mergeLaunchesRequest)
        {
            var uri = HttpClient.BaseAddress.Append($"{Project}/launch/merge");
            var body = ModelSerializer.Serialize<MergeLaunchesRequest>(mergeLaunchesRequest);
            var response = await HttpClient.PostAsync(uri, new StringContent(body, Encoding.UTF8, "application/json")).ConfigureAwait(false);
            response.VerifySuccessStatusCode();
            return ModelSerializer.Deserialize<LaunchModel>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        public async Task<Message> UpdateLaunchAsync(string id, UpdateLaunchRequest updateLaunchRequest)
        {
            var uri = HttpClient.BaseAddress.Append($"{Project}/launch/{id}/update");
            var body = ModelSerializer.Serialize<UpdateLaunchRequest>(updateLaunchRequest);
            var response = await HttpClient.PutAsync(uri, new StringContent(body, Encoding.UTF8, "application/json")).ConfigureAwait(false);
            response.VerifySuccessStatusCode();
            return ModelSerializer.Deserialize<Message>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        public async Task<Message> AnalyzeLaunchAsync(AnalyzeLaunchRequest analyzeLaunchRequest)
        {
            var uri = HttpClient.BaseAddress.Append($"{Project}/launch/analyze");
            var body = ModelSerializer.Serialize<AnalyzeLaunchRequest>(analyzeLaunchRequest);
            var response = await HttpClient.PostAsync(uri, new StringContent(body, Encoding.UTF8, "application/json")).ConfigureAwait(false);
            response.VerifySuccessStatusCode();
            return ModelSerializer.Deserialize<Message>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }
    }
}
