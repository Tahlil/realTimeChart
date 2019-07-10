using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

[Route("api/[controller]")]
[ApiController]
public class ChartController : ControllerBase
{
    private IHubContext<ChartHub> _hub;
    public ChartController(IHubContext<ChartHub> hub)
    {
        _hub = hub;
    }
    public IActionResult Get()
    {
        var timerManager = new TimerManager(() => _hub.Clients.All.SendAsync("transferchartdata", DataManager.GetData()));
        return Ok(new { Message = "Request Completed" });
     }
}