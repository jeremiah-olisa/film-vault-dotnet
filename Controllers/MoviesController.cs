using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilmVault.Controllers;

[Authorize]
public class MoviesController(ILogger<MoviesController> logger) : BaseController<MoviesController>(logger)
{
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult Create()
    {
        return Ok();
    }

    [HttpGet]
    public IActionResult Read()
    {
        return Ok();
    }

    [HttpPatch]
    [Authorize(Roles = "Admin")]
    public IActionResult Update()
    {
        return Ok();
    }

    [HttpDelete]
    [Authorize(Roles = "Admin")]
    public IActionResult Delete()
    {
        return Ok();
    }
}