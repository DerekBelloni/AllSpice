using System;
using System.Collections.Generic;
using AllSpice.Controllers;
using AllSpice.Models;
using AllSpice.Repositories;

namespace AllSpice.Services
{
  public class IngredientsService
  {
    private readonly IngredientsRepository _ingredientsRepo;
    private readonly RecipesService _recipesService;

    public IngredientsService(IngredientsRepository ingredientsRepo, RecipesService recipesService)
    {
      _ingredientsRepo = ingredientsRepo;
      _recipesService = recipesService;
    }





    internal Ingredient Get(int id)
    {
      Ingredient found = _ingredientsRepo.Get(id);
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
      return _ingredientsRepo.Create(ingredientData);
    }

    internal String Remove(int id, Account user)
    {
      Ingredient foundIngredient = this.Get(id);
      Recipe foundRecipe = _recipesService.Get(foundIngredient.RecipeId);
      if (foundRecipe.CreatorId != user.Id)
      {
        throw new Exception("can not delete");
      }
      return _ingredientsRepo.Remove(id);
    }

    internal List<Ingredient> GetAll(int id)
    {
      return _ingredientsRepo.GetAll(id);
    }

    internal Ingredient Update(Account userInfo, Ingredient updatedIngredient)
    {
      Recipe foundRecipe = _recipesService.Get(updatedIngredient.RecipeId);
      if (foundRecipe.CreatorId != userInfo.Id)
      {
        throw new Exception("can not update ingredient");
      }
      Ingredient original = this.Get(updatedIngredient.Id);
      original.Name = updatedIngredient.Name ?? original.Name;
      original.Quantity = updatedIngredient.Quantity ?? original.Quantity;
      _ingredientsRepo.Update(original);
      return original;
    }
  }
}