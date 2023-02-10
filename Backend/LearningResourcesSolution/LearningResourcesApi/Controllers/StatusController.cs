using LearningResourcesApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace LearningResourcesApi.Controllers;

public class StatusController : ControllerBase 
{
    private ISystemTime _systemTime;

    public StatusController(ISystemTime systemTime)
    {
        _systemTime = systemTime;
    }

    // GET /status 
    [HttpGet("/status")]
    public ActionResult GetTheStatus()
    {
        // look this up from a database or whatever
        // If it is between midnight and 4pm, use a phone #
        // Outside of that, use an email address
        var contact = _systemTime.GetCurrent().Hour < 16 ? "bob@aol.com" : "555 555-5555";
        var response = new GetStatusResponse
        {
            Message = "All Good",
            Contact = "555 555-5555"
        };
        return Ok(response);
    }
}

public class GetStatusResponse
{
    public string Message { get; set; } = String.Empty;
    public string Contact { get; set; } = String.Empty;
}
