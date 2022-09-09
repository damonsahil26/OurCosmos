using Cosmos_DataAccess.DTO;

namespace Cosmos_API.Repository.IRepository
{
    public interface IPlanetRepository
    {
        Task Create(PlanetDTO galaxyDTO);

        Task<bool> Update(PlanetDTO galaxyDTO);

        Task<List<PlanetDTO>> GetAll();

        Task<PlanetDTO> GetById(Guid id);

        Task<bool> DeleteById(Guid id);
    }
}
