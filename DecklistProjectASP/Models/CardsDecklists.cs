using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DecklistProjectASP.Models
{
    public class CardsDecklists
    {
        public int CardId { get; set; }
        public Card Card { get; set; }
        public int DecklistId { get; set; }
        public Decklist Decklist { get; set; }
    }
}
