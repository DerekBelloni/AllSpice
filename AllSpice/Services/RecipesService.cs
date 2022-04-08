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
      throw new NotImplementedException();
    }
    internal Recipe Create(Recipe newRecipe)
    {
      throw new NotImplementedException();
    }

    internal Recipe Get(int id)
    {
      throw new NotImplementedException();
    }

    internal Recipe Update(Recipe updatedRecipe)
    {
      throw new NotImplementedException();
    }

    internal Recipe Remove(int id, Account user)
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