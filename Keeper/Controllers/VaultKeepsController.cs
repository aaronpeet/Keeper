using System.Threading.Tasks;
using Keeper.Models;
using Keeper.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Keeper.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    [Authorize]
    public class VaultKeepsController : ControllerBase
    {
        private readonly VaultKeepsService _vaultKeepsService;
        public VaultKeepsController(VaultKeepsService vaultKeepsService)
        {
            _vaultKeepsService = vaultKeepsService;
        }

        [HttpPost]
        public async Task<ActionResult<VaultKeep>> Create([FromBody]VaultKeep newVaultKeep)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                newVaultKeep.CreatorId = userInfo.Id;
                VaultKeep vaultKeep = _vaultKeepsService.Create(newVaultKeep);
                return Ok(vaultKeep);
            }
            catch (System.Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<String>> Delete(int id)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                _vaultKeepsService.Delete(id, userInfo.Id);
                return Ok("DELORTED!");
            }
            catch (System.Exception error)
            {

                return BadRequest(error.Message);
            }
        }

    }
}