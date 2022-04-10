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


    internal Step Get(int id)
    {
      Step found = _stepsRepo.Get(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }
    internal List<Step> GetAllSteps(int id)
    {
      return _stepsRepo.GetAll(id);
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

    internal Step Update(Account userInfo, Step updatedStep)
    {
      Recipe foundRecipe = _recipesService.Get(updatedStep.RecipeId);
      if (foundRecipe.CreatorId != userInfo.Id)
      {
        throw new Exception("can not update step");
      }
      Step original = this.Get(updatedStep.Id);
      original.Body = updatedStep.Body ?? original.Body;
      original.Sequence = updatedStep.Sequence;
      _stepsRepo.Update(original);
      return original;
    }

    internal String Remove(int id, Account userInfo)
    {
      Step foundStep = this.Get(id);
      Recipe foundRecipe = _recipesService.Get(foundStep.RecipeId);
      if (foundRecipe.CreatorId != userInfo.Id)
      {
        throw new Exception("can not delete");
      }
      return _stepsRepo.Remove(id);
    }
  }
}