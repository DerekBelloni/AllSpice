using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using AllSpice.Models;
using Dapper;


namespace AllSpice.Repositories
{
  public class IngredientsRepository
  {
    private readonly IDbConnection _db;

    public IngredientsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<Ingredient> Get()
    {
      string sql = @"
      SELECT
      i.*,
      r.*
      FROM ingredients i
      JOIN recipes r WHERE r.id = i.recipeId;
      ";
      return _db.Query<Ingredient, Recipe, Ingredient>(sql, (ingredient, recipe) =>
      {
        ingredient.Recipe = recipe;
        return ingredient;
      }).ToList();
    }

    internal Ingredient Get(int id)
    {
      throw new NotImplementedException();
    }

    internal Ingredient Create(Ingredient ingredientData)
    {
      throw new NotImplementedException();
    }

    internal string Remove(int id)
    {
      throw new NotImplementedException();
    }
  }
}