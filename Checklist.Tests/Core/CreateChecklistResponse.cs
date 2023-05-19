using System.Collections;

namespace Checklist.Tests.Core;

public record CreateChecklistResponse
{
    public record Success(int Id, string Title, IEnumerable<CreateChecklistRequest.Item> Items) : CreateChecklistResponse
    {
        public record Item();
    }
}