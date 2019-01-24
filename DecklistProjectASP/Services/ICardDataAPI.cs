using System.Collections.Generic;
using System.Threading.Tasks;
using DecklistProjectASP.Models;

namespace DecklistProjectASP.Services
{
    public interface ICardDataAPI
    {
        Task<List<Card>> GetCardListFromAPI();
    }
}