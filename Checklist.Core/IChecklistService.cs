namespace Checklist.Core;

public interface IChecklistService
{
    Result Create(CreateChecklistRequest request);
    Result ById(int id);
}