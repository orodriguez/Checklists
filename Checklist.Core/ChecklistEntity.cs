namespace Checklist.Core;

public class ChecklistEntity : IEntity
{
    public int Id { get; set; }
    public string Title { get; set; }
    public IEnumerable<ItemEntity> Items { get; set; }
}