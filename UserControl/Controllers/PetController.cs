using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Contracts;

namespace PresentationLayer.Controllers
{
    [Route("api/pets")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IServiceManager _service;

        public PetController(IServiceManager service) => _service = service;

        [HttpGet]
        public IActionResult GetAllPets()
        {
            var pets = _service.PetService.GetAllPets();
            return Ok(pets);
        }

        [HttpGet("{id:long}")]
        public IActionResult GetPetById(long id)
        {
            var pet = _service.PetService.GetPetById(id);
            return Ok(pet);
        }

        [HttpGet("owner/{ownerId:long}")]
        public IActionResult GetPetsByOwnerId(long ownerId)
        {
            var pets = _service.PetService.GetPetsByOwnerId(ownerId);
            return Ok(pets);
        }
    }
}
