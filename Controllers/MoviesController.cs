using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilmVault.Controllers;

[Authorize]
public class MoviesController : BaseController<MoviesController>
{
    public MoviesController(ILogger<MoviesController> logger) : base(logger)
    {
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult Create()
    {
        return Ok();
    }

    [HttpGet]
    [Authorize(Roles = "Customer")]
    public IActionResult Read()
    {
        return Ok();
    }

    [HttpPatch]
    public IActionResult Update()
    {
        return Ok();
    }

    [HttpDelete]
    public IActionResult Delete()
    {
        return Ok();
    }
}