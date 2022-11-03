using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diploma.DataAccess.Entities.Configuration
{
    public class AuthorTypeConfiguration : IEntityTypeConfiguration<AuthorType>
    {
        public void Configure(EntityTypeBuilder<AuthorType> builder)
        {
            builder.ToTable("AuthorTypes");
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Authors)
                .WithOne(x => x.AuthorType)
                .HasForeignKey(x => x.AuthorTypeId);
        }
    }
}
