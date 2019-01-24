using DecklistProjectASP.Data;
using DecklistProjectASP.Models;
using DecklistProjectASP.ViewModel;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace DecklistProjectASP.Services
{
    public class CardDataAPI : ICardDataAPI
    {
        public async Task<List<Card>> GetCardListFromAPI()
        {
            List<ApiCard> deserializedCards = new List<ApiCard>();
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync("https://db.ygoprodeck.com/api/v2/cardinfo.php").Result;
                if (response.IsSuccessStatusCode)
                {
                    string CardsJsonString =await response.Content.ReadAsStringAsync();
                    CardsJsonString = CardsJsonString.Substring(1, CardsJsonString.Length - 2);
                    deserializedCards.AddRange(JsonConvert.DeserializeObject<List<ApiCard>>(CardsJsonString));
                }
            }
            List<Card> cards = new List<Card>();
            foreach (var c in deserializedCards)
            {
                Card card = new Card()
                {
                    CardName = c.name,
                    CardIdentifier = Convert.ToInt32(c.id),
                    CardArtPath = "apiPics/" + c.id + ".jpg",
                    IsCardArtDownloaded = false
                };
                cards.Add(card);
            }
            return cards;
        }
    }
}
