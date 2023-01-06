namespace Diploma.BL.Models
{
    public class AuthorModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Patronymic { get; set; }

        public int AuthorTypeId { get; set; }
    }
}
