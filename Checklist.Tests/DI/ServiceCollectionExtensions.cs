using Checklist.Tests.Core;
using Microsoft.Extensions.DependencyInjection;

namespace Checklist.Tests.DI;

public static class ServiceCollectionExtensions
{
    public static void AddApi(this ServiceCollection services)
    {
        services.AddTransient<IApi, Api>();
        services.AddTransient<IChecklistService, ChecklistService>();
    }
}