using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using AllSpice.Models;
using Dapper;

namespace AllSpice.Repositories
{
  public class StepsRepository
  {
    private readonly IDbConnection _db;

    public StepsRepository(IDbConnection db)
    {


      _db = db;
    }

    internal Step Create(Step stepData)
    {
      string sql = @"
      INSERT INTO steps
      (sequence, body, recipeId)
      VALUE
      (@Sequence, @Body, @RecipeId);
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, stepData);
      stepData.Id = id;
      return stepData;
    }

    internal Step Get(int id)
    {
      string sql = @"
      SELECT
      s.*
      FROM steps s
      WHERE s.id = @id;";
      return _db.Query<Step>(sql, new { id }).FirstOrDefault();
    }

    internal List<Step> GetAll(int id)
    {
      string sql = @"
      SELECT
      s.*
      FROM steps s
      WHERE @id = s.recipeId;";
      List<Step> steps = _db.Query<Step>(sql, new { id }).ToList();
      return steps;
    }

    internal Step Update(Step original)
    {
      string sql = @"
      UPDATE steps
      SET
        body = @Body,
        sequence = @Sequence
        WHERE id = @Id;";
      _db.Execute(sql, original);
      return original;
    }

    internal String Remove(int id)
    {
      string sql = @"
      DELETE FROM steps WHERE id = @id LIMIT 1;";
      int rowsAffected = _db.Execute(sql, new { id });
      if (rowsAffected > 0)
      {
        return "deleted";
      }
      throw new Exception("could not delete");
    }
  }
}