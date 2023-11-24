using System.Collections.Generic;
using System.Threading.Tasks;
using Tanuj.BookStore.Models;

namespace Tanuj.BookStore.Repository
{
    public interface ILanguageRepository
    {
        Task<List<LanguageModel>> GetLanguages();
    }
}