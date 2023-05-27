using System.Net;
using System.Text.Json;
using Checklist.Core;
using Checklist.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc.Testing;


namespace Checklist.Tests;

public class HttpTests : IClassFixture<WebApplicationFactory<ChecklistsController>>
{
    private readonly HttpClient _client;

    public HttpTests(WebApplicationFactory<ChecklistsController> factory)
    {
        _client = factory.CreateDefaultClient();
    }

    [Fact(Skip = "POC")]
    public async Task Test()
    {
        var response = await _client.GetAsync("/checklists/1");

        response.EnsureSuccessStatusCode();

        Assert.Equivalent(HttpStatusCode.OK, response.StatusCode);
        
        var stringAsync = await response.Content.ReadAsStringAsync();

        var result = JsonSerializer.Deserialize<Result>(stringAsync, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            
        });

        var checklist = Assert.IsType<ValueResult<Core.Checklist>>(result);
        
        Assert.Equal("Hello", checklist.Value.Title);
    }
}