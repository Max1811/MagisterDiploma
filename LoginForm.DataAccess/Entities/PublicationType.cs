namespace LoginForm.DataAccess.Entities
{
    public class PublicationType : BaseEntity
    {
        public string Type { get; set; }

        public List<Publication> Publications { get; set; }
    }
}
