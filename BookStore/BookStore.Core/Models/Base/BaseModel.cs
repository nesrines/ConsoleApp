namespace BookStore.Core.Models.Base
{
    public abstract class BaseModel
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}