using System.Threading.Tasks;
using AllSpice.Models;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace AllSpice.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class StepsController : ControllerBase
  {
    private readonly StepsService _stepsService;

    public StepsController(StepsService stepsService)
    {
      _stepsService = stepsService;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Step>> Create([FromBody] Step stepData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        Step step = _stepsService.Create(userInfo, stepData);
        return Ok(step);

      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}