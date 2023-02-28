using FruitsApi.Models;
using FruitsApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FruitsApi.Controllers;

[ApiController]
[Route("api/fruits")]
public class FruitsController : ControllerBase
{
    private readonly FruitsService _service;

    public FruitsController(FruitsService service) => _service = service;

    [HttpPost]
    public async Task<ActionResult<Fruit>> Post([FromBody] Fruit request)
    {
        try
        {
            var createdFruit = await _service.Create(request);

            return Created("Fruit created.", createdFruit);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Fruit>>> GetAll()
    {
        try
        {
            var fruits = _service.GetAll();

            return Ok(fruits);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Fruit>> GetById([FromRoute] int id)
    {
        try
        {
            var fruit = await _service.GetById(id);

            return Ok(fruit);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Fruit>> Update([FromRoute] int id, [FromBody] Fruit request)
    {
        try
        {
            var fruit = await _service.Update(id, request);

            return Ok(fruit);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<Fruit>> Delete([FromRoute] int id)
    {
        try
        {
            var deletedFruit = await _service.Delete(id);

            return Ok(deletedFruit);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }
}