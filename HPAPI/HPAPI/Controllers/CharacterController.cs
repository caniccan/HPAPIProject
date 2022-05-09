using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HP.Business;
using HP.DataTransferObjects.Responses;
using HP.DataTransferObjects.Requests;
using HPAPI.Filters;

namespace HPAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService service;
        public CharacterController(ICharacterService characterService)
        {
            service = characterService;
        }
        [HttpGet]
        public async Task<IActionResult> GetCharacters()
        {
            var characters = await service.GetCharacters();
            return Ok(characters);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCharacterById(int id)
        {
            CharacterDisplayResponse character = await service.GetCharacter(id);
            return Ok(character);
        }
        [HttpGet("Search/{key}")]
        public async Task<IActionResult> Search(string key)
        {
            var response = await service.GetCharactersByName(key);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddCharacterRequest request)
        {
            if (ModelState.IsValid)
            {
                int characterId = await service.AddCharacter(request);
                return CreatedAtAction(nameof(GetCharacterById), routeValues: new { id = characterId }, value: null);
            }
            return BadRequest(ModelState);
        }
        [HttpPut("{id}")]
        [IsExists]
        public async Task<IActionResult> Update(int id, UpdateCharacterRequest request)
        {
            //if (await service.IsCharacterExists(id))
            //{ 
                if (ModelState.IsValid)
                {
                    await service.UpdateCharacter(request);
                    return Ok();
                }
                return BadRequest(ModelState);
            //}
            //return NotFound(new { message = $"{id} id'li karakter bulunamadı." });
        }
        [HttpDelete("{id}")]
        [IsExists]
        public async Task<IActionResult> Delete(int id)
        {
                await service.DeleteCharacter(id);
                return Ok();
        }

    } 
}
