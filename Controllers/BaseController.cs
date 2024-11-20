﻿using Microsoft.AspNetCore.Mvc;

namespace FilmVault.Controllers;

[ApiController]
[Route("[controller]")]
public abstract class BaseController<T> : Controller where T : class
{
    protected readonly ILogger<T> _logger;

    protected BaseController(ILogger<T> logger)
    {
        _logger = logger;
    }
}