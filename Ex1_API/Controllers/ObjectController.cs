﻿using ApplicationService;
using ApplicationService.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
    [HttpPost(Name = "PostObject")]
    public IActionResult Post([FromBody] MyObject object1)
    {
        _myService.ProcessObject(object1);
        return Ok();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteObject(int id)
    {
        try
        {
            await _myService.DeleteAsync(id);
            return NoContent();

        }
        catch (FileNotFoundException)
        {

            return NotFound();
        }
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateObject(int id, [FromBody] MyObject obj)
    {
        try
        {
            await _myService.PutAsync(id, obj);
            return Ok();
        }
        catch (FileNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetObject(int id)
    {
        try
        {
            var obj = await _myService.GetAsync(id);
            return Ok(obj);

        }
        catch (FileNotFoundException)
        {

            return NotFound();
        }
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<MyObject>))]
    public async Task<IActionResult> GetAllObjects()
    {
        var objects = await _myService.GetAllObjectsAsync();
        return Ok(objects);
    }
}