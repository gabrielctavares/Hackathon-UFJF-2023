using Hackathon.Models;
using Hackathon.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EnderecoController : Controller
{
    private readonly EnderecoService _service;

    public EnderecoController (EnderecoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        return Ok(await _service.GetAll());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        if (id <= 0)
            return NotFound();

        var model = await _service.GetById(id);

        if (model == null)
            return NotFound();

        return Ok(model);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Endereco model)
    {
        if (model.Id != 0)
            return BadRequest("Operação não permitida");

        if (ModelState.IsValid)
        {
            await _service.Insert(model);
            return Ok(model);
        }

        return BadRequest("Modelo inválido");
    }

    [HttpPut, Route("{id}")]
    public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] Endereco model)
    {
        if (id != model.Id)
            return BadRequest("Operação não permitida");

        if (!ModelState.IsValid)
            return BadRequest("Modelo inválido");

        try
        {
            if (await _service.GetById(id) == null)
                return NotFound();

            return Ok(await _service.Update(model));
        }
        catch (Exception e)
        {
            return BadRequest($"Erro ao editar {Environment.NewLine}Detalhes: {e.Message} ");
        }
    }

    [HttpDelete, Route("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        if (id <= 0)
            return NotFound();

        if (await _service.Delete(id))
            return NoContent();

        return NotFound();
    }
}