using Checklist.Tests.Core;
using Checklist.Tests.Samples;

namespace Checklist.Tests;

public class CreateChecklistTests : ApiTest
{
    [Fact]
    public void ReturnsResponseWithId()
    {
        var request = new ValidCreateChecklistRequest();
        
        var response = Api.Checklist.Create(request);

        var checkList = Assert.IsType<CreateChecklistResponse.Success>(response);
        
        Assert.NotEqual(0, checkList.Id);
    }
    
    [Fact]
    public void ReturnsResponseWithTitle()
    {
        var request = new ValidCreateChecklistRequest { Title = "Definition of Done" };
        
        var response = Api.Checklist.Create(request);

        var checkList = Assert.IsType<CreateChecklistResponse.Success>(response);
        
        Assert.Equal("Definition of Done", checkList.Title);
    }
    
    [Fact]
    public void ReturnsResponseWithItems()
    {
        var request = new ValidCreateChecklistRequest
        {
            Items = new[]
            {
                new CreateChecklistRequest.Item("Code Completed"),
                new CreateChecklistRequest.Item("Tests Passing")
            }
        };
        
        var response = Api.Checklist.Create(request);

        var checkList = Assert.IsType<CreateChecklistResponse.Success>(response);

        Assert.Equal(new[] { "Code Completed", "Tests Passing" }, 
            checkList.Items.Select(item => item.Text));
    }
}