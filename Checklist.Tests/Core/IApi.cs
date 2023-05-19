namespace Checklist.Tests.Core;

public interface IApi
{
    IChecklistService Checklist { get; set; }
}