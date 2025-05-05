using CargoCRM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CargoCRM.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageContoller : ControllerBase
    {
        private static readonly Package[] Packages =
        [
            new Package
            {
                Id = 1,
                Name = "Cargo01",
                Id_trackcode = 1,
                Is_sent = true,
                Date_from = "01/01/2020 00:00:00",
                Date_to = "01/01/2020 23:59:59",
            },
            new Package
            {
                Id = 2,
                Name = "Cargo02",
                Id_trackcode = 2,
                Is_sent = true,
                Date_from = "01/01/2020 00:00:00",
                Date_to = "01/01/2020 23:59:59",
            }
        ];

        [HttpGet(Name = "GetAllPackages")]
        public IEnumerable<Package> GetAllPackages()
        {
            return Packages;
        }
        
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var package = Packages.FirstOrDefault(x => x.Id == id);
            if (package is null)
            {
                return NotFound();
            }
            return Ok(package);
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

