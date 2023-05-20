namespace Checklist.Core;

public record Checklist(int Id, string Title, IEnumerable<Checklist.Item> Items)
{
    public record Item(int Id, string Text);
}