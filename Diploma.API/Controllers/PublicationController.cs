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
            //add validation to publication
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
    }
}
