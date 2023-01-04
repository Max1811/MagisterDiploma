using Diploma.DataAccess.Entities;
using Diploma.DataAccess.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Diploma.DataAccess.Repositories
{
    public class PublicationTypeRepository : GenericRepository<PublicationType>, IPublicationTypeRepository
    {
        private DataContext _dataContext;

        public PublicationTypeRepository(DataContext dataContext)
            : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddPublicationType(PublicationType type)
        {
            if(!_dataContext.PublicationTypes.Any(t => t.Type == type.Type))
            {
                await AddAsync(type);
            }
        }

        public async Task<IEnumerable<PublicationType>> GetPublicationTypes(string? filter)
        {
            Expression<Func<PublicationType, bool>> predicate = string.IsNullOrEmpty(filter) ? p => true : p => p.Type.Contains(filter);

            return await _dataContext.PublicationTypes
                .Where(predicate)
                .OrderByDescending(p => p.CreatedDate)
                .ToListAsync();
        }
    }
}
