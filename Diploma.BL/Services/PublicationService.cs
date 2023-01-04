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
        private readonly IMapper _mapper;

        public PublicationService(
            IPublicationRepository publicationRepository,
            IPublicationTypeRepository publicationTypeRepository,
            IMapper mapper)
        {
            _publicationRepository = publicationRepository;
            _publicationTypeRepository = publicationTypeRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(PublicationModel model)
        {
            var entity = _mapper.Map<Publication>(model);

            await _publicationRepository.AddAsync(entity);
        }

        public async Task AddPublicationType(string publicationType)
        {
            var entity = new PublicationType
            {
                Type = publicationType
            };

            await _publicationTypeRepository.AddPublicationType(entity);
        }

        public async Task<IEnumerable<PublicationTypeModel>> GetPublicationTypes(string? filter)
        {
            var entities = await _publicationTypeRepository.GetPublicationTypes(filter);

            return _mapper.Map<IEnumerable<PublicationTypeModel>>(entities);
        }
    }
}
