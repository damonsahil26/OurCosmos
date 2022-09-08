using Cosmos_DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos_ApplicationServices.IServices
{
    public interface IGalaxyService
    {
        Task Create(GalaxyDTO galaxyDTO);

        Task<bool> Update(GalaxyDTO galaxyDTO);

        Task<List<GalaxyDTO>> GetAll();

        Task<GalaxyDTO> GetById(Guid id);

        Task<bool> DeleteById(Guid id);
    }
}
