namespace LoginForm.DataAccess.Entities
{
    public class Digest : BaseEntity
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public List<Publication> Publications { get; set; }
    }
}
