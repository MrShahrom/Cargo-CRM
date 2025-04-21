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
    }
}

