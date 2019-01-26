using DecklistProjectASP.Models;
using DecklistProjectASP.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DecklistProjectASP.Services
{
    public class LoadCardsFromId : ILoadCardsFromId
    {
        public async Task<List<CardWithAmount>> Load(List<Card> Cards, IList<int> DeckIDs)
        {
            List<Card> cards = Cards.Where(a => DeckIDs.Any(b => a.CardIdentifier == b)).ToList();
            List<CardWithAmount> cardsWithAmounts = new List<CardWithAmount>();
            foreach(var card in cards)
            {
                CardWithAmount cardWithAmount = new CardWithAmount();
                cardWithAmount.Card = card;
                cardWithAmount.Amount = DeckIDs.Count(x=>x==card.CardIdentifier);
                cardsWithAmounts.Add(cardWithAmount);
            }
            cardsWithAmounts= cardsWithAmounts.Distinct().ToList();
            return cardsWithAmounts;

        }
    }
}
