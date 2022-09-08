using Cosmos_ApplicationServices.IServices;
using Cosmos_DataAccess.DTO;
using Cosmos_DataAccess.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos_ApplicationServices.Services
{
    public class GalaxyService : IGalaxyService
    {
        private readonly IGalaxyRepository _galaxyRepository;

        public GalaxyService(IGalaxyRepository galaxyRepository)
        {
            _galaxyRepository = galaxyRepository;
        }
        public async Task Create(GalaxyDTO galaxyDTO)
        {
            await _galaxyRepository.Create(galaxyDTO);
        }

        public async Task<bool> DeleteById(Guid id)
        {
            return await _galaxyRepository.DeleteById(id);
        }

        public async Task<List<GalaxyDTO>> GetAll()
        {
            return await _galaxyRepository.GetAll();
        }

        public async Task<GalaxyDTO> GetById(Guid id)
        {
            return await _galaxyRepository.GetById(id);
        }

        public async Task<bool> Update(GalaxyDTO galaxyDTO)
        {
            return await _galaxyRepository.Update(galaxyDTO);
        }
    }
}
