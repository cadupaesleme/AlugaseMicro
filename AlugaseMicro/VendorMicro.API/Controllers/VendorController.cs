using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VendorMicro.Domain.Interfaces;
using VendorMicro.Domain.VendorAggregate;
using VendorMicro.Infrastructure.Contexts;

namespace VendorMicro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private readonly IVendorService _vendorService;

        public VendorController(IVendorService vendorService)
        {
            _vendorService = vendorService;
        }

        // GET: api/Vendor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vendor>>> GetVendors()
        {
            return Ok(_vendorService.ReadAll());
        }

        // GET: api/Vendor/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Vendor>> GetVendor(Guid id)
        //{
        //    var vendor = await _context.Vendors.FindAsync(id);

        //    if (vendor == null)
        //    {
        //        return NotFound();
        //    }

        //    return vendor;
        //}

        //// PUT: api/Vendor/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutVendor(Guid id, Vendor vendor)
        //{
        //    if (id != vendor.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(vendor).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!VendorExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Vendor
        [HttpPost]
        public async Task<ActionResult<Vendor>> PostVendor(Vendor vendor)
        {
            _vendorService.Create(vendor);
            _vendorService.Complete();

            return CreatedAtAction("GetVendors", null);
        }

        //// DELETE: api/Vendor/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Vendor>> DeleteVendor(Guid id)
        //{
        //    var vendor = await _context.Vendors.FindAsync(id);
        //    if (vendor == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Vendors.Remove(vendor);
        //    await _context.SaveChangesAsync();

        //    return vendor;
        //}

        //private bool VendorExists(Guid id)
        //{
        //    return _context.Vendors.Any(e => e.Id == id);
        //}
    }
}
