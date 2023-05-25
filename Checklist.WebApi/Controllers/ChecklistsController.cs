using Checklist.Core;
using Microsoft.AspNetCore.Mvc;

namespace Checklist.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ChecklistsController : ControllerBase
{
    [HttpGet("{id}")]
    public ActionResult<Core.Checklist> Get(int id)
    {
        var checklist = new Core.Checklist(1, "Hello", new[] { new Core.Checklist.Item(2, "World") });
        return Ok(new ValueResult<Core.Checklist>(checklist));
    }
}