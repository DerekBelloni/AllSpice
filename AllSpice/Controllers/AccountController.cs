using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AllSpice.Models;
using AllSpice.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AllSpice.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class AccountController : ControllerBase
  {
    private readonly AccountService _accountService;
    private readonly RecipesService _recipesService;
    public AccountController(AccountService accountService, RecipesService recipesService)
    {
      _accountService = accountService;
      _recipesService = recipesService;
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<Account>> Get()
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        return Ok(_accountService.GetOrCreateProfile(userInfo));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("favorites")]
    [Authorize]
    public async Task<ActionResult<List<Favorite>>> GetAccountFavorites()
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        List<FavoriteView> favorites = _recipesService.GetAccountFavorites(userInfo.Id);
        return Ok(favorites);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }


}