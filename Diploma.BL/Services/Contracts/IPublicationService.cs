using Diploma.BL.Models;

namespace Diploma.BL.Services.Contracts
{
    public interface IPublicationService
    {
        public Task Add(PublicationModel model);
    }
}
