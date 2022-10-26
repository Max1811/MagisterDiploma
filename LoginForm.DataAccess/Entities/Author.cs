namespace LoginForm.DataAccess.Entities
{
    public class Author : BaseEntity
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public string Patronymic { get; set; }

        public int AuthorTypeId { get; set; }

        public AuthorType AuthorType { get; set; }

        public List<PublicationAuthor> PublicationAuthors { get; set; }
    }
}
