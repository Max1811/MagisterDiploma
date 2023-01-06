using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diploma.DataAccess.Entities.Configuration
{
    public class PublicationConfiguration : IEntityTypeConfiguration<Publication>
    {
        public void Configure(EntityTypeBuilder<Publication> builder)
        {
            builder.ToTable("Publications");
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Type)
                .WithMany(x => x.Publications)
                .HasForeignKey(x => x.TypeId);

            builder.HasOne(x => x.Conference)
                .WithMany(x => x.Publications)
                .HasForeignKey(x => x.ConferenceId)
                .IsRequired(false);

            builder.HasOne(x => x.Digest)
                .WithMany(x => x.Publications)
                .HasForeignKey(x => x.DigestId)
                .IsRequired(false);
        }
    }
}
