namespace Checklist.Core;

public interface IFactory<in TArg, out TReturn>
{
    TReturn Create(TArg arg);
}