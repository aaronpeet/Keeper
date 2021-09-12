using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Keeper.Models;
using Keeper.Services;
using System;

namespace Keeper.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class VaultsController : ControllerBase
    {
        private readonly VaultsService _vaultsService;
        public VaultsController(VaultsService vaultsService)
        {
            _vaultsService = vaultsService;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Vault>> Create([FromBody]Vault newVault)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                newVault.CreatorId = userInfo.Id;
                Vault vault = _vaultsService.Create(newVault);
                return Ok(vault);
            }
            catch (System.Exception error)
            {

                return BadRequest(error.Message);
            }
        }


           [HttpGet("{id}")]
        public ActionResult<Vault> GetById(int id)
        {
            try
            {
                Vault vault = _vaultsService.GetById(id);
                return Ok(vault);
            }
            catch (System.Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<String>> Delete(int id)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                _vaultsService.Delete(id, userInfo.Id);
                return Ok("DELORTED!");
            }
            catch (System.Exception error)
            {

                return BadRequest(error.Message);
            }
        }
    }
}