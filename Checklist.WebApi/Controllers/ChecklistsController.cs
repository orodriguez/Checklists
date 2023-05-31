using Checklist.Core;
using Microsoft.AspNetCore.Mvc;

namespace Checklist.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ChecklistsController : ControllerBase
{
    [HttpPost]
    public ActionResult<int> Create(CreateChecklistRequest request) => Ok(1);

    [HttpGet("{id}")]
    public ActionResult<Core.Checklist> Get(int id)
    {
        var checklist = new Core.Checklist(1, "Definition of Done", new[] { new Core.Checklist.Item(2, "World") });
        return Ok(checklist);
    }
}