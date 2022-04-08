using System;
using System.Data;
using AllSpice.Models;

namespace AllSpice.Repositories
{
  public class RecipesRepository
  {
    private readonly IDbConnection _db;

    public RecipesRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Recipe Remove(int id)
    {
      throw new NotImplementedException();
    }

    internal Recipe GetById(int id)
    {
      throw new NotImplementedException();
    }
  }
}