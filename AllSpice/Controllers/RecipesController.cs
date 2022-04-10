using Microsoft.AspNetCore.Mvc;
using AllSpice.Models;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using AllSpice.Services;

namespace AllSpice.Controllers
{
  [ApiController]
  [Route("api/[controller]")]

  public class RecipesController : ControllerBase
  {
    private readonly RecipesService _recipesService;
    private readonly IngredientsService _ingredientService;

    private readonly StepsService _stepsService;

    public RecipesController(RecipesService recipesService, IngredientsService ingredientsService, StepsService stepsService)
    {
      _recipesService = recipesService;
      _ingredientService = ingredientsService;
      _stepsService = stepsService;
    }

    [HttpGet]
    public ActionResult<List<Recipe>> Get()
    {
      try
      {
        List<Recipe> recipes = _recipesService.Get();
        return Ok(recipes);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Recipe> Get(int id)
    {
      try
      {
        Recipe recipe = _recipesService.Get(id);
        return Ok(recipe);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}/ingredients")]
    public ActionResult<List<Ingredient>> GetAllIngredients(int id)
    {
      try
      {
        List<Ingredient> recipeIngredients = _ingredientService.GetAll(id);
        return Ok(recipeIngredients);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}/steps")]
    [Authorize]
    public ActionResult<List<Step>> GetAllSteps(int id)
    {
      try
      {
        List<Step> recipeSteps = _stepsService.GetAllSteps(id);
        return Ok(recipeSteps);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Recipe>> Create([FromBody] Recipe recipeData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        recipeData.CreatorId = userInfo.Id;
        Recipe recipe = _recipesService.Create(recipeData);
        recipe.Creator = userInfo;
        return Ok(recipe);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<Recipe>> Update(int id, [FromBody] Recipe updatedRecipe)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        updatedRecipe.CreatorId = userInfo.Id;
        updatedRecipe.Id = id;
        Recipe recipe = _recipesService.Update(updatedRecipe);
        return Ok(recipe);
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
        return Ok(_recipesService.Remove(id, userInfo));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}