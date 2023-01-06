using Diploma.DataAccess.Entities;

namespace Diploma.DataAccess.Repositories.Contracts
{
    public interface IConferenceRepository: IGenericRepository<Conference>
    {
        public Task<IEnumerable<ConferenceType>> GetConferenceTypes(string? filter);

        public Task AddConferenceType(ConferenceType type);

        public Task<IEnumerable<Conference>> GetConferences(string? filter);

        public Task AddConference(Conference conference);
    }
}
