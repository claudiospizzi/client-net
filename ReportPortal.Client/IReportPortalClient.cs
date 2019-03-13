using System;

namespace ReportPortal.Client
{
    /// <summary>
    /// ReportPortal Web API definition. Provides possibility to manage almost of service's entities.
    /// </summary>
    public interface IReportPortalClient
    {
        HttpClient HttpClient { get; }

        string ProjectName { get; }

        #region Resources

        ILaunchApiClient Launch { get; }

        ILogApiClient Log { get; }

        IProjectApiClient Project { get; }

        ITestItemApiClient TestItem { get; }

        IUserApiClient User { get; }

        IFilterApiClient Filter { get; }

        #endregion
    }
}
