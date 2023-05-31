using System.ComponentModel;
using System.Net;
using System.Text;
using System.Text.Json;
using Checklist.Core;

namespace Checklist.Client;

public class HttpClientChecklistService : IChecklistService
{
    private readonly HttpClient _client;

    public HttpClientChecklistService(HttpClient client) => _client = client;

    public async Task<Result> Create(CreateChecklistRequest request)
    {
        var response = await _client.PostAsync("/checklists", HttpContent(request));
        return await CreateResult<int>(response);
    }

    public async Task<Result> ById(int id)
    {
        var response = await _client.GetAsync($"/checklists/{id}");
        return await CreateResult<Core.Checklist>(response);
    }

    private static async Task<Result> CreateResult<T>(HttpResponseMessage response) =>
        response.StatusCode switch
        {
            HttpStatusCode.OK => await CreateValueResult<T>(response),
            _ => throw new InvalidEnumArgumentException(response.ToString())
        };

    private static async Task<ValueResult<T>> CreateValueResult<T>(HttpResponseMessage response)
    {
        var obj = await Deserialize<T>(response);
        return new ValueResult<T>(obj);
    }

    private static HttpContent HttpContent(CreateChecklistRequest red)
    {
        var json = JsonSerializer.Serialize(red);
        HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");
        return httpContent;
    }

    private static async Task<T> Deserialize<T>(HttpResponseMessage response)
    {
        var strContent = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<T>(strContent, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        }) ?? throw new InvalidOperationException("Object was deserialized to null");
    }
}