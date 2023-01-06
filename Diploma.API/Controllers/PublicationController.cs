using AutoMapper;
using Diploma.API.Models;
using Diploma.API.Models.Request;
using Diploma.API.Models.Response;
using Diploma.BL.Models;
using Diploma.BL.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Diploma.API.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class PublicationController : Controller
    {
        private readonly IPublicationService _publicationService;
        private readonly IMapper _mapper;

        public PublicationController(
            IPublicationService publicationService,
            IMapper mapper)
        {
            _publicationService = publicationService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task AddPublication([FromBody] PublicationDto publication)
        {
            var publicationModel = _mapper.Map<PublicationModel>(publication);

            await _publicationService.AddAsync(publicationModel);
        }

        [HttpGet("publication-types")]
        public async Task<IEnumerable<PublicationTypeDto>> GetPublicationTypes([FromQuery] string? filter = null)
        {
            var types = await _publicationService.GetPublicationTypes(filter);

            return _mapper.Map<IEnumerable<PublicationTypeDto>>(types);
        }

        [HttpPost("publication-type")]
        public async Task AddPublicationType([FromBody] AddPublicationTypeRequestDto request)
        {
            await _publicationService.AddPublicationType(request.PublicationType);
        }

        [HttpGet("conference-types")]
        public async Task<IEnumerable<ConferenceTypeResponseDto>> GetConferenceTypes([FromQuery] string? filter = null)
        {
            var conferenceTypes = await _publicationService.GetConferenceTypes(filter);

            return _mapper.Map<IEnumerable<ConferenceTypeResponseDto>>(conferenceTypes);
        }

        [HttpPost("conference-type")]
        public async Task AddConferenceType([FromBody] AddConferenceTypeRequestDto request)
        {
            await _publicationService.AddConferenceType(request.ConferenceType);
        }

        [HttpPost("conference")]
        public async Task AddConference([FromBody] ConferenceDto request)
        {
            var model = _mapper.Map<ConferenceModel>(request);

            await _publicationService.AddConference(model);
        }

        [HttpGet("conferences")]
        public async Task<IEnumerable<ConferenceDto>> GetConferences([FromQuery] string? filter = null)
        {
            var conferences = await _publicationService.GetConferences(filter);

            return _mapper.Map<IEnumerable<ConferenceDto>>(conferences);
        }

        [HttpPost("digest")]
        public async Task AddDigest([FromBody] DigestRequestDto request)
        {
            var model = _mapper.Map<DigestModel>(request);

            await _publicationService.AddDigest(model);
        }

        [HttpGet("digests")]
        public async Task<IEnumerable<DigestRequestDto>> GetDigests([FromQuery] string? filter = null)
        {
            var conferences = await _publicationService.GetDigests(filter);

            return _mapper.Map<IEnumerable<DigestRequestDto>>(conferences);
        }

        [HttpPost("author")]
        public async Task AddPublicationAuthor([FromBody] AuthorRequestDto request)
        {
            var model = _mapper.Map<AuthorModel>(request);

            await _publicationService.AddPublicationAuthor(model);
        }

        [HttpGet("authors")]
        public async Task<IEnumerable<AuthorRequestDto>> GetPublicationAuthors([FromQuery] string? filter = null)
        {
            var authors = await _publicationService.GetPublicationAuthors(filter);

            return _mapper.Map<IEnumerable<AuthorRequestDto>>(authors);
        }

        [HttpGet("author-types")]
        public async Task<IEnumerable<AuthorTypeResponseDto>> GetAuthorTypes([FromQuery] string? filter = null)
        {
            var authorTypes = await _publicationService.GetAuthorTypes(filter);

            return _mapper.Map<IEnumerable<AuthorTypeResponseDto>>(authorTypes);
        }
    }
}
