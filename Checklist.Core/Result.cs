using System.Text.Json.Serialization;

namespace Checklist.Core;
[JsonDerivedType(typeof(ValueResult<Checklist>))]
public record Result
{
}