using Domain.Entity;
using Domain.Interface;
using Domain.Request;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var usuarios = await _usuarioService.GetAllAsync();

        if (usuarios.Status == false)
        {
            return NotFound();
        }
        
        return Ok(usuarios);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var usuario = await _usuarioService.GetByIdAsync(id);

        if (usuario.Status == false)
        {
            return NotFound();
        }
        
        return Ok(usuario);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] UsuarioRequest request)
    {
        var result = await _usuarioService.AddAsync(request);
        return Ok(result);
    }
}