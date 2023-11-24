using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tanuj.BookStore.Data;
using Tanuj.BookStore.Models;

namespace Tanuj.BookStore.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _context = null;

        public BookRepository(BookStoreContext context) // instantiating context using dependency injection 
        {
            _context = context;
        }
        public async Task<int> AddNewBook(BookModel model)
        {

            var newBook = new Books()
            {
                Title = model.Title,

                Author = model.Author,
                Description = model.Description,
                Image = model.Image,
                Category = model.Category,
                LanguageId = model.LanguageId,
                TotalPages = model.TotalPages.HasValue ? model.TotalPages.Value : 0,
                CoverImageUrl = model.CoverImageUrl,
                BookPdfUrl = model.BookPdfUrl

            };
            newBook.bookGallery = new List<BookGallery>();   // database

            foreach (var file in model.Gallery)          // url of many images in code i.e from input 
            {
                newBook.bookGallery.Add(new BookGallery()  // adding to database
                {
                    Name = file.Name,
                    URL = file.URL

                });
            }

            await _context.Books.AddAsync(newBook);  // adding to database
            await _context.SaveChangesAsync();

            return newBook.Id;

        }

        public async Task<List<BookModel>> GetAllBooks()
        {

            return await _context.Books
                .Select(book => new BookModel()
                {

                    Author = book.Author,
                    Description = book.Description,
                    Image = book.Image,
                    Category = book.Category,
                    LanguageId = book.LanguageId,
                    Language = book.Language.Name,   // from book table going to language table and getting name
                    TotalPages = book.TotalPages,
                    Id = book.Id,
                    Title = book.Title,
                    CoverImageUrl = book.CoverImageUrl



                }).ToListAsync();

        }

        public async Task<BookModel> GetBookById(int id)
        {

            // linq query
            // return DataSource().Where(x => x.Id == id).FirstOrDefault();


            // to get book  from database
            return await _context.Books.Where(x => x.Id == id)
                 .Select(book => new BookModel()
                 {
                     Author = book.Author,
                     Description = book.Description,
                     Image = book.Image,
                     Category = book.Category,
                     LanguageId = book.LanguageId,
                     Language = book.Language.Name,
                     TotalPages = book.TotalPages,
                     Id = book.Id,
                     Title = book.Title,
                     CoverImageUrl = book.CoverImageUrl,
                     Gallery = book.bookGallery.Select(g => new GalleryModel()
                     {
                         Id = g.Id,
                         Name = g.Name,
                         URL = g.URL


                     }).ToList(),
                     BookPdfUrl = book.BookPdfUrl

                 }).FirstOrDefaultAsync();



        }


        public List<BookModel> SearchBook(string title, string authorName)
        {
            // linq query to reterive hardcoded data
            // return DataSource().Where(x=> x.Title.Contains(title)  && x.Author.Contains(authorName)).ToList();
            return null;
        }


        public async Task<List<BookModel>> GetTopBooksAsync(int count)
        {

            return await _context.Books
                .Select(book => new BookModel()
                {

                    Author = book.Author,
                    Description = book.Description,
                    Image = book.Image,
                    Category = book.Category,
                    LanguageId = book.LanguageId,
                    Language = book.Language.Name,   // from book table going to language table and getting name
                    TotalPages = book.TotalPages,
                    Id = book.Id,
                    Title = book.Title,
                    CoverImageUrl = book.CoverImageUrl



                }).Take(count).ToListAsync();

        }


        public string GetAppName()
        {
            return "BookWanderer";
        }


        /*
        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel() {Id =  1, Title="Cosmos (1980) ", Author=" Carl Sagan ",Category= "Science", Language="English" , TotalPages= 365 ,Image="https://cdn.britannica.com/36/194736-050-CA5BE18B/Carl-Sagan-science-writer-American.jpg", Description="Cosmos is a popular science book written by astronomer and Pulitzer Prize-winning author Carl Sagan. It was published in 1980 as a companion piece to the PBS mini-series Cosmos: A Personal Voyage with which it was co-developed and intended to " +
                "complement. Each of the book’s 13 illustrated chapters corresponds to one of the 13 episodes of the television series. Just a few of the ideas explored in Cosmos include the history and mutual development of science and civilization, the nature of the Universe, human and robotic space exploration, the inner workings of the " +
                "cell and the DNA that controls it, and the dangers and future implications of nuclear war. One of Sagan's main purposes for both the book and the television series was to explain complex " +
                "scientific ideas in a way that anyone interested in learning can understand. "},
                new BookModel() {Id =  2, Title="A Brief History of Time (1988)", Author="Stephen Hawking " ,Category= "Science", Language="English" , TotalPages= 256 , Description="A Brief History Of Time demystifies terms like anti matter, quarks, black holes, arrows of time, and big bang for the layman. It talks about the bigger God and inexplicable and unforeseen possibilities. The author brings alive images with his astounding imagination. With his brilliant intellect, he the enlightens the reader about secrets of the universe. This book was published by Bantam in the year 1998."},
                new BookModel() {Id =  3, Title="The Origin of Species (1859)", Author="Charles Darwin ",Category= "Science", Language="English" , TotalPages= 502, Description = "On the Origin of Species (or, more completely, On the Origin of Species by Means of Natural Selection, or the Preservation of Favoured Races in the Struggle for Life) is a work of scientific literature by Charles Darwin that is considered to be the foundation of evolutionary biology"},
                new BookModel() {Id =  4, Title="Philosophiae Naturalis Principia Mathematica (1687)", Author="Isaac Newton ",Category= "Science", Language="Latin" , TotalPages= 212 ,Description="Philosophiae naturalis principia mathematica (Mathematical principles of natural philosophy) is Sir Isaac Newton's masterpiece. Its appearance was a turning point in the history of science, and the treatise is considered by many as the most important scientific work ever published. Newton (1642--1727) was a professor of mathematics at Trinity College, Cambridge, when he produced the work. It presents the basis of physics and astronomy, formulated in the language of pure geometry. It is a deductive work in which, from very general propositions, mechanical properties are demonstrated in the form of theorems. It lays the foundations of hydrostatics, hydrodynamics, and acoustics, and systematizes a method for the study of nature by mathematical means. "},
                new BookModel() {Id = 5, Title="Relativity: The Special and General Theory  (1916)", Author=" Albert Einstein",Category= "Science", Language="English" , TotalPages= 164, Description="Discover Albert Einstein's groundbreaking theories with \"Relativity: The Special and the General Theory.\" This influential work provides a comprehensive exploration of the principles that revolutionized our understanding of space, time, and gravity. A must-read for science enthusiasts and those intrigued by the mysteries of the universe."},


                  new BookModel() {Id = 6, Title="Data Structures and Algorithms Made Easy (2012)", Author=" Narasimha Karumanchi",Category= "Computer Science", Language="English" , TotalPages= 453, Description="Narasimha Karumanchi is the founder of CareerMonk and author of few books on data structures, algorithms, and design patterns. He was a software developer who has been both interviewer and interviewee over his long career. Most recently he worked for Amazon Corporation, IBM labs, Mentor Graphics, and Microsoft. He filed patents which are under processing. He authored the following books which got translated to international languages: Chinese, Japanese, Korea and Taiwan. Also, around 58 international universities were using these books as reference for academic courses. Data Structures and Algorithms Made Easy Data Structures and Algorithms Made Easy in Java Elements of Computer Networking Data Structures and Algorithms Made Easy for GATE Peeling Design Patterns Coding Interview Questions Narasimha held M.Tech. in computer science from IIT, Bombay, after finishing his B.Tech. from JNT university. He has also taught data structures and algorithms at various training institutes and colleges." }
            };
        }

        */
    }
}
