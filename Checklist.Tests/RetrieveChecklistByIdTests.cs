using Checklist.Core;
using Checklist.Tests.Samples;

namespace Checklist.Tests;

public class RetrieveChecklistByIdTests : ApiTest
{
    [Fact]
    public async Task Id()
    {
        var request = new ValidCreateChecklistRequest();
        
        var response = await Api.Checklist.Create(request);

        var id = Assert.IsType<ValueResult<int>>(response).Value;
        
        Assert.NotEqual(0, id);
    }
    
    [Fact]
    public async Task Title()
    {
        var request = new ValidCreateChecklistRequest
        {
            Title = "Definition of Done"
        };

        var id = Assert.IsType<ValueResult<int>>(await Api.Checklist.Create(request)).Value;

        var checklist = Assert.IsType<ValueResult<Core.Checklist>>(await Api.Checklist.ById(id)).Value;
        
        Assert.Equal(request.Title, checklist.Title);
    }
    
    [Fact]
    public async Task Items()
    {
        var item = new CreateChecklistRequest.Item("Tests Passing");
        
        var request = new ValidCreateChecklistRequest
        {
            Items = new [] { item }
        };

        var createResult = await Api.Checklist.Create(request);
        var id = Assert.IsType<ValueResult<int>>(createResult).Value;

        var byIdByIdResult = await Api.Checklist.ById(id);
        var checklist = Assert.IsType<ValueResult<Core.Checklist>>(byIdByIdResult).Value;

        var createdItem = Assert.Single(checklist.Items);
        
        Assert.NotEqual(0, createdItem.Id);
        Assert.Equal("Tests Passing", item.Text);
    }
}