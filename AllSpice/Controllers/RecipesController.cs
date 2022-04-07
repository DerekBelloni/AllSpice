using Microsoft.AspNetCore.Mvc;
using AllSpice.Models;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;

namespace AllSpice.Controllers
{
  [ApiController]
  [Route("api/[controller")]

  public class RecipesController : ControllerBase
  {
    private readonly RecipesService _recipesService;

    public RecipesController(RecipesService recipesService)
    {
      _recipesService = recipesService;
    }



    [HttpPost]
    public async Task<ActionResult<Recipe>> Create([FromBody] Recipe newRecipe)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        newRecipe.CreatorId = userInfo.Id;
        Recipe recipe = _recipesService.Create(newRecipe);
        recipe.Creator = userInfo;
        return Ok(recipe);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }


  }
}