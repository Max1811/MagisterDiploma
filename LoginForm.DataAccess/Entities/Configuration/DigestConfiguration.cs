using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoginForm.DataAccess.Entities.Configuration
{
    public class DigestConfiguration : IEntityTypeConfiguration<Digest>
    {
        public void Configure(EntityTypeBuilder<Digest> builder)
        {
            builder.ToTable("Digests");
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Publications)
                .WithOne(x => x.Digest)
                .HasForeignKey(x => x.DigestId);
        }
    }
}
