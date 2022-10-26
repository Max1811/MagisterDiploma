using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoginForm.DataAccess.Entities.Configuration
{
    public class PublicationAuthorConfiguration : IEntityTypeConfiguration<PublicationAuthor>
    {
        public void Configure(EntityTypeBuilder<PublicationAuthor> builder)
        {
            builder.ToTable("PublicationAuthors");
            builder.HasKey(x => new { x.PublicationId, x.AuthorId });

            builder.HasOne(x => x.Author)
                .WithMany(x => x.PublicationAuthors)
                .HasForeignKey(x => x.AuthorId);

            builder.HasOne(x => x.Publication)
                .WithMany(x => x.PublicationAuthors)
                .HasForeignKey(x => x.PublicationId);
        }
    }
}
