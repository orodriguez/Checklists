namespace Checklist.Core;

public class Factory : IFactory<CreateChecklistRequest, ChecklistEntity>, IFactory<ChecklistEntity, Checklist>
{
    public ChecklistEntity Create(CreateChecklistRequest request) =>
        new()
        {
            Title = request.Title,
            Items = request.Items.Select(Creates).ToList()
        };

    private ItemEntity Creates(CreateChecklistRequest.Item item) =>
        new()
        {
            Text = item.Text
        };

    public Checklist Create(ChecklistEntity entity)
    {
        var items = entity.Items.Select(Create);
        return new Checklist(entity.Id, entity.Title, items);
    }

    private Checklist.Item Create(ItemEntity item) => 
        new(item.Id, item.Text);
}