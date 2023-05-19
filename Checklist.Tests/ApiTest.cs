using Checklist.Tests.Core;
using Checklist.Tests.DI;
using Microsoft.Extensions.DependencyInjection;

namespace Checklist.Tests;

public class ApiTest
{
    protected IApi Api { get; set; }
    public ApiTest()
    {
        var services = new ServiceCollection();
        services.AddApi();
        var provider = services.BuildServiceProvider();
        Api = provider.GetRequiredService<IApi>();
    }
}