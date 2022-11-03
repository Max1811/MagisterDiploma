using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diploma.DataAccess.Entities.Configuration
{
    public class PublicationTypeConfiguration : IEntityTypeConfiguration<PublicationType>
    {
        public void Configure(EntityTypeBuilder<PublicationType> builder)
        {
            builder.ToTable("PublicationTypes");
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Publications)
                .WithOne(x => x.Type)
                .HasForeignKey(x => x.TypeId);
        }
    }
}
