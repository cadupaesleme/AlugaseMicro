using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure;
using Microsoft.EntityFrameworkCore;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;
using RentMicro.API.Interfaces;
using RentMicro.API.Models;
using RentMicro.Domain.Interfaces;
using RentMicro.Infrastructure.Contexts;

namespace RentMicro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentController : ControllerBase
    {
        private readonly IRentAppService _RentAppService;
        private readonly IRentItemAppService _RentItemAppService;

        public RentController(IRentAppService RentAppService, IRentItemAppService RentItemAppService)
        {
            _RentAppService = RentAppService;
            _RentItemAppService = RentItemAppService;
        }

        // GET: api/Rent
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RentViewModel>>> GetRents()
        {
            return Ok(_RentAppService.ReadAll());
        }

        // GET: api/Rent/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RentViewModel>> GetRent(Guid id)
        {
            return Ok(_RentAppService.Read(id));
        }

        // PUT: api/Rent/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRent(Guid id, RentItemViewModel Rent)
        {
            if (id != Rent.Id)
            {
                return BadRequest();
            }

            try
            {
                _RentItemAppService.Update(Rent);
                return Ok(Rent);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            //return NoContent();
        }

        // POST: api/Rent
        [HttpPost]
        public async Task<ActionResult<RentViewModel>> PostRent(RentViewModel Rent)
        {

           
            _RentAppService.Create(Rent);
            return Ok(Rent);
        }

        // DELETE: api/Rent/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RentItemViewModel>> DeleteRent(Guid id)
        {
            if (!RentItemExists(id))
            {
                return NotFound();
            }

            _RentItemAppService.Delete(id);
            return Ok("Deletado");
        }

        private bool RentExists(Guid id)
        {
            return _RentAppService.Read(id) != null;
        }
        private bool RentItemExists(Guid id)
        {
            return _RentItemAppService.Read(id) != null;
        }
    }
}
