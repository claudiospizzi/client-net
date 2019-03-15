using System;
using System.Threading.Tasks;
using ReportPortal.Client.Api.Launch.DataContract;

namespace ReportPortal.Client.Tests.Api
{
    public class LaunchFixtureBase: BaseFixture, IDisposable
    {
        public string LaunchId { get; set; }

        public LaunchFixtureBase()
        {
            LaunchId = Task.Run(async () => await Service.Launch.StartLaunchAsync(new StartLaunchRequest
            {
                Name = "StartFinishDeleteLaunch",
                StartTime = DateTime.UtcNow
            })).Result.Id;
        }

        public void Dispose()
        {
            Task.Run(async () =>
            {
                await Service.Launch.FinishLaunchAsync(LaunchId, new FinishLaunchRequest { EndTime = DateTime.UtcNow }, true);
                await Service.Launch.DeleteLaunchAsync(LaunchId);
            }).Wait();
        }
    }
}
