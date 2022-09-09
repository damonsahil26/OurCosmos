using Cosmos_API.Repository.IRepository;
using Cosmos_API.Services.IService;
using Cosmos_DataAccess.DTO;

namespace Cosmos_API.Services
{
    public class PlanetService : IPlanetService
    {
        private readonly IPlanetRepository _planetRepository;

        public PlanetService(IPlanetRepository planetRepository)
        {
            _planetRepository = planetRepository;
        }

        public async Task Create(PlanetDTO planetDTO)
        {
            await _planetRepository.Create(planetDTO);
        }

        public async Task<bool> DeleteById(Guid id)
        {
            return await _planetRepository.DeleteById(id);
        }

        public async Task<List<PlanetDTO>> GetAll()
        {
            return await _planetRepository.GetAll();
        }

        public async Task<PlanetDTO> GetById(Guid id)
        {
            return await _planetRepository.GetById(id);
        }

        public async Task<bool> Update(PlanetDTO planetDTO)
        {
            return await _planetRepository.Update(planetDTO);
        }
    }
}
