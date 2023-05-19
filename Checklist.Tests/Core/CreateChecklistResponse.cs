namespace Checklist.Tests.Core;

public record CreateChecklistResponse
{
    public record Success(string Title) : CreateChecklistResponse
    {
    }
}