using Checklist.Tests.Core;
using Checklist.Tests.Samples;

namespace Checklist.Tests;

public class CreateChecklistTests : ApiTest
{
    [Fact]
    public void Title()
    {
        var request = new ValidCreateChecklistRequest { Title = "Definition of Done" };
        
        var response = Api.Checklist.Create(request);

        var checkList = Assert.IsType<CreateChecklistResponse.Success>(response);
        
        Assert.Equal("Definition of Done", checkList.Title);
    }
    
    [Fact]
    public void Items_One()
    {
        var request = new ValidCreateChecklistRequest
        {
            Items = new[] { new CreateChecklistRequest.Item("Tests Passing") }
        };
        
        var response = Api.Checklist.Create(request);

        var checkList = Assert.IsType<CreateChecklistResponse.Success>(response);

        var item = Assert.Single(checkList.Items);
        
        Assert.Equal("Tests Passing", item.Text);
    }
}