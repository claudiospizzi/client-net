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
using ReportPortal.Client.Extension;

namespace ReportPortal.Client
{
    public class ReportPortalClient : IReportPortalClient
    {
        /// <summary>
        /// Constructor to initialize a new object of service.
        /// </summary>
        /// <param name="baseUri">Base URI for REST service.</param>
        /// <param name="projectName">A project to work with.</param>
        /// <param name="uuid">UUID given from user's profile page.</param>
        /// <param name="messageHandler">The HTTP handler to use for sending all requests.</param>
        public ReportPortalClient(Uri baseUri, string projectName, string uuid, HttpMessageHandler messageHandler = null)
        {
            if (!baseUri.LocalPath.ToUpperInvariant().Contains("API/V1"))
            {
                baseUri = baseUri.Append("api/v1");
            }

            BaseUri = baseUri;

            ProjectName = projectName;

            HttpClient = messageHandler == null ? new HttpClient() : new HttpClient(messageHandler);

            HttpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(new ProductHeaderValue("dotNetReporter")));
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", uuid);

#if NET45
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
#endif
        }

        private HttpClient HttpClient { get; }

        public Uri BaseUri { get; }

        /// <summary>
        /// Get or set project name to interact with.
        /// </summary>
        public string ProjectName { get; }

        #region Api Clients

        private ILaunchApiClient _launch;
        public ILaunchApiClient Launch
        {
            get
            {
                if (_launch == null)
                {
                    _launch = new LaunchApiClient(HttpClient, BaseUri, ProjectName);
                }

                return _launch;
            }
        }

        private ILogApiClient _log;
        public ILogApiClient Log
        {
            get
            {
                if (_log == null)
                {
                    _log = new LogApiClient(HttpClient, BaseUri, ProjectName);
                }

                return _log;
            }
        }

        private IProjectApiClient _project;
        public IProjectApiClient Project
        {
            get
            {
                if (_project == null)
                {
                    _project = new ProjectApiClient(HttpClient, BaseUri, ProjectName);
                }

                return _project;
            }
        }

        private ITestItemApiClient _testItem;
        public ITestItemApiClient TestItem
        {
            get
            {
                if (_testItem == null)
                {
                    _testItem = new TestItemApiClient(HttpClient, BaseUri, ProjectName);
                }

                return _testItem;
            }
        }

        private IUserApiClient _user;
        public IUserApiClient User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserApiClient(HttpClient, BaseUri, ProjectName);
                }

                return _user;
            }
        }

        private IFilterApiClient _filter;
        public IFilterApiClient Filter
        {
            get
            {
                if (_filter == null)
                {
                    _filter = new FilterApiClient(HttpClient, BaseUri, ProjectName);
                }

                return _filter;
            }
        }

        #endregion
    }
}
