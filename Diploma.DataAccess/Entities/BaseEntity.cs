namespace Diploma.DataAccess.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
