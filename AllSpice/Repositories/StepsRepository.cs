using System.Data;
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
  }
}