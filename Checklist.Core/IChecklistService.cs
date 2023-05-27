namespace Checklist.Core;

public interface IChecklistService
{
    Task<Result> Create(CreateChecklistRequest request);
    Task<Result> ById(int id);
}