using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Contracts;
using ServiceLayer.DataTransferObjects;

namespace PresentationLayer.Controllers
{
    [Route("api/owners/{ownerId}/pets")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IServiceManager _service;

        public PetController(IServiceManager service) => _service = service;

        [HttpGet]
        public IActionResult GetPets(long ownerId)
        {
            var pets = _service.PetService.GetPets(ownerId);
            return Ok(pets);
        }

        [HttpGet("{id:long}", Name = "GetPetById")]
        public IActionResult GetPetById(long ownerId, long id)
        {
            var pet = _service.PetService.GetPetById(ownerId, id);

            return Ok(pet);
        }

        [HttpPost]
        public IActionResult CreatePet(long ownerId, [FromBody] PetCreateDto pet)
        {
            if (pet is null)
                return BadRequest("Pet object is null");

            var petResponse = _service.PetService.CreatePet(ownerId, pet);

            return CreatedAtRoute("GetPetById", new { ownerId = petResponse.OwnerId, id = petResponse.Id }, petResponse);
        }
    }
}
