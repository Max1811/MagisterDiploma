using LoginForm.DataAccess.Entities;
using LoginForm.DataAccess.Entities.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LoginForm.DataAccess
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }

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
