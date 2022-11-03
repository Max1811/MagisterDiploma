namespace Diploma.DataAccess.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public DateTime UpdatedDate { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
