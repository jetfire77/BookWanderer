using System.Collections;
using System.Collections.Generic;

namespace Tanuj.BookStore.Data
{

    // this class because we are using code first apporach 




    public class Books
    {

        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public string Category { get; set; }

        public int LanguageId { get; set; }

        public int TotalPages { get; set; }

        public Language Language { get; set; }    // relation between Language table and book table


        public string CoverImageUrl { get; set; }  

        public ICollection<BookGallery> bookGallery { get; set; }   //by this we have created 1 to many relationship betweem books and bookgallery table


        public string BookPdfUrl { get; set; }  

    }
}
