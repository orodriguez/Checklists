using System.Text;
using System.Text.Json;
using Checklist.Core;

namespace Checklist.Client;

public class HttpClientChecklistService : IChecklistService
{
    private readonly HttpClient _client;

    public HttpClientChecklistService(HttpClient client)
    {
        _client = client;
    }

    public async Task<Result> Create(CreateChecklistRequest request)
    {
        var response = await _client.PostAsync("/checklists", HttpContent(request));
        var responseStr = await response.Content.ReadAsStringAsync();
        var id = JsonSerializer.Deserialize<int>(responseStr);
        return new ValueResult<int>(id);
    }

    public async Task<Result> ById(int id)
    {
        var response = await _client.GetAsync("/checklists");
        var responseStr = await response.Content.ReadAsStringAsync();
        var checklist = JsonSerializer.Deserialize<Core.Checklist>(responseStr);
        return new ValueResult<Core.Checklist>(checklist);
    }

    private static HttpContent HttpContent(CreateChecklistRequest red)
    {
        var json = JsonSerializer.Serialize(red);
        HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");
        return httpContent;
    }
}