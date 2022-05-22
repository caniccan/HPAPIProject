using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HP.Business;
using HP.DataTransferObjects.Responses;
using HP.DataTransferObjects.Requests;
using HPAPI.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Caching.Memory;
using HPAPI.Models;

namespace HPAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService service;
        private readonly IMemoryCache memoryCache;

        public CharacterController(ICharacterService characterService, IMemoryCache memoryCache)
        {
            service = characterService;
            this.memoryCache = memoryCache;
        }

        private DateTime cacheTime = DateTime.Now;

        [HttpGet]
        //[Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetCharacters()
        {

            if (!memoryCache.TryGetValue("characterCache",out CacheProofModel proof))
            {
                var entryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(5))
                                                              .RegisterPostEvictionCallback((key, value, reason, state) =>
                                                              {
                                                                  // memory cache içerisinden bir data çıkarıldığında
                                                                  // çalışmasını istediğiniz işlemleri yazacaksınız.
                                                              });


                memoryCache.Set("characterCache",new CacheProofModel { Characters = await service.GetCharacters(), CacheTime = DateTime.Now },DateTime.Now.AddMinutes(1));
                proof =new CacheProofModel { Characters = await service.GetCharacters(), CacheTime = DateTime.Now };
                
            }


            return Ok(proof);
        }
        [HttpGet("{id}")]
        [IsExists]
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
        [Authorize(Roles ="Admin")]
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
                if (ModelState.IsValid)
                {
                    await service.UpdateCharacter(request);
                    return Ok();
                }
                return BadRequest(ModelState);
        }
        [HttpDelete("{id}")]
        [CustomException(Order =1)]
        [IsExists(Order =2)]
        public async Task<IActionResult> Delete(int id)
        {
            if (id<0 || id>200)
            {
                throw new ArgumentException("id degeri negatif olamaz!");
            }
            throw new NotImplementedException("Ürün silme işlemi tamamlanmadı");
            await service.DeleteCharacter(id);
            return Ok();
        }

    } 
}
