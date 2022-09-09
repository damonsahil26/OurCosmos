using Cosmos_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Cosmos_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Planet> Planets { get; set; }
    }
}
