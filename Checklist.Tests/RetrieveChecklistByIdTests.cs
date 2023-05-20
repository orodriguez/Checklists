using Checklist.Core;
using Checklist.Tests.Samples;

namespace Checklist.Tests;

public class RetrieveChecklistByIdTests : ApiTest
{
    [Fact]
    public void Id()
    {
        var request = new ValidCreateChecklistRequest();
        
        var response = Api.Checklist.Create(request);

        var id = Assert.IsType<ValueResult<int>>(response).Value;
        
        Assert.NotEqual(0, id);
    }
    
    [Fact]
    public void Title()
    {
        var request = new ValidCreateChecklistRequest
        {
            Title = "Definition of Done"
        };

        var id = Assert.IsType<ValueResult<int>>(Api.Checklist.Create(request)).Value;

        var checklist = Assert.IsType<ValueResult<Core.Checklist>>(Api.Checklist.ById(id)).Value;
        
        Assert.Equal(request.Title, checklist.Title);
    }
}