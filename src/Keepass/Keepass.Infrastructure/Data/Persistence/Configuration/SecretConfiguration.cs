using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Keepass.Infrastructure.Data.Persistence.Configuration
{
    internal class SecretConfiguration : IEntityTypeConfiguration<Secret>
    {
        public void Configure(EntityTypeBuilder<Secret> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
