
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Contracts;

namespace PresentationLayer.Controllers
{
    [Route("api/owners")]
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

        [HttpGet("id:long")]
        public IActionResult GetOwnerById(long id)
        {
            var owner = _service.OwnerService.GetOwnerById(id);
            return Ok(owner);
        }
    }
}
