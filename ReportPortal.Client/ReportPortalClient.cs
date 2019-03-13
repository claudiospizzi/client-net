using System;
#if NETFRAMEWORK
using System.Net;
#endif
using System.Net.Http;
using System.Net.Http.Headers;
using ReportPortal.Client.Api.Filter;
using ReportPortal.Client.Api.Launch;
using ReportPortal.Client.Api.Log;
using ReportPortal.Client.Api.Project;
using ReportPortal.Client.Api.TestItem;
using ReportPortal.Client.Api.User;
using ReportPortal.Client.Extention;

namespace ReportPortal.Client
{
    public class ReportPortalClient : IReportPortalClient
    {
        /// <summary>
        /// Constructor to initialize a new object of service.
        /// </summary>
        /// <param name="uri">Base URI for REST service.</param>
        /// <param name="project">A project to manage.</param>
        /// <param name="password">A password for user. Can be UID given from user's profile page.</param>
        /// <param name="messageHandler">The HTTP handler to use for sending all requests.</param>
        public ReportPortalClient(Uri uri, string project, string password, HttpMessageHandler messageHandler)
        {
            HttpClient = new HttpClient(messageHandler);

            if (!uri.LocalPath.ToUpperInvariant().Contains("API/V1"))
            {
                uri = uri.Append("api/v1");
            }
            
            HttpClient.BaseAddress = uri;

            HttpClient.DefaultRequestHeaders.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + password);
            HttpClient.DefaultRequestHeaders.Add("User-Agent", ".NET Reporter");

            ProjectName = project;

#if NET45
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
#endif
        }

        /// <summary>
        /// Constructor to initialize a new object of service.
        /// </summary>
        /// <param name="uri">Base URI for REST service.</param>
        /// <param name="project">A project to manage.</param>
        /// <param name="password">A password for user. Can be UID given from user's profile page.</param>
        public ReportPortalClient(Uri uri, string project, string password)
            : this(uri, project, password, new RetryWithExponentialBackoffHttpClientHandler(3))
        {
        }

        public HttpClient HttpClient { get; }

        /// <summary>
        /// Get or set project name to interact with.
        /// </summary>
        public string ProjectName { get; }

        #region Resources

        public ILaunchApiClient Launch => new LaunchApiClient(HttpClient, ProjectName);

        public ILogApiClient Log => new LogApiClient(HttpClient, ProjectName);

        public IProjectApiClient Project => new ProjectApiClient(HttpClient, ProjectName);

        public ITestItemApiClient TestItem => new TestItemApiClient(HttpClient, ProjectName);

        public IUserApiClient User => new UserApiClient(HttpClient, ProjectName);

        public IFilterApiClient Filter => new FilterApiClient(HttpClient, ProjectName);

        #endregion
    }
}
