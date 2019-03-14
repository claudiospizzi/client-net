using System;
using ReportPortal.Client.Api.Filter;
using ReportPortal.Client.Api.Launch;
using ReportPortal.Client.Api.Log;
using ReportPortal.Client.Api.Project;
using ReportPortal.Client.Api.TestItem;
using ReportPortal.Client.Api.User;

namespace ReportPortal.Client
{
    /// <summary>
    /// ReportPortal Web API definition. Provides possibility to manage almost of service's entities.
    /// </summary>
    public interface IReportPortalClient
    {
        Uri BaseUri { get; }

        string ProjectName { get; }

        #region Api Clients

        ILaunchApiClient Launch { get; }

        ILogApiClient Log { get; }

        IProjectApiClient Project { get; }

        ITestItemApiClient TestItem { get; }

        IUserApiClient User { get; }

        IFilterApiClient Filter { get; }

        #endregion
    }
}
