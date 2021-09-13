using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Keeper.Models;
using Keeper.Services;
using System;
using System.Collections.Generic;

namespace Keeper.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class VaultsController : ControllerBase
    {
        private readonly VaultsService _vaultsService;
        private readonly KeepsService _keepsService;
        public VaultsController(VaultsService vaultsService, KeepsService keepsService)
        {
            _vaultsService = vaultsService;
            _keepsService = keepsService;
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
                if(vault.IsPrivate != false)
                {
                    return BadRequest("This vault is private");
                }
                return Ok(vault);
            }
            catch (System.Exception error)
            {

                return BadRequest(error.Message);
            }
        }

               [HttpGet("{id}/keeps")]
        public ActionResult<List<VaultKeepViewModel>> GetKeeps(int id)
        {
            try
            {
                List<VaultKeepViewModel> keeps = _keepsService.GetByVaultId(id);
                return Ok(keeps);
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

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<Vault>> Edit([FromBody]Vault updatedVault, int id)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                updatedVault.CreatorId = userInfo.Id;
                updatedVault.Id = id;
                Vault vault = _vaultsService.Edit(updatedVault);
                return Ok(vault);
            }
            catch (System.Exception error)
            {

                return BadRequest(error.Message);
            }
        }
    }
}