using Cosmos_DataAccess.Data;
using Cosmos_DataAccess.DTO;
using Cosmos_DataAccess.IRepository;
using Cosmos_Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos_DataAccess.Repository
{
    public class GalaxyRepository : IGalaxyRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public GalaxyRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(GalaxyDTO galaxyDTO)
        {
            if (galaxyDTO != null)
            {
                var galaxy = new Galaxy
                {
                    Id = Guid.NewGuid(),
                    Name = galaxyDTO.Name,
                    Description = galaxyDTO.Description
                };
                _dbContext.Galaxies.Add(galaxy);
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteById(Guid id)
        {
            var galaxy = _dbContext.Galaxies.FirstOrDefaultAsync(x => x.Id == id);

            if (galaxy.Result != null)
            {
                _dbContext.Galaxies.Remove(galaxy.Result);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<List<GalaxyDTO>> GetAll()
        {
            var galaxies = await _dbContext.Galaxies.ToListAsync();
            return galaxies.Select(x => new GalaxyDTO
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            }).ToList();
        }

        public async Task<GalaxyDTO> GetById(Guid id)
        {
            var galaxy = await _dbContext.Galaxies
                        .FirstOrDefaultAsync(x => x.Id == id);

            if (galaxy != null)
            {
                return new GalaxyDTO
                {
                    Id = galaxy.Id,
                    Name = galaxy.Name,
                    Description = galaxy.Description
                };
            }

            return new();
        }

        public async Task<bool> Update(GalaxyDTO galaxyDTO)
        {
            var galaxy = await _dbContext.Galaxies.FirstOrDefaultAsync(x => x.Id == galaxyDTO.Id);
            if (galaxy != null)
            {
                galaxy.Name = galaxyDTO.Name;
                galaxy.Description = galaxyDTO.Description;
                _dbContext.Galaxies.Update(galaxy);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
