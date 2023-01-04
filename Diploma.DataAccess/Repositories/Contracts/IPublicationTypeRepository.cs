using Diploma.DataAccess.Entities;

namespace Diploma.DataAccess.Repositories.Contracts
{
    public interface IPublicationTypeRepository: IGenericRepository<PublicationType>
    {
        public Task<IEnumerable<PublicationType>> GetPublicationTypes(string? filter);

        public Task AddPublicationType(PublicationType type);
    }
}
