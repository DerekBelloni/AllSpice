using System.Threading.Tasks;
using AllSpice.Models;
using AllSpice.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AllSpice.Controllers
{
  [ApiController]
  [Route("api/[controller]")]

  public class IngredientsController : ControllerBase
  {
    private readonly IngredientsService _ingredientsService;

    public IngredientsController(IngredientsService ingredientsService)
    {
      _ingredientsService = ingredientsService;
    }



    // [HttpGet("{id}")]
    // public ActionResult<Ingredient> Get(int id)
    // {
    //   try
    //   {
    //     Ingredient ingredient = _ingredientsService.Get(id);
    //     return Ok(ingredient);
    //   }
    //   catch (System.Exception e)
    //   {
    //     return BadRequest(e.Message);
    //   }
    // }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Ingredient>> Create([FromBody] Ingredient ingredientData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        Ingredient ingredient = _ingredientsService.Create(userInfo, ingredientData);
        return Ok(ingredient);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<Ingredient>> Update(int id, [FromBody] Ingredient updatedIngredient)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        updatedIngredient.Id = id;
        Ingredient ingredient = _ingredientsService.Update(userInfo, updatedIngredient);
        return Ok(ingredient);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    [Authorize]

    public async Task<ActionResult<string>> Remove(int id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        return Ok(_ingredientsService.Remove(id, userInfo));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}
