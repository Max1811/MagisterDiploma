using AutoMapper;
using Diploma.BL.Models;
using Diploma.BL.Services.Contracts;
using Diploma.DataAccess.Entities;
using Diploma.DataAccess.Repositories.Contracts;

namespace Diploma.BL.Services
{
    public class PublicationService : IPublicationService
    {
        private readonly IGenericRepository<Publication> _genericRepository;
        private readonly IMapper _mapper;

        public PublicationService(
            IGenericRepository<Publication> genericRepository,
            IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(PublicationModel model)
        {
            var entity = _mapper.Map<Publication>(model);

            await _genericRepository.AddAsync(entity);
        }

        public async Task AddPublicationType(PublicationTypeModel model)
        {
            var entity = _mapper.Map<PublicationType>(model);
        }
    }
}
