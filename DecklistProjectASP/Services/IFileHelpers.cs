using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DecklistProjectASP.Services
{
    public interface IFileHelpers
    {
        Task<string> ProcessFormFile(IFormFile formFile, ModelStateDictionary modelState);
    }
}