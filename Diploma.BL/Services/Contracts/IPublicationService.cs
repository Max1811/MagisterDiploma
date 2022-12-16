using Diploma.BL.Models;

namespace Diploma.BL.Services.Contracts
{
    public interface IPublicationService
    {
        public Task AddAsync(PublicationModel model);
    }
}
