global using Hangfire.Dashboard.Management.v2.Support;
global using Hangfire.Dashboard.Management.v2.Metadata;
global using System.ComponentModel;
global using Hangfire.Server;
global using Hangfire;
using Hangfire.Dashboard.Management.v2;
using Hangfire.MemoryStorage;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddHangfire(configuration => configuration
        .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
        .UseSimpleAssemblyNameTypeSerializer()
        .UseRecommendedSerializerSettings()
        .UseMemoryStorage()
        .UseManagementPages(typeof(Program).Assembly))
    .AddHangfireServer();

var app = builder.Build();

app.UseHangfireDashboard("", new DashboardOptions
{
    DashboardTitle = "Dashboard",
    DisplayStorageConnectionString = false
});

app.Run();