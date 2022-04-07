using AllSpice.Repositories;
namespace AllSpice.Controllers
{
  public class StepsService
  {
    private readonly StepsRepository _repo;

    public StepsService(StepsRepository repo)
    {
      _repo = repo;
    }
  }
}