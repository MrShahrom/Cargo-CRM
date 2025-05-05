using CargoCRM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CargoCRM.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackCodeContoller : ControllerBase
    {
        private static readonly TrackCode[] TrackCodes =
        [
            new TrackCode
            {
                Id = 1,
                Name = "GT854841551",
                Id_customer = 1,
                
            },
            new TrackCode
            {
                Id = 2,
                Name = "GT854841552",
                Id_customer = 2,
            }
        ];

        [HttpGet(Name = "GetAllTrackCodes")]
        public IEnumerable<TrackCode> GetAllTrackCodes()
        {
            return TrackCodes;
        }
        
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var trackCode = TrackCodes.FirstOrDefault(x => x.Id == id);
            if (trackCode is null)
            {
                return NotFound();
            }
            return Ok(trackCode);
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

