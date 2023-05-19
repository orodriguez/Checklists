using Checklist.Tests.Core;

namespace Checklist.Tests.Samples;

public record ValidCreateChecklistRequest() : CreateChecklistRequest("DefaultTitle", Array.Empty<Item>());