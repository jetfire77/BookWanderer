using System.Security.Principal;

namespace Tanuj.BookStore.Data
{
    public class BookGallery
    {

        public int Id { get; set; }

        public int BookId { get; set; }

        public string Name { get; set; }

        public string URL { get; set; }

        public  Books book { get; set; }  // foreign key
    }
}
