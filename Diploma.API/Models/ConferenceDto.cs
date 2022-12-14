namespace Diploma.API.Models
{
    public class ConferenceDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ConferenceTypeId { get; set; }

        public string ConferenceCity { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
