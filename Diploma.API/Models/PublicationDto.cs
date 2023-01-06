namespace Diploma.API.Models
{
    public class PublicationDto
    {
        public string Name { get; set; }

        public int TypeId { get; set; }

        public string PublishingCity { get; set; }

        public string PublishingHouse { get; set; }

        public string Pages { get; set; }

        public string Organization { get; set; }

        public string Category { get; set; }

        public string Link { get; set; }

        public int? ConferenceId { get; set; }

        public int? DigestId { get; set; }

        public int AuthorId { get; set; }
    }
}
