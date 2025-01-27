namespace Keepass.Infrastructure.Data.Persistence
{
    public class KeepassDbContext : DbContext
    {
        public KeepassDbContext()
        {
            
        }

        public KeepassDbContext(DbContextOptions options)
            : base (options)
        {
        }

        public DbSet<Secret> Secrets { get; set; } = default!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Keepass.db");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(KeepassDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
