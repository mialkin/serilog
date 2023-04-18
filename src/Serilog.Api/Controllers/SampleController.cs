using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Serilog.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SampleController : ControllerBase
{
    private readonly ILogger<SampleController> _logger;

    public SampleController(ILogger<SampleController> logger) => _logger = logger;

    [HttpGet("get-current-utc-date")]
    public IActionResult GetCurrentUtcDate()
    {
        _logger.LogInformation("Start getting UTC date");
        var utc = DateTime.UtcNow;
        _logger.LogInformation("End getting UTC date");

        return Ok(utc);
    }
}