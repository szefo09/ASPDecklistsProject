using System.Collections.Generic;
using System.Threading.Tasks;
using DecklistProjectASP.Models;
using DecklistProjectASP.ViewModel;

namespace DecklistProjectASP.Services
{
    public interface ILoadCardsFromId
    {
        Task<List<CardWithAmount>> Load(List<Card> Cards, IList<int> DeckIDs);
    }
}