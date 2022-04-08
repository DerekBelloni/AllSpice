namespace AllSpice.Models
{
  public class Step
  {
    public string Id { get; set; }

    public int Sequence { get; set; }

    public string Body { get; set; }

    public string RecipeId { get; set; }

    public Recipe Recipe { get; set; }


  }
}