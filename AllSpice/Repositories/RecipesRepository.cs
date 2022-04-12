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


    internal Recipe GetById(int id)
    {
      throw new NotImplementedException();
    }

    internal Recipe Create(Recipe newRecipe)
    {
      string sql = @"
      INSERT INTO recipes
      (title, subtitle, category, creatorId, picture)
      VALUES
      (@Title, @Subtitle, @Category, @CreatorId, @Picture);
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, newRecipe);
      newRecipe.Id = id;
      return newRecipe;
    }

    internal List<Recipe> Get()
    {
      string sql = @"
      SELECT
      r.*,
      a.*
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
      string sql = @"
      SELECT
      r.*,
      a.*
      FROM recipes r
      JOIN accounts a ON a.id = r.creatorId
      WHERE r.id = @id;
      ";
      return _db.Query<Recipe, Account, Recipe>(sql, (recipe, account) =>
      {
        recipe.Creator = account;
        return recipe;
      }, new { id }).FirstOrDefault();
    }

    internal List<FavoriteView> GetAccountFavorites(string id)
    {
      string sql = @"
     SELECT
      a.*,
      f.*,
      r.*
      FROM favorites f
      JOIN recipes r ON f.recipeId = r.id
      JOIN accounts a ON r.creatorId = a.id
      WHERE f.accountId = @id;";
      List<FavoriteView> recipes = _db.Query<Account, Recipe, FavoriteView, FavoriteView>(sql, (a, fv, r) =>
      {
        r.Creator = a;
        r.FavoriteId = fv.Id;
        return r;
      }, new { id }).ToList<FavoriteView>();
      return recipes;
    }

    internal string Remove(int id)
    {
      string sql = @"
     DELETE FROM recipes WHERE id = @id LIMIT 1;
     ";
      int rowsAffected = _db.Execute(sql, new { id });
      if (rowsAffected > 0)
      {
        return "deleted";
      }
      throw new Exception("could not delete");
    }

    internal void Update(Recipe original)
    {
      string sql = @"
      UPDATE recipes
      SET
        title = @Title,
        subtitle = @Subtitle,
        category = @Category
        WHERE id =  @Id;";
      _db.Execute(sql, original);
    }
  }
}