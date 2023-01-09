using Diploma.DataAccess.Entities;

namespace Diploma.DataAccess.Repositories.Contracts
{
    public interface IPublicationRepository : IGenericRepository<Publication>
    {
        public Task<IEnumerable<Publication>> GetPublications(string? filter);
    }
}
