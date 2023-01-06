using Diploma.BL.Models;

namespace Diploma.BL.Services.Contracts
{
    public interface IPublicationService
    {
        public Task AddAsync(PublicationModel model);

        public Task AddPublicationType(string publicationType);

        public Task<IEnumerable<PublicationTypeModel>> GetPublicationTypes(string? filter);

        public Task<IEnumerable<ConferenceTypeModel>> GetConferenceTypes(string? filter);

        public Task AddConferenceType(string conferenceType);

        public Task AddConference(ConferenceModel model);

        public Task<IEnumerable<ConferenceModel>> GetConferences(string? filter);

        public Task AddDigest(DigestModel model);

        public Task<IEnumerable<DigestModel>> GetDigests(string? filter);

        public Task AddPublicationAuthor(AuthorModel model);

        public Task<IEnumerable<AuthorModel>> GetPublicationAuthors(string? filter);

        public Task<IEnumerable<AuthorTypeModel>> GetAuthorTypes(string? filter);
    }
}
