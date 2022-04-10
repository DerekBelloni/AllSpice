using System;
using System.Collections.Generic;
using AllSpice.Models;
using AllSpice.Repositories;
namespace AllSpice.Controllers
{
  public class StepsService
  {
    private readonly StepsRepository _stepsRepo;
    private readonly RecipesService _recipesService;

    public StepsService(StepsRepository stepsRepo, RecipesService recipesService)
    {
      _stepsRepo = stepsRepo;
      _recipesService = recipesService;
    }

    internal List<Step> GetAllSteps(int id)
    {
      throw new NotImplementedException();
    }

    internal Step Create(Account userInfo, Step stepData)
    {
      Recipe foundRecipe = _recipesService.Get(stepData.RecipeId);
      if (userInfo.Id != foundRecipe.CreatorId)
      {
        throw new Exception("Can not add steps to recipes that are not yours");
      }
      return _stepsRepo.Create(stepData);
    }
  }
}