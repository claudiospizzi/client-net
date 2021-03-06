﻿using System;
using System.Threading.Tasks;
using ReportPortal.Client.Requests;

namespace ReportPortal.Client.Tests
{
    public class LaunchFixtureBase: BaseFixture, IDisposable
    {
        public string LaunchId { get; set; }

        public LaunchFixtureBase()
        {
            LaunchId = Task.Run(async () => await Service.StartLaunchAsync(new StartLaunchRequest
            {
                Name = "StartFinishDeleteLaunch",
                StartTime = DateTime.UtcNow
            })).Result.Id;
        }

        public void Dispose()
        {
            Task.Run(async () =>
            {
                await Service.FinishLaunchAsync(LaunchId, new FinishLaunchRequest { EndTime = DateTime.UtcNow }, true);
                await Service.DeleteLaunchAsync(LaunchId);
            }).Wait();
        }
    }
}
