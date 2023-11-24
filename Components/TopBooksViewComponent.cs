using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tanuj.BookStore.Repository;

namespace Tanuj.BookStore.Components
{
    public class TopBooksViewComponent : ViewComponent
    {

        public readonly IBookRepository _bookRepository;
        public TopBooksViewComponent(IBookRepository bookRepository)
        {
           _bookRepository = bookRepository;
        }

       

        public async Task<IViewComponentResult> InvokeAsync(int count)
        {
            var books = await _bookRepository.GetTopBooksAsync(count);
            return View(books);

        }
    }
}
