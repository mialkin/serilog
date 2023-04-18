using System;
using Microsoft.AspNetCore.Mvc;

namespace Serilog.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SampleController : ControllerBase
{
    [HttpGet("GetCurrentUtcDate")]
    public IActionResult GetCurrentUtcDate()
    {
        return Ok(DateTime.UtcNow);
    }
}