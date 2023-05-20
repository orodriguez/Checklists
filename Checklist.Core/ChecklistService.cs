namespace Checklist.Core;

public class ChecklistService : IChecklistService
{
    private readonly IFactory<CreateChecklistRequest, ChecklistEntity> _entityFactory;
    private readonly IRepository<ChecklistEntity> _checklists;
    private readonly IFactory<ChecklistEntity, Checklist> _responseFactory;

    public ChecklistService(IFactory<CreateChecklistRequest, ChecklistEntity> entityFactory, IRepository<ChecklistEntity> checklists, IFactory<ChecklistEntity, Checklist> responseFactory)
    {
        _entityFactory = entityFactory;
        _checklists = checklists;
        _responseFactory = responseFactory;
    }

    public Result Create(CreateChecklistRequest request)
    {
        var checklist = _entityFactory.Create(request);
        _checklists.Add(checklist);
        return new ValueResult<int>(checklist.Id);
    }

    public Result ById(int id)
    {
        var checklist = _checklists.ById(id);
        var response = _responseFactory.Create(checklist);
        return new ValueResult<Checklist>(response);
    }
}