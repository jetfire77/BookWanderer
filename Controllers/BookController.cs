using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Tanuj.BookStore.Models;
using Tanuj.BookStore.Repository;

namespace Tanuj.BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository = null;
        private readonly ILanguageRepository _languageRepository = null;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BookController(IBookRepository bookRepository, ILanguageRepository languageRepository 
            
            ,IWebHostEnvironment webHostEnvironment)
        {

            _bookRepository = bookRepository;
            _languageRepository = languageRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<ViewResult> GetAllBooks()
        {

            var data = await _bookRepository.GetAllBooks();

            return View(data);

        }

        [Route("book-details/{id}", Name = "bookDetailsRoute")]
        public async Task<ViewResult> GetBook(int id)
        {

            /*
            dynamic data = new System.Dynamic.ExpandoObject();
            data.book = _bookRepository.GetBookById(id);
            data.name = "tanuj";
            return View(data);
            */

            var data = await _bookRepository.GetBookById(id);
            return View(data);



        }

        public List<BookModel> SearchBooks(string bookName, string authorName)
        {
            return _bookRepository.SearchBook(bookName, authorName);
        }

        [Authorize]    // to allow only loggein in user to add book
        public async Task<ViewResult> AddNewBook(bool isSuccess = false, int bookId = 0) {

            var model = new BookModel()
            {
               // Language = "2"
            };


           

            /*  ViewBag.Language = new List<SelectListItem>()
              {

                  new SelectListItem() {Text = "Hindi" , Value ="1" },
                  new SelectListItem() {Text = "English" , Value ="2" },
                  new SelectListItem() {Text = "Dutch" , Value ="3"},
                  new SelectListItem() {Text = "Tamil" , Value ="4"},
                      new SelectListItem() {Text = "Urdu" , Value ="5"},
                          new SelectListItem() {Text = "Chinese" , Value ="6"},

              };

              */


            /*
            ViewBag.Language =  GetLanguage().Select(x=> new SelectListItem()
            {

                Text = x.Text,
                Value= x.Id.ToString(),

            }).ToList();
            */




            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View(model);
        }


        //  creating action method to submit form you can have method with same 
        // name or update name it is your choice
        // but we cannot hve with same name and same parameter
        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookModel) {

            if (ModelState.IsValid) // validation if all the properties are valid
            {      
                if(bookModel.CoverPhoto != null)
                {

                    string folder = "books/cover/";
                   bookModel.CoverImageUrl =  await UploadImage(folder, bookModel.CoverPhoto);
                }

                if (bookModel.GalleryFiles != null)
                {

                    string folder = "books/gallery/";

                    bookModel.Gallery = new List<GalleryModel>();   // to add url of many books

                    foreach (var file  in bookModel.GalleryFiles)
                    {
                        var gallery = new GalleryModel()
                        {
                            Name = file.FileName,
                            URL = await UploadImage(folder, file)     // return url of the images
                        };

                        bookModel.Gallery.Add(gallery);

                    }
                       
                    
                    
                }


                if (bookModel.BookPdf != null)
                {

                    string folder = "books/pdf/";
                    bookModel.BookPdfUrl = await UploadImage(folder, bookModel.BookPdf);
                }

                int id = await _bookRepository.AddNewBook(bookModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookId = id });
                }

            }
            // ViewBag.IsSuccess = false;
            // ViewBag.BookId = 0;




            /*

                ViewBag.Language = new List<SelectListItem>()
                {

                    new SelectListItem() {Text = "Hindi" , Value ="1" },
                    new SelectListItem() {Text = "English" , Value ="2" },
                    new SelectListItem() {Text = "Dutch" , Value ="3"},
                    new SelectListItem() {Text = "Tamil" , Value ="4"},
                        new SelectListItem() {Text = "Urdu" , Value ="5"},
                            new SelectListItem() {Text = "Chinese" , Value ="6"},

                };
            */


           

            return View(); 
        }

        private async Task<string> UploadImage(string folderPath, IFormFile file)
        {
            
            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;

            

            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);  // combining with server path


            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));  // uploading file

            return "/" + folderPath;
        }


        /*
        private List<LanguageModel> GetLanguage()
        {
            return new List<LanguageModel>()
        {
                new LanguageModel(){Id=1, Text="Hindi"},
                new LanguageModel(){Id=2, Text="English"},
                new LanguageModel(){Id=3, Text="Dutch"},
                new LanguageModel(){Id=4, Text="French"},

        };

        }

        */
    }


    
}
