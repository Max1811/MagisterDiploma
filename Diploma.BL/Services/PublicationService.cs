using AutoMapper;
using Diploma.BL.Models;
using Diploma.BL.Services.Contracts;
using Diploma.DataAccess.Entities;
using Diploma.DataAccess.Repositories.Contracts;

namespace Diploma.BL.Services
{
    public class PublicationService : IPublicationService
    {
        private readonly IPublicationRepository _publicationRepository;
        private readonly IPublicationTypeRepository _publicationTypeRepository;
        private readonly IConferenceRepository _conferenceRepository;
        private readonly IDigestRepository _digestRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public PublicationService(
            IPublicationRepository publicationRepository,
            IPublicationTypeRepository publicationTypeRepository,
            IConferenceRepository conferenceRepository,
            IDigestRepository digestRepository,
            IAuthorRepository authorRepository,
            IMapper mapper)
        {
            _publicationRepository = publicationRepository;
            _publicationTypeRepository = publicationTypeRepository;
            _conferenceRepository = conferenceRepository;
            _digestRepository = digestRepository;
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(PublicationModel model)
        {
            var entity = _mapper.Map<Publication>(model);

            var publication = await _publicationRepository.AddAsync(entity);

            await _authorRepository.AddPublicationAuthor(publication.Id, model.AuthorId);
        }

        public async Task AddConferenceType(string conferenceType)
        {
            var entity = new ConferenceType
            {
                Type = conferenceType
            };

            await _conferenceRepository.AddConferenceType(entity);
        }

        public async Task AddPublicationType(string publicationType)
        {
            var entity = new PublicationType
            {
                Type = publicationType
            };

            await _publicationTypeRepository.AddPublicationType(entity);
        }

        public async Task<IEnumerable<ConferenceTypeModel>> GetConferenceTypes(string? filter)
        {
            var entities = await _conferenceRepository.GetConferenceTypes(filter);

            return _mapper.Map<IEnumerable<ConferenceTypeModel>>(entities);
        }

        public async Task<IEnumerable<PublicationTypeModel>> GetPublicationTypes(string? filter)
        {
            var entities = await _publicationTypeRepository.GetPublicationTypes(filter);

            return _mapper.Map<IEnumerable<PublicationTypeModel>>(entities);
        }

        public async Task AddConference(ConferenceModel model)
        {
            var entity = _mapper.Map<Conference>(model);

            await _conferenceRepository.AddConference(entity);
        }

        public async Task<IEnumerable<ConferenceModel>> GetConferences(string? filter)
        {
            var entities = await _conferenceRepository.GetConferences(filter);

            return _mapper.Map<IEnumerable<ConferenceModel>>(entities);
        }

        public async Task AddDigest(DigestModel model)
        {
            var entity = _mapper.Map<Digest>(model);

            await _digestRepository.AddDigest(entity);
        }

        public async Task<IEnumerable<DigestModel>> GetDigests(string? filter)
        {
            var entities = await _digestRepository.GetDigests(filter);

            return _mapper.Map<IEnumerable<DigestModel>>(entities);
        }

        public async Task AddPublicationAuthor(AuthorModel model)
        {
            var entity = _mapper.Map<Author>(model);

            await _authorRepository.AddPublicationAuthor(entity);
        }

        public async Task<IEnumerable<AuthorModel>> GetPublicationAuthors(string? filter)
        {
            var entities = await _authorRepository.GetPublicationAuthors(filter);

            return _mapper.Map<IEnumerable<AuthorModel>>(entities);
        }

        public async Task<IEnumerable<AuthorTypeModel>> GetAuthorTypes(string? filter)
        {
            var entities = await _authorRepository.GetAuthorTypes(filter);

            return _mapper.Map<IEnumerable<AuthorTypeModel>>(entities);
        }
    }
}
