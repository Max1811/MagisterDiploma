using Diploma.DataAccess.Entities;
using Diploma.DataAccess.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Diploma.DataAccess.Repositories
{
    public class ConferenceRepository : GenericRepository<Conference>, IConferenceRepository
    {
        private DataContext _dataContext;

        public ConferenceRepository(DataContext context)
            :base(context)
        {
            _dataContext = context;
        }

        public async Task<IEnumerable<ConferenceType>> GetConferenceTypes(string? filter)
        {
            Expression<Func<ConferenceType, bool>> predicate = string.IsNullOrEmpty(filter) ? p => true : p => p.Type.Contains(filter);

            return await _dataContext.ConferenceTypes
                .Where(predicate)
                .OrderByDescending(p => p.CreatedDate)
                .ToListAsync();
        }

        public async Task AddConferenceType(ConferenceType type)
        {
            if (!_dataContext.ConferenceTypes.Any(t => t.Type == type.Type))
            {
                await _dataContext.ConferenceTypes.AddAsync(type);
                await _dataContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Conference>> GetConferences(string? filter)
        {
            Expression<Func<Conference, bool>> predicate = string.IsNullOrEmpty(filter)
                ? p => true
                : p => p.Name.Contains(filter)
                    || p.ConferenceCity.Contains(filter)
                    || p.ConferenceType.Type.Contains(filter);

            return await _dataContext.Conferences
                .Where(predicate)
                .OrderByDescending(p => p.CreatedDate)
                .ToListAsync();
        }

        public async Task AddConference(Conference conference)
        {
            if (!_dataContext.Conferences.Any(c => c.Name == conference.Name))
            {
                await AddAsync(conference);
                await _dataContext.SaveChangesAsync();
            }
        }
    }
}
