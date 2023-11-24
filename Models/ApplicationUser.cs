using Microsoft.AspNetCore.Identity;
using System;

namespace Tanuj.BookStore.Models
{
    public class ApplicationUser : IdentityUser    // to add more coloumn to user table provided by identity framework
    { 
        public string FirstName { get; set; }   
        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }       // ? meaning it is optional

    }
}
