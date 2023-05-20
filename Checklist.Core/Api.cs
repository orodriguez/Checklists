namespace Checklist.Core;

public class Api : IApi
{
    public IChecklistService Checklist { get; set; }

    public Api(IChecklistService checklist) => 
        Checklist = checklist;
}