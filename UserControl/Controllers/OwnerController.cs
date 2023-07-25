
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Contracts;
using ServiceLayer.DataTransferObjects;

namespace PresentationLayer.Controllers
{
    [Route("api/owners")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IServiceManager _service;

        public OwnerController(IServiceManager service) => _service = service;

        [HttpGet]
        public IActionResult GetAllOwners()
        {
            var owners = _service.OwnerService.GetAllOwners();
            return Ok(owners);
        }

        [HttpGet("{id:long}", Name = "GetOwnerById")]
        public IActionResult GetOwnerById(long id)
        {
            var owner = _service.OwnerService.GetOwnerById(id);
            return Ok(owner);
        }

        [HttpPost]
        public IActionResult CreateOwner([FromBody] OwnerCreateDto owner)
        {
            if (owner is null)
                return BadRequest("Owner object is null");

            var ownerResponse = _service.OwnerService.CreateOwner(owner);

            return CreatedAtRoute("GetOwnerById", new { id = ownerResponse.Id }, ownerResponse);
        }
    }
}
