namespace Checklist.Tests.Core;

public record CreateChecklistRequest(string Title, IEnumerable<CreateChecklistRequest.Item> Items)
{
    public record Item(string Text);
}