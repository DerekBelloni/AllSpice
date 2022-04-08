using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using AllSpice.Models;
using Dapper;

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

    internal List<Recipe> Get()
    {
      string sql = @"
      SELECT
      r.*,
      a.*,
      FROM recipes r
      JOIN accounts a WHERE a.id = r.creatorId;
      ";
      return _db.Query<Recipe, Account, Recipe>(sql, (recipe, account) =>
      {
        recipe.Creator = account;
        return recipe;
      }).ToList();
    }

    internal Recipe Get(int id)
    {
      throw new NotImplementedException();
    }

    internal void Update(Recipe original)
    {
      throw new NotImplementedException();
    }
  }
}