using BookStore.Core.Models.Base;
namespace BookStore.Core.Models
{
    public class Author : BaseModel
    {
        private static int _id;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public List<Book> Books;
        public Author(string FirstName, string LastName, int Age)
        {
            _id++;
            Id = _id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Age = Age;
            Books = new List<Book>();
            CreatedDate = DateTime.UtcNow.AddHours(4);
        }
        public override string ToString()
        {
            return $"Name: {FirstName} {LastName}, Age: {Age}, Created: {CreatedDate}, Updated: {UpdatedDate}";
        }
    }
}