using System;
using System.Collections.Generic;
using AllSpice.Controllers;
using AllSpice.Models;
using AllSpice.Repositories;

namespace AllSpice.Services
{
  public class IngredientsService
  {
    private readonly IngredientsRepository _repo;
    private readonly RecipesService _recipesService;

    public IngredientsService(IngredientsRepository repo, RecipesService recipesService)
    {
      _repo = repo;
      _recipesService = recipesService;
    }





    internal Ingredient Get(int id)
    {
      Ingredient found = _repo.Get(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }



    internal Ingredient Create(Account userInfo, Ingredient ingredientData)
    {
      Recipe foundRecipe = _recipesService.Get(ingredientData.RecipeId);
      if (userInfo.Id != foundRecipe.CreatorId)
      {
        throw new Exception("Can not add ingredients to recipes that are not yours");
      }
      return _repo.Create(ingredientData);
    }

    internal String Remove(int id, Account user)
    {
      Ingredient foundIngredient = this.Get(id);
      Recipe foundRecipe = _recipesService.Get(foundIngredient.RecipeId);
      if (foundRecipe.CreatorId != user.Id)
      {
        throw new Exception("can not delete");
      }
      return _repo.Remove(id);
    }

    internal List<Ingredient> GetAll(int id)
    {
      return _repo.GetAll(id);
    }
  }
}