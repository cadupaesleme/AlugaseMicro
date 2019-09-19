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
using VendorMicro.API.Interfaces;
using VendorMicro.API.Models;
using VendorMicro.Domain.Interfaces;
using VendorMicro.Infrastructure.Contexts;

namespace VendorMicro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private readonly IVendorAppService _vendorAppService;

        public VendorController(IVendorAppService vendorAppService)
        {
            _vendorAppService = vendorAppService;
        }

        // GET: api/Vendor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VendorViewModel>>> GetVendors()
        {
            //teste fila
            Add_Queue();

            return Ok(_vendorAppService.ReadAll());
        }

        // GET: api/Vendor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VendorViewModel>> GetVendor(Guid id)
        {
            return Ok(_vendorAppService.Read(id));
        }

        // PUT: api/Vendor/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVendor(Guid id, VendorViewModel vendor)
        {
            if (id != vendor.Id)
            {
                return BadRequest();
            }

            try
            {
                _vendorAppService.Update(vendor);
                return Ok(vendor);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendorExists(id))
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

        // POST: api/Vendor
        [HttpPost]
        public async Task<ActionResult<VendorViewModel>> PostVendor(VendorViewModel vendor)
        {
            _vendorAppService.Create(vendor);
            return Ok(vendor);
        }

        // DELETE: api/Vendor/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VendorViewModel>> DeleteVendor(Guid id)
        {
            if (!VendorExists(id))
            {
                return NotFound();
            }

            _vendorAppService.Delete(id);
            return Ok("Deletado");
        }

        private bool VendorExists(Guid id)
        {
            return _vendorAppService.Read(id) != null;
        }
    }
}
