namespace Checklist.Core;

public interface IApi
{
    IChecklistService Checklist { get; set; }
}