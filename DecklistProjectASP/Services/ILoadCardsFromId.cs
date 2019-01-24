using System.Collections.Generic;
using System.Threading.Tasks;
using DecklistProjectASP.Models;

namespace DecklistProjectASP.Services
{
    public interface ILoadCardsFromId
    {
        Task<List<Card>> Load(List<Card> Cards, IList<int> DeckIDs);
    }
}