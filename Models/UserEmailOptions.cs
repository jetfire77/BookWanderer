using System.Collections.Generic;

namespace Tanuj.BookStore.Models
{
    public class UserEmailOptions
    {

        public List<string> ToEmails { get; set; }   

        public string Subject { get; set; } 

        public string Body { get; set; }

        public List<KeyValuePair<string, string>> PlaceHolders { get; set; }   //for passing dynamic content like username

    }
}
