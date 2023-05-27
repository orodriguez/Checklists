using Checklist.Client;
using Checklist.Core;
using Checklist.DI;
using Checklist.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace Checklist.Tests;

public class ApiTest
{
    protected IApi Api { get; set; }
    public ApiTest()
    {
        var services = new ServiceCollection();
        services.AddApi();
        services.AddTransient<IChecklistService, HttpClientChecklistService>();
        services.AddSingleton<HttpClient>(serviceProvider =>
            serviceProvider.GetRequiredService<WebApplicationFactory<ChecklistsController>>().CreateClient());
        services.AddSingleton<WebApplicationFactory<ChecklistsController>>();
        var provider = services.BuildServiceProvider();
        Api = provider.GetRequiredService<IApi>();
    }
}