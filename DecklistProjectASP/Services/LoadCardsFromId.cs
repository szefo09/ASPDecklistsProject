using DecklistProjectASP.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DecklistProjectASP.Services
{
    public class LoadCardsFromId : ILoadCardsFromId
    {
        public async Task<List<Card>> Load(List<Card> Cards, IList<int> DeckIDs)
        {
            return Cards.Where(a => DeckIDs.Any(b => a.CardIdentifier == b)).ToList();
        }
    }
}
