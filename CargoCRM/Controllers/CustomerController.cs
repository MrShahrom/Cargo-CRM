using CargoCRM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CargoCRM.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerContoller : ControllerBase
    {
        private static readonly Customer[] Customers =
        [
            new Customer
            {
                Id = 1,
                FirstName = "John",
                LastName = "Smith",
                Phone = "555-555-5555",
            },
            new Customer
            {
                Id = 2,
                FirstName = "Jane",
                LastName = "Doe",
                Phone = "555-555-5555",
            }
        ];

        [HttpGet(Name = "GetAllCustomers")]
        public IEnumerable<Customer> GetAllCustomers()
        {
            return Customers;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var customer = Customers.FirstOrDefault(x => x.Id == id);
            if (customer is null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        public IActionResult Test()
        {
            return Ok("Test Post");
        }

        [HttpPut]
        public IActionResult TestPut()
        {
            return Ok("Test Updated");
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok("Test Deleted");
        }
    }
}

