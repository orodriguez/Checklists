using System.Net;
using System.Text.Json;
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

    [Fact]
    public async Task Test()
    {
        var response = await _client.GetAsync("/checklists/1");

        response.EnsureSuccessStatusCode();

        Assert.Equivalent(HttpStatusCode.OK, response.StatusCode);
        
        var stringAsync = await response.Content.ReadAsStringAsync();

        var checklist = JsonSerializer.Deserialize<Core.Checklist>(stringAsync, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
        
        Assert.Equal("Hello", checklist.Title);
    }
}