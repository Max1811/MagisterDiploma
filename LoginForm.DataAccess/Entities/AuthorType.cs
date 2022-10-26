namespace LoginForm.DataAccess.Entities
{
    public class AuthorType : BaseEntity
    {
        public string Type { get; set; }

        public List<Author> Authors { get; set; }
    }
}
