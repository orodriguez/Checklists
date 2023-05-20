namespace Checklist.Core;

public record ValueResult<TValue>(TValue Value) : Result
{
}