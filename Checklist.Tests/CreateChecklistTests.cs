using Checklist.Core;
using Checklist.Tests.Samples;

namespace Checklist.Tests;

public class CreateChecklistTests : ApiTest
{
    [Fact]
    public void SavesChecklist()
    {
        var request = new ValidCreateChecklistRequest();

        var id = Assert.IsType<ValueResult<int>>(Api.Checklist.Create(request)).Value;

        var retrievedChecklist = Assert.IsType<ValueResult<Core.Checklist>>(Api.Checklist.ById(id)).Value;
        
        Assert.Equal(request.Title, retrievedChecklist.Title);
    }
    
    [Fact]
    public void ReturnsResponseWithId()
    {
        var request = new ValidCreateChecklistRequest();
        
        var response = Api.Checklist.Create(request);

        var id = Assert.IsType<ValueResult<int>>(response).Value;
        
        Assert.NotEqual(0, id);
    }
}