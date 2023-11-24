using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Dynamic;
using System.Net;
using System.Threading.Tasks;
using Tanuj.BookStore.Models;
using Tanuj.BookStore.Service;

namespace Tanuj.BookStore.Controllers
{
    public class HomeController : Controller
    {
        //private readonly IConfiguration configuration;

        //public HomeController(IConfiguration _configuration)  // using dependency injection to read appsettings.json
        //{
        //    configuration = _configuration;
        //}


        private readonly NewBookAlertConfig _newBookAlertconfiguration;
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;

        public HomeController(IOptionsSnapshot<NewBookAlertConfig> newBookAlertconfiguration,
            IUserService userService , IEmailService emailService)  // using dependency injection to read appsettings.json   // IUserService userService
        {
            _newBookAlertconfiguration = newBookAlertconfiguration.Value;
            _userService = userService;
            _emailService = emailService;
        }

        [ViewData]  // decoritating with viewdata attribute
        public string CustomProperty { get; set; }


        [ViewData]
        public string Title { get; set; }

        [ViewData]
        public BookModel book { get; set; }

        
        public async  Task<ViewResult> Index()
        {

            UserEmailOptions options = new UserEmailOptions
            {
                ToEmails = new List<string>()
                {
                    "test@gmail.com"
                },
                PlaceHolders = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("{{UserName}}", "Tanuj kumar")
                }
            };

          //await  _emailService.SendTestEmail(options);


            var userId = _userService.GetUserId(); 
            var isLoggedIn = _userService.IsAuthenticated();
          

            bool isDisplay = _newBookAlertconfiguration.DisplayNewBookAlert;


            /* ViewBag.Title = "Named Book Wanderer";
               dynamic data = new ExpandoObject();
               data.id = 1;
               data.name = "test";
               ViewBag.Data = data;

               ViewBag.Type = new BookModel()
               {
                   Id = 5,
                   Author = "tanuj",


               };

               */


            ViewData["property1"] = "nitish";

            ViewData["book"] = new BookModel() { Author = "Tanuj", Id = 1 };



            CustomProperty = "Custom value";
            Title = "Home Page";

            book = new BookModel() { Id = 7, Title="Harry potter", Author="j k rollings" };


            var obj = new { id = 1, Name="tanuj" };
            return  View(obj);
        }


        //[Route("about-us")]   // attribute routing
        public ViewResult AboutUs() {

            Title = "About us";

            return View();
        }


       
        public ViewResult ContactUs()
        {
            Title = "Contact us";

            return View();
        }
    }
}
