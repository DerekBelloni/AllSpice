namespace AllSpice.Models
{
  public class Ingredient
  {
    public string Id { get; set; }
    public string Name { get; set; }

    public string Quantity { get; set; }

    public int recipeId { get; set; }

    public Recipe Recipe { get; set; }


  }
}