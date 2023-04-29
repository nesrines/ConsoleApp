using BookStore.Core.Models.Base;
using BookStore.Core.Enums;
namespace BookStore.Core.Models
{
    public class Book:BaseModel
    {
        private static int _id;
        public string Title { get; set; }
        public Author Author { get; set; }
        public BookCategory Category { get; set; }
        public double Price { get; set; }
        public double DiscountedPrice { get; set; }
        public bool IsInStock { get; set; }
        public Book(string Title, Author Author, BookCategory Category, double Price, double DiscountedPrice)
        {
            _id++;
            Id = _id;
            this.Title = Title;
            this.Author = Author;
            this.Category = Category;
            this.Price = Price;
            this.DiscountedPrice = DiscountedPrice;
            CreatedDate = DateTime.UtcNow.AddHours(4);
        }
        public override string ToString()
        {
            if (DiscountedPrice < Price)
            { return $"{Title} by {Author}, Category: {Category}, Price: ${Price} ({(Price - DiscountedPrice) / Price}% off), Created: {CreatedDate}, Updated: {UpdatedDate}"; }
            else { return $"{Title} by {Author}, Category: {Category}, Price: ${Price}, Created: {CreatedDate}, Updated: {UpdatedDate}"; }
        }
    }
}