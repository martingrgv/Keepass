namespace Keepass.Infrastructure.Data.Persistence
{
    public class KeepassDbContext : DbContext
    {
        public KeepassDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Secret> Secrets { get; set; } = default!;
        public DbSet<User> Users { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(KeepassDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
