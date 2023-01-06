using Diploma.DataAccess.Entities;
using Diploma.DataAccess.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Diploma.DataAccess.Repositories
{
    public class DigestRepository: GenericRepository<Digest>, IDigestRepository
    {
        private DataContext _dataContext;

        public DigestRepository(DataContext dataContext)
            :base(dataContext)
        {
            _dataContext = dataContext; 
        }

        public async Task<IEnumerable<Digest>> GetDigests(string? filter)
        {
            Expression<Func<Digest, bool>> predicate = string.IsNullOrEmpty(filter) ? p => true : p => p.Name.Contains(filter) || p.Type.Contains(filter);

            return await _dataContext.Digests
                .Where(predicate)
                .OrderByDescending(p => p.CreatedDate)
                .ToListAsync();
        }

        public async Task AddDigest(Digest digest)
        {
            if (!_dataContext.Digests.Any(d => d.Name == digest.Name))
            {
                await AddAsync(digest);
                await _dataContext.SaveChangesAsync();
            }
        }
    }
}
