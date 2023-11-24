using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tanuj.BookStore.Data;
using Tanuj.BookStore.Models;

namespace Tanuj.BookStore.Repository
{
    public class LanguageRepository : ILanguageRepository
    {

        private readonly BookStoreContext _context = null;

        public LanguageRepository(BookStoreContext context) // instantiating context using dependency injection 
        {
            _context = context;
        }

        // to perform operation we have to create  model into appliacation for language



        public async Task<List<LanguageModel>> GetLanguages()
        {
            return await _context.Language.Select(x => new LanguageModel()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,


            }).ToListAsync();
        }
    }
}
