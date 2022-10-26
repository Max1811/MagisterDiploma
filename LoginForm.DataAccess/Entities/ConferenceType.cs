namespace LoginForm.DataAccess.Entities
{
    public class ConferenceType : BaseEntity
    {
        public string Type { get; set; } 

        public List<Conference> Conferences { get; set; }
    }
}
