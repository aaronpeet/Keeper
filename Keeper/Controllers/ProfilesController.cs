using Keeper.Models;
using Keeper.Services;
using Microsoft.AspNetCore.Mvc;

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

    }
}