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

    internal List<Ingredient> GetAll(int id)
    {
      string sql = @"
      SELECT
      i.*
      FROM ingredients i
      WHERE @id = i.recipeId;
      ";
      List<Ingredient> ingredients = _db.Query<Ingredient>(sql, new { id }).ToList();
      return ingredients;
    }

    internal Ingredient Get(int id)
    {
      throw new NotImplementedException();
    }

    internal Ingredient Create(Ingredient ingredientData)
    {
      string sql = @"
      INSERT INTO ingredients
      (name, quantity, recipeId)
      VALUE
      (@Name, @Quantity, @RecipeId);
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, ingredientData);
      ingredientData.Id = id;
      return ingredientData;
    }

    internal string Remove(int id)
    {
      throw new NotImplementedException();
    }
  }
}