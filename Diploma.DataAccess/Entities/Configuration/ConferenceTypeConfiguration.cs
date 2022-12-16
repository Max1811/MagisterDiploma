using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diploma.DataAccess.Entities.Configuration
{
    public class ConferenceTypeConfiguration : IEntityTypeConfiguration<ConferenceType>
    {
        public void Configure(EntityTypeBuilder<ConferenceType> builder)
        {
            builder.ToTable("ConferenceTypes");
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Conferences)
                .WithOne(x => x.ConferenceType)
                .HasForeignKey(x => x.ConferenceTypeId);
        }
    }
}
