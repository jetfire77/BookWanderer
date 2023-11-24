using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;  // for validation
using Tanuj.BookStore.Enums;
using Tanuj.BookStore.Helpers;

namespace Tanuj.BookStore.Models
{
    public class BookModel
    {
        // properties


      /*  [DataType(DataType.DateTime)]
        [Display(Name = "Chose date and time")]
        public string MyField { get; set; } 
      */

        public int Id { get; set; }

        [StringLength(100, MinimumLength = 5)]
        [Required(ErrorMessage = "Please enter the title of your book")]
        //[MyCustomValidation ( "azure")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter author name")]
        public string Author { get; set; }


        [StringLength(500, MinimumLength = 30)]
        public string Description { get; set; }

        public string Image { get; set; }

        public string Category { get; set; }

        [Required(ErrorMessage = "Please enter the language")]
        public int LanguageId { get; set; }

        public string Language { set; get; }    

        /*
           [Required(ErrorMessage = "Please enter the languages of your book")]
            public List<string> MultiLanguage { get; set; }
        */


      




        [Required(ErrorMessage = "Please enter total pages")]
        [Display(Name ="Total pages of book")]
        public int? TotalPages { get; set; }


        [Display(Name = "Chose the cover photo of your book")]
        [Required]
        public IFormFile CoverPhoto { get; set; }   // book image

        public string CoverImageUrl { get; set; }   // book image url

        [Display(Name = "Chose the gallery images of your book")]
        [Required]
        public IFormFileCollection GalleryFiles { get; set; }   // can also use list<IFormFile> or IEnumerable<IFormFile> 
                                                                // lists of book images

        public List<GalleryModel> Gallery { get; set; }     // urls of images 



        [Display(Name = "Upload your book in pdf format")]
        [Required]
        public IFormFile BookPdf { get; set; }   // pdf

        public string BookPdfUrl { get; set; }   // pdf
    }
}
