using System;
using System.Collections.Generic;
using AllSpice.Models;
using AllSpice.Repositories;

namespace AllSpice.Controllers
{
  public class RecipesService
  {

    private readonly RecipesRepository _recipesRepo;

    public RecipesService(RecipesRepository recipesRepo)
    {
      _recipesRepo = recipesRepo;
    }

    internal List<Recipe> Get()
    {
      return _recipesRepo.Get();
    }
    internal Recipe Create(Recipe newRecipe)
    {
      return _recipesRepo.Create(newRecipe);
    }

    internal Recipe Get(int id)
    {
      Recipe found = _recipesRepo.Get(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }

    internal Recipe Update(Recipe updatedRecipe)
    {
      Recipe original = Get(updatedRecipe.Id);
      original.Title = updatedRecipe.Title ?? original.Title;
      original.Subtitle = updatedRecipe.Subtitle ?? original.Subtitle;
      original.Category = updatedRecipe.Category ?? original.Category;
      _recipesRepo.Update(original);
      return original;
    }

    internal string Remove(int id, Account user)
    {
      Recipe recipe = _recipesRepo.Get(id);
      if (recipe.CreatorId != user.Id)
      {
        throw new Exception("can not delete");
      }
      return _recipesRepo.Remove(id);
    }

    internal List<FavoriteView> GetAccountFavorites(string id)
    {
      return _recipesRepo.GetAccountFavorites(id);
    }
  }
}