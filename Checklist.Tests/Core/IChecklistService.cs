namespace Checklist.Tests.Core;

public interface IChecklistService
{
    CreateChecklistResponse Create(CreateChecklistRequest request);
}