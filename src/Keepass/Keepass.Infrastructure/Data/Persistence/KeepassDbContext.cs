using Keepass.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Keepass.Infrastructure.Data.Persistence
{
    public class KeepassDbContext : DbContext
    {
        public KeepassDbContext(DbContextOptions options)
            : base (options)
        {
        }

        public DbSet<Secret> Secrets { get; set; }
    }
}
