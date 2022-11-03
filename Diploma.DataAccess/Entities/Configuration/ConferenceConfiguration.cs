using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diploma.DataAccess.Entities.Configuration
{
    public class ConferenceConfiguration : IEntityTypeConfiguration<Conference>
    {
        public void Configure(EntityTypeBuilder<Conference> builder)
        {
            builder.ToTable("Conferentions");
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Publications)
                .WithOne(x => x.Conference)
                .HasForeignKey(x => x.ConferenceId);

            builder.HasOne(x => x.ConferenceType)
                .WithMany(x => x.Conferences)
                .HasForeignKey(x => x.ConferenceTypeId);
        }
    }
}
