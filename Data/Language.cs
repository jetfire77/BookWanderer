using System.Collections;
using System.Collections.Generic;

namespace Tanuj.BookStore.Data
{
    public class Language
    {

        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }


        public ICollection<Books> Book { get; set; }

    }

}
