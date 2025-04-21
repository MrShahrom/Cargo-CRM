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
    }
}

