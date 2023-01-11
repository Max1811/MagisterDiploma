using Diploma.API.Models.Request;

namespace Diploma.API.Models.Response
{
    public class PublicationResponseDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public PublicationTypeDto Type { get; set; }

        public string PublishingCity { get; set; }

        public string PublishingHouse { get; set; }

        public string Pages { get; set; }

        public string Organization { get; set; }

        public string Category { get; set; }

        public string Link { get; set; }

        public ConferenceDto? Conference { get; set; }

        public DigestRequestDto? Digest { get; set; }

        public AuthorResponseDto Author { get; set; }
    }
}
