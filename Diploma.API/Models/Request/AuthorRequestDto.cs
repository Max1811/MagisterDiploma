namespace Diploma.API.Models.Request
{
    public class AuthorRequestDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Patronymic { get; set; }

        public int AuthorTypeId { get; set; }
    }
}
