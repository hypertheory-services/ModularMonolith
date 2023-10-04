using Microsoft.AspNetCore.Mvc;

using SharedUtils;

namespace Api1.Controllers;

public class HomeController : ControllerBase
{
    private readonly Utils _utils;

    public HomeController(Utils utils)
    {
        _utils = utils;
    }

    [HttpGet("/")]
    public ActionResult GetThem()
    {
        var response = Enumerable.Range(1, 100).Select(n => new { num = n, isEven = _utils.IsEven(n) }).ToList();

        return Ok(response);
    }
}
