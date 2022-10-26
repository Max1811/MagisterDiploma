namespace LoginForm.DataAccess.Entities
{
    public class Conference : BaseEntity
    {
        public string Name { get; set; }

        public int ConferenceTypeId { get; set; }

        public string ConferenceCity { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public ConferenceType ConferenceType { get; set; }

        public List<Publication> Publications { get; set; }
    }
}
