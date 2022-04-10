using System;
using AllSpice.Models;
using AllSpice.Repositories;

namespace AllSpice.Controllers
{
  public class FavoritesService
  {

    private readonly FavoritesRepository _favoritesRepo;

    public FavoritesService(FavoritesRepository favoritesRepo)
    {
      _favoritesRepo = favoritesRepo;
    }

    internal Favorite Get(int id)
    {
      Favorite found = _favoritesRepo.Get(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }

    internal object Create(Favorite favoriteData)
    {
      return _favoritesRepo.Create(favoriteData);
    }

    internal object Remove(int id, Account userInfo)
    {
      Favorite favorite = _favoritesRepo.Get(id);
      if (favorite.AccountId != userInfo.Id)
      {
        throw new Exception("can not delete");
      }
      return _favoritesRepo.Remove(id);
    }
  }
}