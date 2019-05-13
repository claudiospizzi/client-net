﻿using System;

namespace ReportPortal.Client.Tests.Api
{
    public class BaseFixture
    {
        protected static readonly string Username = "ci_check_net_client";
        protected readonly IReportPortalClient Service = new ReportPortalClient(new Uri("https://rp.epam.com/api/v1"), "ci-agents-checks", "b79e81a5-8448-49b5-857d-945ff5fd5ed2");
    }
}
