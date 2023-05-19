namespace Checklist.Tests.Core;

public class ChecklistService : IChecklistService
{
    public CreateChecklistResponse Create(CreateChecklistRequest request)
    {
        return new CreateChecklistResponse.Success(request.Title, request.Items);
    }
}