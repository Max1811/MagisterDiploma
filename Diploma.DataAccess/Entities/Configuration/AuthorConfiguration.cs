using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diploma.DataAccess.Entities.Configuration
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Authors");
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.AuthorType)
                .WithMany(x => x.Authors)
                .HasForeignKey(x => x.AuthorTypeId);
        }
    }
}
