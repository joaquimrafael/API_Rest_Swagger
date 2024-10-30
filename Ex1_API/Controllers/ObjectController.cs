using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApplicationService;
using ApplicationService.Interfaces;

// defino essa classe como controler da API
[ApiController]
[Route("api/v1/[controller]")]
public class ObjectController : ControllerBase
{
    private readonly IMyService _myService;
    // injeto a minha classe de serviço no construtor para processar o objeto
    public ObjectController(IMyService myService)
    {
        _myService = myService;
    }

    // faça uma requisição http post para escrever o objeto
    [HttpPost(Name ="PostObject")]
    public IActionResult Post([FromBody] MyObject object1)
    {
        _myService.ProcessObject(object1);
        return Ok();
    }
}

