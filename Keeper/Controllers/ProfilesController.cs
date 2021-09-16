using Keeper.Models;
using Keeper.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CodeWorks.Auth0Provider;
using System.Threading.Tasks;

namespace Keeper.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ProfilesController : ControllerBase
    {
        private readonly KeepsService _keepsService;
        private readonly VaultsService _vaultsService;
        private readonly AccountService _accountService;
        public ProfilesController(KeepsService keepsService, AccountService accountService, VaultsService vaultsService)
        {
            _keepsService = keepsService;
            _accountService = accountService;
            _vaultsService = vaultsService;
        }

        [HttpGet("{id}")]
        public ActionResult<Profile> GetProfile(string id)
        {
            try
            {
                Profile profile = _accountService.GetProfile(id);
                return Ok(profile);
            }
            catch (System.Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        [HttpGet("{id}/keeps")]
        public ActionResult<List<Keep>> GetProfileKeeps(string id)
        {
           try
           {
                List<Keep> keeps = _keepsService.GetProfileKeeps(id);
                return Ok(keeps);
            }
           catch (System.Exception error)
           {

                return BadRequest(error.Message);
            }
        }

             [HttpGet("{id}/vaults")]
        public async Task<ActionResult<List<Vault>>> GetProfileVaults(string id)
        {
           try
           {
               Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                List<Vault> vaults = _vaultsService.GetProfileVaults(userInfo?.Id, id);
                return Ok(vaults);
            }
           catch (System.Exception error)
           {

                return BadRequest(error.Message);
            }
        }

    }
}