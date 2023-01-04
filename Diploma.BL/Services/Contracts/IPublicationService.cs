using Diploma.BL.Models;

namespace Diploma.BL.Services.Contracts
{
    public interface IPublicationService
    {
        public Task AddAsync(PublicationModel model);

        public Task AddPublicationType(string publicationType);

        public Task<IEnumerable<PublicationTypeModel>> GetPublicationTypes(string? filter);
    }
}
