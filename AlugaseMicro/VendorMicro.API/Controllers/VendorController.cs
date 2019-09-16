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
            //teste fila
            Add_Queue();

            return Ok(_vendorService.ReadAll());
        }

        // GET: api/Vendor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vendor>> GetVendor(Guid id)
        {
            return Ok(_vendorService.Read(id));
        }

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

        // DELETE: api/Vendor/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Vendor>> DeleteVendor(Guid id)
        {
            _vendorService.Delete(id);
            return CreatedAtAction("GetVendors", null);
        }

        public void Add_Queue()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=alugasestorage;AccountKey=P4il7lcfc8wdXTe1cQULpzcyp3+i+U9BkjxtJWd6e9zRd8R67aFW7RQTfLv1xp8G8M8RzqBLjMLcdNMibRFZHw==;EndpointSuffix=core.windows.net");         
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();         
            CloudQueue queue = queueClient.GetQueueReference("filateste");         
            queue.CreateIfNotExistsAsync();         
            //CloudQueueMessage message = new CloudQueueMessage("Hello, World");
            CloudQueueMessage message = new CloudQueueMessage(Newtonsoft.Json.JsonConvert.SerializeObject(new Vendor { Id = Guid.NewGuid(), Name = "Fila"}));
            queue.AddMessageAsync(message);
            //Fonte: https://docs.microsoft.com/pt-br/azure/storage/queues/storage-dotnet-how-to-use-queues
        }
        //private bool VendorExists(Guid id)
        //{
        //    return _context.Vendors.Any(e => e.Id == id);
        //}
    }
}
