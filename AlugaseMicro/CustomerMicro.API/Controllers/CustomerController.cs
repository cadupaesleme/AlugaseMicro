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
using CustomerMicro.API.Interfaces;
using CustomerMicro.API.Models;
using CustomerMicro.Domain.Interfaces;
using CustomerMicro.Infrastructure.Contexts;

namespace CustomerMicro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerAppService _CustomerAppService;

        public CustomerController(ICustomerAppService CustomerAppService)
        {
            _CustomerAppService = CustomerAppService;
        }

        // GET: api/Customer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerViewModel>>> GetCustomers()
        {
            //teste fila
            //Add_Queue();

            return Ok(_CustomerAppService.ReadAll());
        }

        // GET: api/Customer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerViewModel>> GetCustomer(Guid id)
        {
            return Ok(_CustomerAppService.Read(id));
        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(Guid id, CustomerViewModel Customer)
        {
            if (id != Customer.Id)
            {
                return BadRequest();
            }

            try
            {
                _CustomerAppService.Update(Customer);
                return Ok(Customer);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
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

        // POST: api/Customer
        [HttpPost]
        public async Task<ActionResult<CustomerViewModel>> PostCustomer(CustomerViewModel Customer)
        {
            _CustomerAppService.Create(Customer);
            return Ok(Customer);
        }

        // DELETE: api/Customer/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CustomerViewModel>> DeleteCustomer(Guid id)
        {
            if (!CustomerExists(id))
            {
                return NotFound();
            }

            _CustomerAppService.Delete(id);
            return Ok("Deletado");
        }

        private bool CustomerExists(Guid id)
        {
            return _CustomerAppService.Read(id) != null;
        }
    }
}
