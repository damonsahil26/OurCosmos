using Cosmos_API.Services.IService;
using Cosmos_DataAccess.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Cosmos_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlanetController : Controller
    {
        private readonly IPlanetService _planetService;

        public PlanetController(IPlanetService planetService)
        {
            _planetService = planetService;
        }

        [HttpGet(Name = "GetAllPlanets")]
        public async Task<List<PlanetDTO>> GetAllPlanets()
        {
            return await _planetService.GetAll();
        }

        [HttpGet("id")]
        public async Task<PlanetDTO> GetPlanet(Guid id)
        {
            return await _planetService.GetById(id);
        }

        [HttpPost]
        public async Task Create([FromBody] PlanetDTO planetDTO)
        {
            await _planetService.Create(planetDTO);
        }

        [HttpDelete("id")]
        public async Task<bool> Delete(Guid id)
        {
            return await _planetService.DeleteById(id);
        }

        [HttpPut]
        public async Task<bool> Update([FromBody] PlanetDTO planetDTO)
        {
            return await _planetService.Update(planetDTO);
        }
    }
}
