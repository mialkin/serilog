using System;
using Microsoft.AspNetCore.Mvc;

namespace Serilog.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SampleController : ControllerBase
{
    [HttpGet("get-current-utc-date")]
    public IActionResult GetCurrentUtcDate()
    {
        return Ok(DateTime.UtcNow.ToLocalTime());
    }
}