using System;
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

    internal Recipe Create(Recipe newRecipe)
    {
      throw new NotImplementedException();
    }
  }
}