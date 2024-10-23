using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApplicationService;
using ApplicationService.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class ObjectController : ControllerBase
{
    private readonly IMyService _myService;

    public ObjectController(IMyService myService)
    {
        _myService = myService;
    }

    [HttpPost]
    public IActionResult Post([FromBody] MyObject object1)
    {
        _myService.ProcessObject(object1);
        return Ok();
    }
}

