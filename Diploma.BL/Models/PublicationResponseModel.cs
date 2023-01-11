namespace Diploma.BL.Models
{
    public class PublicationResponseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public PublicationTypeModel Type { get; set; }

        public string PublishingCity { get; set; }

        public string PublishingHouse { get; set; }

        public string Pages { get; set; }

        public string Organization { get; set; }

        public string Category { get; set; }

        public string Link { get; set; }

        public ConferenceModel? Conference { get; set; }

        public DigestModel? Digest { get; set; }

        public AuthorModel? Author { get; set; }

        public string AuthorId { get; set; }
    }
}
