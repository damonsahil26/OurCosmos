using Cosmos_API.Data;
using Cosmos_API.Models;
using Cosmos_API.Repository.IRepository;
using Cosmos_DataAccess.DTO;
using Microsoft.EntityFrameworkCore;

namespace Cosmos_API.Repository
{
    public class PlanetRepository : IPlanetRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PlanetRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(PlanetDTO PlanetDTO)
        {
            if (PlanetDTO != null)
            {
                var planet = new Planet
                {
                    Id = Guid.NewGuid(),
                    Name = PlanetDTO.Name,
                    Description = PlanetDTO.Description
                };
                _dbContext.Planets.Add(planet);
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteById(Guid id)
        {
            var planet = _dbContext.Planets.FirstOrDefaultAsync(x => x.Id == id);

            if (planet.Result != null)
            {
                _dbContext.Planets.Remove(planet.Result);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<List<PlanetDTO>> GetAll()
        {
            var Planets = await _dbContext.Planets.ToListAsync();
            return Planets.Select(x => new PlanetDTO
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            }).ToList();
        }

        public async Task<PlanetDTO> GetById(Guid id)
        {
            var planet = await _dbContext.Planets
                        .FirstOrDefaultAsync(x => x.Id == id);

            if (planet != null)
            {
                return new PlanetDTO
                {
                    Id = planet.Id,
                    Name = planet.Name,
                    Description = planet.Description
                };
            }

            return new();
        }

        public async Task<bool> Update(PlanetDTO PlanetDTO)
        {
            var planet = await _dbContext.Planets.FirstOrDefaultAsync(x => x.Id == PlanetDTO.Id);
            if (planet != null)
            {
                planet.Name = PlanetDTO.Name;
                planet.Description = PlanetDTO.Description;
                _dbContext.Planets.Update(planet);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}