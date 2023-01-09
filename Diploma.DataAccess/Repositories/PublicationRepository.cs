using Diploma.DataAccess.Entities;
using Diploma.DataAccess.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Diploma.DataAccess.Repositories
{
    public class PublicationRepository: GenericRepository<Publication>, IPublicationRepository
    {
        private DataContext _dataContext;

        public PublicationRepository(DataContext dataContext)
            : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<Publication>> GetPublications(string? filter)
        {
            return await _dataContext
                .Publications
                .Include(p => p.Conference)
                .Include(p => p.Digest)
                .Include(p => p.Type)
                .Include(p => p.PublicationAuthors)
                .ToListAsync();
        }
    }
}
