using Diploma.DataAccess.Entities;
using Diploma.DataAccess.Entities.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Diploma.DataAccess
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Author> Authors { get; set; }
        
        public DbSet<Publication> Publications { get; set; }

        public DbSet<AuthorType> AuthorTypes { get; set; }

        public DbSet<Conference> Conferences { get; set; }

        public DbSet<ConferenceType> ConferenceTypes { get; set; }

        public DbSet<Digest> Digests { get; set; }

        public DbSet<PublicationAuthor> PublicationAuthors { get; set; }

        public DbSet<PublicationType> PublicationTypes { get; set; }

        public DataContext() { }

        public DataContext(DbContextOptions options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration())
                .ApplyConfiguration(new PublicationConfiguration())
                .ApplyConfiguration(new AuthorConfiguration())
                .ApplyConfiguration(new AuthorTypeConfiguration())
                .ApplyConfiguration(new PublicationTypeConfiguration())
                .ApplyConfiguration(new ConferenceConfiguration())
                .ApplyConfiguration(new ConferenceTypeConfiguration())
                .ApplyConfiguration(new DigestConfiguration())
                .ApplyConfiguration(new PublicationAuthorConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("MSSQLLocalConnectionString");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
