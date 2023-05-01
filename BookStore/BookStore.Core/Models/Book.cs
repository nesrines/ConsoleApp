using BookStore.Core.Models.Base;
using BookStore.Core.Enums;
namespace BookStore.Core.Models
{
    public class Book : BaseModel
    {
        private static int _id;
        public string Title { get; set; }
        public Author Author { get; set; }
        public BookCategory Category { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public double DiscountedPrice { get; set; }
        public bool IsInStock { get; set; }
        public Book(string Title, Author Author, BookCategory Category, int Count, double Price, double DiscountedPrice)
        {
            _id++;
            Id = _id;
            this.Title = Title;
            this.Author = Author;
            this.Category = Category;
            this.Count = Count;
            IsInStock = Count > 0;
            this.Price = Price;
            this.DiscountedPrice = DiscountedPrice;
            CreatedDate = DateTime.UtcNow.AddHours(4);
        }
        public override string ToString()
        {
            if (IsInStock) Console.ForegroundColor = ConsoleColor.Blue;
            else Console.ForegroundColor = ConsoleColor.Gray;
            if (DiscountedPrice < Price)
            { return $"ID: {Id}, '{Title}' by {Author.FirstName} {Author.LastName}, Category: {Category}, in Stock: {Count}, Price: ${Price} ({(Price - DiscountedPrice) / Price}% off), Created: {CreatedDate}, Updated: {UpdatedDate}"; }
            else
            { return $"ID: {Id}, '{Title}' by {Author.FirstName} {Author.LastName}, Category: {Category}, in Stock: {Count}, Price: ${Price}, Created: {CreatedDate}, Updated: {UpdatedDate}"; }
        }
    }
}