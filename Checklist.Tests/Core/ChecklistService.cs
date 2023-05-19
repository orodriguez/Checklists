namespace Checklist.Tests.Core;

public class ChecklistService : IChecklistService
{
    public CreateChecklistResponse Create(CreateChecklistRequest request) => 
        new CreateChecklistResponse.Success(1, request.Title, request.Items);
}