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
        public async Task<IActionResult> GetPets(long ownerId)
        {
            var pets = await _service.PetService.GetPets(ownerId);
            return Ok(pets);
        }

        [HttpGet("{id:long}", Name = "GetPetById")]
        public async Task<IActionResult> GetPetById(long ownerId, long id)
        {
            var pet = await _service.PetService.GetPetById(ownerId, id);

            return Ok(pet);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePet(long ownerId, [FromBody] PetCreateDto pet)
        {
            if (pet is null)
                return BadRequest("Pet object is null");

            var petResponse = await _service.PetService.CreatePet(ownerId, pet);

            return CreatedAtRoute("GetPetById", new { ownerId = petResponse.OwnerId, id = petResponse.Id }, petResponse);
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> UpdatePet(long ownerId, long id, [FromBody] PetUpdateDto pet)
        {
            if (pet is null)
                return BadRequest("Pet object is null");

            await _service.PetService.UpdatePet(ownerId, id, pet, false, true);

            return NoContent();
        }
    }
}
