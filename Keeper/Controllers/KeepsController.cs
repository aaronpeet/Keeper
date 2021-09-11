using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Keeper.Models;
using Keeper.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Keeper.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KeepsController : ControllerBase
    {
        private readonly KeepsService _keepsService;

        public KeepsController(KeepsService keepsService)
        {
            _keepsService = keepsService;
        }

        
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Keep>> Create([FromBody] Keep newKeep)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                newKeep.CreatorId = userInfo.Id;
                Keep keep = _keepsService.Create(newKeep);
                return Ok(keep);
            }
            catch (System.Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        [HttpGet]
        public ActionResult<List<Keep>> Get()
        {
            try
            {
                List<Keep> keeps = _keepsService.Get();
                return Ok(keeps);
            }
            catch (System.Exception error)
            {

                return BadRequest(error.Message);
            }
        }

         [HttpGet("{id}")]
        public ActionResult<Keep> GetById(int id)
        {
            try
            {
                Keep keep = _keepsService.GetById(id);
                return Ok(keep);
            }
            catch (System.Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<Keep>> Edit([FromBody] Keep updatedKeep, int id)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                updatedKeep.CreatorId = userInfo.Id;
                updatedKeep.Id = id;
                Keep keep = _keepsService.Edit(updatedKeep);
                return Ok(keep);
            }
            catch (System.Exception error)
            {

                return BadRequest(error.Message);
            }
        }
    }
}