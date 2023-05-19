using Checklist.Tests.Core;

namespace Checklist.Tests;

public class CreateChecklistTests : ApiTest
{
    [Fact]
    public void Title()
    {
        var request = new CreateChecklistRequest(
            "Definition of Done");
        
        var response = Api.Checklist.Create(request);

        var checkList = Assert.IsType<CreateChecklistResponse.Success>(response);
        
        Assert.Equal("Definition of Done", checkList.Title);
    }
}