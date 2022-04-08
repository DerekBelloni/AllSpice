using System;
using System.Collections.Generic;
using AllSpice.Models;
using AllSpice.Repositories;

namespace AllSpice.Controllers
{
  public class RecipesService
  {

    private readonly RecipesRepository _repo;

    public RecipesService(RecipesRepository repo)
    {
      _repo = repo;
    }

    internal List<Recipe> Get()
    {
      return _repo.Get();
    }
    internal Recipe Create(Recipe newRecipe)
    {
      return _repo.Create(newRecipe);
    }

    internal Recipe Get(int id)
    {
      Recipe found = _repo.Get(id);
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
      _repo.Update(original);
      return original;
    }

    internal String Remove(int id, Account user)
    {
      Recipe recipe = _repo.GetById(id);
      if (recipe.CreatorId != user.Id)
      {
        throw new Exception("can not delete");
      }
      return _repo.Remove(id);
    }
  }
}